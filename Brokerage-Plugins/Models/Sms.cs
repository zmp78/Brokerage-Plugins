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
    [EntityLogicalName("frb_sms")]
    internal class Sms : Entity
    {
        public Sms()
        {
            this.LogicalName = PluginResource.Sms_LogicalName;
        }


        public string Description
        {
            get => this.GetAttributeValue<string>(PluginResource.Sms_Description);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Sms_Description, value);
            }
        }
        public string Subject
        {
            get => this.GetAttributeValue<string>(PluginResource.Sms_Subject);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Sms_Subject, value);
            }
        }

        public EntityReference Regarding
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Sms_Regarding);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Sms_Regarding, value);
            }
        }
        public EntityReference SmsTemplate
        {
            get => this.GetAttributeValue<EntityReference>(PluginResource.Sms_SmsTemplate);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.Sms_SmsTemplate, value);
            }
        }
 // look how a property is implemented for an activity party field:
        public EntityReference To
        {
            get => this.GetAttributeValue<EntityCollection>(PluginResource.SMS_To).Entities.FirstOrDefault()?.ToEntity<ActivityParty>()?.Customer;
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.SMS_To,
                    new EntityCollection()
                    {
                        Entities =
                        {
                            new ActivityParty()
                            {
                                Customer = value
                            }
                        }
                    });
            }
        }
    }
}
