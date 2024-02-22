using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories;
using Brokerage_Plugins.Repositories.Base;
using Brokerage_Plugins.Repositories.Resources;
using Brokerage_Plugins.Services.Base;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Services
{
    internal class TaskService : BaseService
    {
        public TaskService(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }

        public void CreateNewTaskFromChangeStateTask()
        {
            var taskRepository = new TaskRepository(Context);
            var taskEntity = taskRepository.CreateInstance();
            var preImageTask = taskRepository.CreateInstancepPreImage();

            if (preImageTask?.TaskStep != null && preImageTask?.Regarding != null)
            {
                var taskManagerService = new TaskManagerService(Context);
                var taskStepRepository = new TaskStepRepository(Context);
                var repository = new BaseRepository(Context.OrganizationService);
                var taskStep = taskStepRepository.GetTaskStep(preImageTask.TaskStep);
                if (taskStep != null)
                {
                    if (taskEntity?.StatusReason.Value == (int)TaskStatusReason.Completed)
                    {
                        if (taskStep?.CompletedStep != null && taskStep?.CompletedStep.Id != Guid.Empty)
                        {
                            var nextStep = taskStepRepository.GetTaskStep(taskStep.CompletedStep);
                            taskManagerService.CreateTask(nextStep, preImageTask.Regarding);

                        }

                        if (preImageTask.Regarding?.LogicalName == PluginResource.Case_LogicalName)
                        {
                            if (taskStep?.CompleteStatus != null)
                            {
                                if (taskStep?.CompleteStatus.Value == 1)
                                {
                                    var caseService = new CaseService(Context);
                                    caseService.CloseCase(preImageTask.Regarding, (CaseStatusReason)taskStep.CompleteStatusReason.Value);
                                }
                                else
                                {
                                    repository.SetState(preImageTask.Regarding, new OptionSetValue(taskStep.CompleteStatus.Value), new OptionSetValue(taskStep.CompleteStatusReason.Value));

                                }
                            }

                        }
                        if (taskStep?.SmsTemplate != null && taskStep?.SmsTemplate?.Id != Guid.Empty)
                        {
                            var smsRepository = new SmsRepository(Context.OrganizationService);
                            var smsTemplateRepository = new SmsTemplateRepository(Context.OrganizationService);
                            var smsTemplate = smsTemplateRepository.GetSmsTemplate(taskStep.SmsTemplate);
                            var caseRepository = new CaseRepository(Context);
                            var caseEntity = caseRepository.GetCase(preImageTask.Regarding);
                            var sms = new Sms()
                            {
                                Regarding = preImageTask?.Regarding,
                                Description = smsTemplate?.Text,
                                To = caseEntity?.Customer,
                                SmsTemplate = smsTemplate?.ToEntityReference(),
                                Subject = smsTemplate?.Name + "-" + caseEntity?.Customer?.Name
                            };
                            smsRepository.CreateEntity(sms);
                        }
                    }
                    if (taskEntity?.StatusReason.Value == (int)TaskStatusReason.Canceled) //cancel
                    {
                        if (taskStep.RejectedStep != null && taskStep.RejectedStep?.Id != Guid.Empty)
                        {
                            var nextStep = taskStepRepository.GetTaskStep(taskStep?.RejectedStep);
                            taskManagerService.CreateTask(nextStep, preImageTask?.Regarding);
                        }

                        if (taskStep.RejectStatus != null)
                        {
                            repository.SetState(preImageTask.Regarding, new OptionSetValue(taskStep.RejectStatus.Value), new OptionSetValue(taskStep.RejectStatusReason.Value));
                        }

                    }
                }
            }
        }

        public void UpdateTaskByOwner()
        {
            var teamRepository = new TeamRepository(Context);
            var taskRepository = new TaskRepository(Context);
            var preImageTask = taskRepository.CreateInstancepPreImage();

            if (preImageTask?.Owner != null)
            {
                var currentUser = Context.PluginExecutionContext.UserId;
                if (preImageTask.Owner?.LogicalName == PluginResource.Team_LogicalName)
                {
                    var isMember = teamRepository.GetMembersOfTeam(preImageTask.Owner.Id, currentUser);

                    if (isMember == false)
                        throw new InvalidPluginExecutionException("شما مجوز ایجاد تغییرات روی این رکورد را ندارید");

                }

                else if (preImageTask.Owner?.LogicalName == PluginResource.SystemUser_LogicalName)
                {
                    if (currentUser != preImageTask.Owner?.Id)
                    {
                        throw new InvalidPluginExecutionException(
                            "شما مجوز ایجاد تغییرات روی این رکورد را ندارید");
                    }
                }
            }
        }

        public void SetDeadlines()
        {
            var taskRepository = new TaskRepository(Context);
            var slaCategoryRepository = new SlaCategoryRepository(Context);

            var taskInstance = taskRepository.CreateInstance();
            if (taskInstance.Contains(PluginResource.Task_SlaCategory))
            {
                var columnSet = new string[]
                {
                    PluginResource.SlaCategory_Duration1, PluginResource.SlaCategory_Duration2, PluginResource.SlaCategory_Duration3,
                    PluginResource.SlaCategory_Activation1, PluginResource.SlaCategory_Activation2, PluginResource.SlaCategory_Activation3
                };
                var slaCategory = slaCategoryRepository.GetEntityById(taskInstance.SlaCategory, columnSet)?
                    .ToEntity<SlaCategory>();
                if (slaCategory.Activation1 && slaCategory?.Duration1 > 0)
                {
                    taskInstance.Deadline1 = taskInstance.CreatedOn.AddMinutes(Convert.ToDouble(slaCategory.Duration1));
                }

                if (slaCategory.Activation2 && slaCategory?.Duration2 > 0)
                {
                    taskInstance.Deadline2 = taskInstance.CreatedOn.AddMinutes(Convert.ToDouble(slaCategory.Duration2));
                }

                if (slaCategory.Activation3 && slaCategory?.Duration3 > 0)
                {
                    taskInstance.Deadline3 = taskInstance.CreatedOn.AddMinutes(Convert.ToDouble(slaCategory.Duration3));
                }
            }

        }
    }
}
