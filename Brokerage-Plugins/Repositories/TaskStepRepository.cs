using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories.Base;
using Brokerage_Plugins.Repositories.Resources;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories
{
    internal class TaskStepRepository : PluginRepository<TaskStep>
    {
        public TaskStepRepository(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }
        public TaskStep GetTaskStep(EntityReference reference)
        {
            var columnSet = new string[]
            {
                PluginResource.TaskStep_Team,
                PluginResource.TaskStep_User,
                PluginResource.TaskStep_Message,
                PluginResource.TaskStep_CompletedStep,
                PluginResource.TaskStep_RejectedStep,
                PluginResource.TaskStep_SmsTemplate,
                PluginResource.TaskStep_DueDate,
                PluginResource.TaskStep_ProsseccDuration,
                PluginResource.TaskStep_CompleteStatus,
                PluginResource.TeskStep_CompleteStatusReason,
                PluginResource.TaskStep_RejectStatus,
                PluginResource.TaskStep_RejectStatusReason,
                PluginResource.TaskStep_UserSmsTemplate,
                PluginResource.TaskStep_SendSmsToUser,
                PluginResource.TaskStep_SlaCategory
            };
            return base.GetEntityById(reference, columnSet).ToEntity<TaskStep>();
        }
    }
}
