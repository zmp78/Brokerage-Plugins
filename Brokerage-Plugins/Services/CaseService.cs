using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories;
using Brokerage_Plugins.Repositories.Resources;
using Brokerage_Plugins.Services.Base;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Services
{
    internal class CaseService : BaseService
    {
        public CaseService(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }

        public void CreateTaskFromCase()
        {
            var caseCategoryId = Guid.Empty;
            var caseSubCategoryId = Guid.Empty;
            var caseRepository = new CaseRepository(Context);
            var caseEntity = caseRepository.CreateInstance();
            if (caseEntity.Contains(PluginResource.Case_CaseCategory))
            {
                caseCategoryId = caseEntity.CaseCategory.Id;
            }
            if (caseEntity.Contains(PluginResource.Case_CaseSubCategory))
            {
                caseSubCategoryId = caseEntity.CaseSubCategory.Id;
            }

            if (caseCategoryId != Guid.Empty)
            {
                var taskManagerService = new TaskManagerService(Context);
                var taskManager = taskManagerService.GetTaskManager(caseCategoryId, caseSubCategoryId);
                if (taskManager == null)
                {
                    taskManager = taskManagerService.GetTaskManager(caseCategoryId, Guid.Empty);
                }
                if (taskManager != null)
                {
                    var taskStepRepository = new TaskStepRepository(Context);
                    var taskStep = taskStepRepository.GetTaskStep(taskManager.FirstStep);
                    if (taskStep != null)
                    {
                        taskManagerService.CreateTask(taskStep, caseEntity.ToEntityReference());
                    }
                }
            }
        }

        public void CloseCase(EntityReference caseReference, CaseStatusReason caseStatusReason)
        {
            var caseRepository = new CaseRepository(Context);
            var resolution = new Entity("incidentresolution");
            resolution["subject"] = "Case Closed";
            resolution["incidentid"] = caseReference;
            CloseIncidentRequest closeRequest = new CloseIncidentRequest();
            closeRequest.IncidentResolution = resolution;
            closeRequest.Status = new OptionSetValue((int)caseStatusReason);
            CloseIncidentResponse closeResponse = (CloseIncidentResponse)caseRepository.Service.Execute(closeRequest);
        }
    }
}
