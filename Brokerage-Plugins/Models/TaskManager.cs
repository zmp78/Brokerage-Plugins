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
    [EntityLogicalName("frb_taskmanager")]
    internal class TaskManager : Entity
    {
        public TaskManager()
        {
            this.LogicalName = PluginResource.TaskManager_LogicalName;
        }
        public EntityReference CaseCategory
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskManager_CaseCategory);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskManager_CaseCategory, value);
            }
        }
        public EntityReference CaseSubCategory
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskManager_CaseSubCategory);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskManager_CaseSubCategory, value);
            }
        }
        public EntityReference FirstStep
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.TaskManager_FirstStep);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.TaskManager_FirstStep, value);
            }
        }
    }
}
