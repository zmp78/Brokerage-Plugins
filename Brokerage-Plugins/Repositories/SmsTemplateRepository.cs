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
    internal class SmsTemplateRepository : BaseRepository
    {
        public SmsTemplateRepository(IOrganizationService currentService) : base(currentService)
        {
        }
        public SmsTemplate GetSmsTemplate(EntityReference reference)
        {
            var columnSet = new string[]
            {
                PluginResource.SmsTemplates_Text,
                PluginResource.SmsTemplates_Name
            };
            return base.GetEntityById(reference, columnSet).ToEntity<SmsTemplate>();
        }
    }
}
