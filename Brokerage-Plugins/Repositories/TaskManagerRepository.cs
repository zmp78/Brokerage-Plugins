using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories.Base;
using Brokerage_Plugins.Repositories.Resources;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories
{
    internal class TaskManagerRepository : PluginRepository<TaskManager>
    {
        public TaskManagerRepository(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }

        public TaskManager GetTaskManagerFromCaseCategory(Guid caseCategoryId, Guid caseSubCategoryId)
        {

            var columnSet = new ColumnSet(new string[]
            {
                PluginResource.TaskManager_FirstStep
            });
            var query = new QueryExpression(PluginResource.TaskManager_LogicalName)
            {
                ColumnSet = columnSet,
            };

            if (caseSubCategoryId == Guid.Empty && caseCategoryId == Guid.Empty)
                return null;

            if (caseCategoryId != Guid.Empty)
            {
                query = new QueryExpression(PluginResource.TaskManager_LogicalName)
                {
                    ColumnSet = columnSet,
                    Criteria = new FilterExpression(LogicalOperator.And)
                    {
                        Conditions =
                        {
                            new ConditionExpression(PluginResource.TaskManager_CaseCategory,ConditionOperator.Equal,caseCategoryId),
                        }
                    }
                };
            }

            if (caseSubCategoryId != Guid.Empty)
            {
                query.Criteria.Conditions.Add(new ConditionExpression(PluginResource.TaskManager_CaseSubCategory, ConditionOperator.Equal, caseSubCategoryId));
                //var link = new LinkEntity()
                //{
                //    LinkFromEntityName = PluginResource.TaskManager_LogicalName,
                //    LinkToEntityName = PluginResource.CaseSubCategory_LogicalName,
                //    LinkFromAttributeName = PluginResource.TaskManager_Id,
                //    LinkToAttributeName = PluginResource.CaseSubCategory_LinkId,
                //    LinkCriteria =
                //    {
                //        Conditions =
                //        {
                //            new ConditionExpression(PluginResource.CaseSubCategory_Id,ConditionOperator.Equal,caseSubCategoryId),
                //        }
                //    }
                //};
                //query.LinkEntities.Add(link);
                //var caseSubCategory = new CaseSubCategoryRepository().GetCaseSubCategoryBasedOnTaskManager();
                //return caseSubCategory;
            }
            var entityCollection = Service.RetrieveMultiple(query);
            if (entityCollection.Entities.Count > 0)
            {
                var taskManager = entityCollection.Entities.FirstOrDefault()?.ToEntity<TaskManager>();
                return taskManager;
            }
            return null;
        }

        public TaskManager GetTaskManagerFromCaseCategoryAndSubCategory(Guid caseCategoryId, Guid caseSubCategoryId)
        {

            var columnSet = new ColumnSet(new string[]
            {
                PluginResource.TaskManager_FirstStep
            });
            var query = new QueryExpression(PluginResource.TaskManager_LogicalName)
            {
                ColumnSet = columnSet,
            };

            if (caseSubCategoryId == Guid.Empty && caseCategoryId == Guid.Empty)
                return null;

            if (caseCategoryId != Guid.Empty)
            {
                query = new QueryExpression(PluginResource.TaskManager_LogicalName)
                {
                    ColumnSet = columnSet,
                    Criteria = new FilterExpression(LogicalOperator.And)
                    {
                        Conditions =
                        {
                            new ConditionExpression(PluginResource.TaskManager_CaseCategory,ConditionOperator.Equal,caseCategoryId),
                        }
                    }
                };
            }

            if (caseSubCategoryId != Guid.Empty)
            {
                var link = new LinkEntity()
                {
                    LinkFromEntityName = PluginResource.TaskManager_LogicalName,
                    LinkToEntityName = PluginResource.CaseSubCategory_LogicalName,
                    LinkFromAttributeName = PluginResource.TaskManager_Id,
                    LinkToAttributeName = PluginResource.CaseSubCategory_LinkId,
                    LinkCriteria =
                    {
                        Conditions =
                        {
                            new ConditionExpression(PluginResource.CaseSubCategory_Id,ConditionOperator.Equal,caseSubCategoryId),
                        }
                    }
                };
                query.LinkEntities.Add(link);
            }
            var entityCollection = Service.RetrieveMultiple(query);
            if (entityCollection.Entities.Count > 0)
            {
                var taskManager = entityCollection.Entities.FirstOrDefault()?.ToEntity<TaskManager>();
                return taskManager;
            }
            return null;
        }
    }
}
