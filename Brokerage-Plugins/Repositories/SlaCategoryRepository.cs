using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories
{
    internal class SlaCategoryRepository : PluginRepository<SlaCategory>
    {
        public SlaCategoryRepository(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }
    }
}
