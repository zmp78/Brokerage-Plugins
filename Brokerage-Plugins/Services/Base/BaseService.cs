using Brokerage_Plugins.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Services.Base
{
    internal class BaseService
    {
        public PluginBase.LocalPluginContext Context;
        public BaseService(PluginBase.LocalPluginContext currentService)
        {
            Context = currentService;
        }
    }
}
