using Brokerage_Plugins.Helper;
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
    internal class TaskRepository : PluginRepository<Models.Task>
    {
        public TaskRepository(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }

        public Models.Task GetTask(EntityReference reference)
        {

            var columnSet = new string[]
            {
                //PluginResource.Task_Deadline,
                PluginResource.Task_Status,
                PluginResource.Task_Owner
            };
            return base.GetEntityById(reference, columnSet).ToEntity<Models.Task>();
        }
    }
}
