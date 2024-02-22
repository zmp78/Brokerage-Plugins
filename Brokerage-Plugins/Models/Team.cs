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
    [EntityLogicalName("team")]
    internal class Team : Entity
    {
        public Team()
        {
            this.LogicalName = PluginResource.Team_LogicalName;
        }
    }
}
