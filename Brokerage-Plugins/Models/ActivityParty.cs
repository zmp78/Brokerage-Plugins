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
    [EntityLogicalName("activityparty")]
    internal class ActivityParty : Entity
    {
        public ActivityParty()
        {
            this.LogicalName = PluginResource.ActivityParty_LogicalName;
        }

        public EntityReference Customer
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.ActivityParty_PartyId);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.ActivityParty_PartyId, value);
            }
        }
    }
}
