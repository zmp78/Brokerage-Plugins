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
    [EntityLogicalName("frb_smstemplate")]
    internal class SmsTemplate : Entity
    {
        public SmsTemplate()
        {
            this.LogicalName = PluginResource.SmsTemplates_LogicalName;
        }
        public string Text
        {
            get => this.GetAttributeValue<string>(PluginResource.SmsTemplates_Text);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.SmsTemplates_Text, value);
            }
        }
        public string Name
        {
            get => this.GetAttributeValue<string>(PluginResource.SmsTemplates_Name);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.SmsTemplates_Name, value);
            }
        }
    }
}
