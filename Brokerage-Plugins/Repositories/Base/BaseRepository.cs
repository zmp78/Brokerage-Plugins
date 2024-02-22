using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories.Base
{
    internal class BaseRepository
    {
        public IOrganizationService Service;
        public OrganizationServiceContext ServiceContext;

        public BaseRepository(IOrganizationService currentService)
        {
            Service = currentService;
            ServiceContext = new OrganizationServiceContext(Service);
        }

        public virtual Entity GetEntityById(EntityReference reference)
        {
            var columnSet = new ColumnSet(true);
            var entity = Service.Retrieve(reference.LogicalName, reference.Id, columnSet);
            return entity;
        }

        public virtual Entity GetEntityById(EntityReference reference, string[] columns)
        {
            var columnSet = new ColumnSet(columns);
            var entity = Service.Retrieve(reference.LogicalName, reference.Id, columnSet);
            return entity;
        }

        public virtual EntityCollection GetEntityCollectionByFetch(string fetch)
        {
            var entityCollection = Service.RetrieveMultiple(new FetchExpression(fetch));
            return entityCollection;
        }

        public virtual Guid CreateEntity(Entity entity)
        {
            var entityId = Service.Create(entity);
            return entityId;
        }

        public virtual void UpdateEntity(Entity entity)
        {
            Service.Update(entity);
        }

        public virtual void SetState(EntityReference reference, OptionSetValue state, OptionSetValue status)
        {
            var setStateRequest = new SetStateRequest()
            {
                EntityMoniker = reference,
                State = state,
                Status = status
            };
            Service.Execute(setStateRequest);
        }
    }
}
