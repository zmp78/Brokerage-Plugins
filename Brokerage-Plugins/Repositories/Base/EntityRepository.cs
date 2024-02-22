using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories.Base
{
    internal class EntityRepository<T> : BaseRepository where T : Entity
    {
        public EntityRepository(IOrganizationService currentService) : base(currentService)
        {
        }

        public override Entity GetEntityById(EntityReference reference)
        {
            return base.GetEntityById(reference).ToEntity<T>();
        }

        public override Entity GetEntityById(EntityReference reference, string[] columns)
        {
            return base.GetEntityById(reference, columns).ToEntity<T>();
        }


    }
}
