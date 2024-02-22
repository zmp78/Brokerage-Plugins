
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Repositories.Resources;

namespace Brokerage_Plugins.Repositories.Base
{
    internal class PluginRepository<T> : EntityRepository<T> where T : Entity
    {
        private PluginBase.LocalPluginContext _context;
        public PluginRepository(PluginBase.LocalPluginContext currentService) : base(currentService.OrganizationService)
        {
            _context = currentService;
        }

        public virtual T CreateInstance()
        {
            T typedEntity = default(T);
            if (_context.PluginExecutionContext.InputParameters.Contains(PluginResource.Target) &&
                _context.PluginExecutionContext.InputParameters[PluginResource.Target] is Entity)
            {
                var entity = (Entity)_context.PluginExecutionContext.InputParameters[PluginResource.Target];
                typedEntity = entity.ToEntity<T>();
            }

            return typedEntity;
        }

        public virtual T CreateInstancepPreImage()
        {
            T typedEntity = default(T);
            EntityLogicalNameAttribute logicalNameAttribute =
                (EntityLogicalNameAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(EntityLogicalNameAttribute));
            if (_context.PluginExecutionContext.PreEntityImages.Contains(logicalNameAttribute.LogicalName) &&
                _context.PluginExecutionContext.PreEntityImages[logicalNameAttribute.LogicalName] is Entity)
            {
                var entity = (Entity)_context.PluginExecutionContext.PreEntityImages[logicalNameAttribute.LogicalName];
                typedEntity = entity.ToEntity<T>();
            }

            return typedEntity;
        }

        public virtual T CreateInstanceForCustomAction(string[] columns = null)
        {
            var columnSet = columns == null ? new ColumnSet(true) : new ColumnSet(columns);
            T typedEntity = default(T);

            if (_context.PluginExecutionContext.InputParameters.Contains(PluginResource.Target) &&
                _context.PluginExecutionContext.InputParameters[PluginResource.Target] is EntityReference)
            {
                var entityRef = (EntityReference)_context.PluginExecutionContext.InputParameters[PluginResource.Target];
                typedEntity = _context.OrganizationService.Retrieve(entityRef.LogicalName, entityRef.Id, columnSet).ToEntity<T>();
            }
            return typedEntity;
        }
    }

}
