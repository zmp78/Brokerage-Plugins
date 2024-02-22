using Brokerage_Plugins.Repositories.Resources;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Models
{
    [EntityLogicalName("frb_taskstep")]
    internal class TaskStep : Entity
    {
        public TaskStep()
        {
            this.LogicalName = PluginResource.TaskStep_LogicalName;
        }
        public EntityReference TaskManager
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_TaskManager);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_TaskManager, value);
            }
        }
        public EntityReference Team
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_Team);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_Team, value);
            }
        }

        public EntityReference User
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_User);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_User, value);
            }
        }
        public EntityReference SendSmsToUser
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_SendSmsToUser);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_SendSmsToUser, value);
            }
        }
        public string Message
        {
            get => this.GetAttributeValue<string>(PluginResource.TaskStep_Message);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_Message, value);
            }
        }
        public EntityReference CompletedStep
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_CompletedStep);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_CompletedStep, value);
            }
        }
        public EntityReference RejectedStep
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_RejectedStep);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_RejectedStep, value);
            }
        }
        public EntityReference SmsTemplate
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_SmsTemplate);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_SmsTemplate, value);
            }
        }
        public EntityReference UserSmsTemplate
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_UserSmsTemplate);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_UserSmsTemplate, value);
            }
        }
        public int DueDate
        {
            get => this.GetAttributeValue<int>(PluginResource.TaskStep_DueDate);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_DueDate, value);
            }
        }
        public int ProsseccDuration
        {
            get => this.GetAttributeValue<int>(PluginResource.TaskStep_ProsseccDuration);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_ProsseccDuration, value);
            }
        }
        public OptionSetValue RejectStatus
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.TaskStep_RejectStatus);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_RejectStatus, value);
            }
        }
        public OptionSetValue RejectStatusReason
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.TaskStep_RejectStatusReason);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_RejectStatusReason, value);
            }
        }
        public OptionSetValue CompleteStatus
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.TaskStep_CompleteStatus);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_CompleteStatus, value);
            }
        }
        public OptionSetValue CompleteStatusReason
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.TeskStep_CompleteStatusReason);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TeskStep_CompleteStatusReason, value);
            }
        }
        public EntityReference SlaCategory
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskStep_SlaCategory);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskStep_SlaCategory, value);
            }
        }
    }
}
