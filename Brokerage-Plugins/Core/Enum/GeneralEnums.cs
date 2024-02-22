using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Core.Enum
{
    internal class GeneralEnums
    {
        public enum PluginStage
        {
            PreValidation = 10,
            PreOperation = 20,
            PostOperation = 40
        }

        public enum PluginMessageName
        {
            Create = 1,
            Update = 2
        }
    }
}
