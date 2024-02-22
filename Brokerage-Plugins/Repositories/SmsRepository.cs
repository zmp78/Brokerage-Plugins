using Brokerage_Plugins.Repositories.Base;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories
{
    internal class SmsRepository : BaseRepository
    {
        public SmsRepository(IOrganizationService currentService) : base(currentService)
        {
        }
    }
}
