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
    public enum TaskStatusReason
    {
        Completed = 5,
        Canceled = 6
    }

    [EntityLogicalName("task")]
    internal class Task : Entity
    {
        public Task()
        {
            this.LogicalName = PluginResource.Task_LogicalName;
        }
        public string Subject
        {
            get => this.GetAttributeValue<string>(PluginResource.Task_Subject);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Subject, value);
            }
        }
        public EntityReference Owner
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Task_Owner);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Owner, value);
            }
        }

        public EntityReference Regarding
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Task_Regarding);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Regarding, value);
            }
        }
        public int Duration
        {
            get => this.GetAttributeValue<int>(PluginResource.Task_Duration);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Duration, value);
            }
        }
        public DateTime CreatedOn
        {
            get => this.GetAttributeValue<DateTime>(PluginResource.CreateOn);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.CreateOn, value);
            }
        }
        public DateTime Deadline
        {
            get => this.GetAttributeValue<DateTime>(PluginResource.Task_Deadline);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Deadline, value);
            }
        }
        public DateTime Deadline1
        {
            get => this.GetAttributeValue<DateTime>(PluginResource.Task_Deadline1);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Deadline1, value);
            }
        }
        public DateTime Deadline2
        {
            get => this.GetAttributeValue<DateTime>(PluginResource.Task_Deadline2);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Deadline2, value);
            }
        }
        public DateTime Deadline3
        {
            get => this.GetAttributeValue<DateTime>(PluginResource.Task_Deadline3);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Deadline3, value);
            }
        }

        public EntityReference TaskStep
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Task_TaskStep);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_TaskStep, value);
            }
        }
        public OptionSetValue StatusReason
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.StatusReason);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.StatusReason, value);
            }
        }
        public OptionSetValue Status
        {
            get => this.GetAttributeValue<OptionSetValue>(PluginResource.Task_Status);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_Status, value);
            }
        }
        public EntityReference SlaCategory
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Task_SlaCategory);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Task_SlaCategory, value);
            }
        }
    }
}
