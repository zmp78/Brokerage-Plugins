using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories;
using Brokerage_Plugins.Services.Base;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Services
{
    internal class TaskManagerService : BaseService
    {
        public TaskManagerService(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }

        public void CreateTask(TaskStep taskStep, EntityReference caseReference)
        {
            var caseRepository = new CaseRepository(Context);
            var task = new Models.Task()
            {

                Subject = taskStep.Message,
                TaskStep = taskStep.ToEntityReference(),
                Regarding = caseReference,
            };
            //if (taskStep.DueDate != null)
            //{
            //    task.Deadline = DateTime.Now.AddMinutes(taskStep.DueDate);
            //}
            if (taskStep.User != null && taskStep.User.Id != Guid.Empty)
            {
                task.Owner = taskStep.User;
            }
            else if (taskStep.Team != null && taskStep.Team.Id != Guid.Empty)
            {
                task.Owner = taskStep.Team;
            }
            else
            {
                var caseEntity = caseRepository.GetCase(caseReference);
                task.Owner = caseEntity.Owner;
            }
            var taskRepository = new TaskRepository(Context);

            if (taskStep.UserSmsTemplate != null && taskStep.UserSmsTemplate.Id != Guid.Empty)
            {
                var smsRepository = new SmsRepository(Context.OrganizationService);
                var smsTemplateRepository = new SmsTemplateRepository(Context.OrganizationService);
                var smsTemplate = smsTemplateRepository.GetSmsTemplate(taskStep?.UserSmsTemplate);
                var caseEntity = caseRepository.GetCase(caseReference);
                var taskstepRepository = new TaskStepRepository(Context);
                var taskStepEntity = taskstepRepository.GetTaskStep(taskStep?.ToEntityReference());
                if (taskStepEntity?.SendSmsToUser != null && taskStepEntity?.SendSmsToUser.Id != Guid.Empty)
                {
                    var sms = new Sms()
                    {
                        To = taskStepEntity?.SendSmsToUser,
                        Regarding = caseEntity?.ToEntityReference(),
                        Description = smsTemplate?.Text,
                        SmsTemplate = smsTemplate?.ToEntityReference(),
                        Subject = smsTemplate?.Name + "-" + caseEntity?.Customer?.Name
                    };
                    smsRepository.CreateEntity(sms);
                }

            }

            if (taskStep.SlaCategory != null && taskStep.SlaCategory.Id != Guid.Empty)
            {
                task.SlaCategory = taskStep?.SlaCategory;
            }
            task.Id = taskRepository.CreateEntity(task);

        }

        public TaskManager GetTaskManager(Guid caseCategoryId, Guid caseSubCategoryId)
        {
            var taskManagerRepository = new TaskManagerRepository(Context);
            var taskManager = taskManagerRepository.GetTaskManagerFromCaseCategory(caseCategoryId, caseSubCategoryId);
            if (taskManager == null)
            {
                taskManager = taskManagerRepository.GetTaskManagerFromCaseCategoryAndSubCategory(caseCategoryId, caseSubCategoryId);
            }
            return taskManager;
        }
    }
}
