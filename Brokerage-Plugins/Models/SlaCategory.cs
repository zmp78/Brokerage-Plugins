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
    [EntityLogicalName("frb_slacategory")]
    internal class SlaCategory : Entity
    {
        public SlaCategory()
        {
            this.LogicalName = PluginResource.SlaCategory_LogicalName;
        }
        public decimal Duration1
        {
            get => this.GetAttributeValue<decimal>(PluginResource.SlaCategory_Duration1);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.SlaCategory_Duration1, value);
            }
        }
        public decimal Duration2
        {
            get => this.GetAttributeValue<decimal>(PluginResource.SlaCategory_Duration2);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.SlaCategory_Duration2, value);
            }
        }
        public decimal Duration3
        {
            get => this.GetAttributeValue<decimal>(PluginResource.SlaCategory_Duration3);
            set
            {
                if (value != null) this.SetAttributeValue(PluginResource.SlaCategory_Duration3, value);
            }
        }
        public bool Activation1
        {
            get => this.GetAttributeValue<bool>(PluginResource.SlaCategory_Activation1);
            set => this.SetAttributeValue(PluginResource.SlaCategory_Activation1, value);
        }
        public bool Activation2
        {
            get => this.GetAttributeValue<bool>(PluginResource.SlaCategory_Activation2);
            set => this.SetAttributeValue(PluginResource.SlaCategory_Activation2, value);
        }
        public bool Activation3
        {
            get => this.GetAttributeValue<bool>(PluginResource.SlaCategory_Activation3);
            set => this.SetAttributeValue(PluginResource.SlaCategory_Activation3, value);
        }
    }
}
