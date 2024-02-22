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
    internal class CaseRepository : PluginRepository<Case>
    {
        public CaseRepository(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }
        public Case GetCase(EntityReference reference)
        {
            var columnSet = new string[]
            {
                PluginResource.Case_Owner,
                PluginResource.Case_Customer
            };
            return base.GetEntityById(reference, columnSet).ToEntity<Case>();
        }
    }
}
