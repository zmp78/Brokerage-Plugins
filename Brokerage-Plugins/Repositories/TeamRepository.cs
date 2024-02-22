using Brokerage_Plugins.Helper;
using Brokerage_Plugins.Models;
using Brokerage_Plugins.Repositories.Base;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brokerage_Plugins.Repositories
{
    internal class TeamRepository : PluginRepository<Team>
    {
        public TeamRepository(PluginBase.LocalPluginContext currentService) : base(currentService)
        {
        }

        public bool GetMembersOfTeam(Guid team, Guid currentUser)
        {
            var isMember = false;
            var fetch =
                @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                    <entity name='systemuser'>
                    <attribute name='systemuserid' />
                    <filter type='and'>
                    <condition attribute='isdisabled' operator='ne' value='1' />
                    <condition attribute='systemuserid' operator='eq' uiname='Zahra Moradipour' uitype='systemuser' value='{" + currentUser + @"}' />
                    </filter>
                    <link-entity name='teammembership' from='systemuserid' to='systemuserid' visible='false' intersect='true'>
                    <link-entity name='team' from='teamid' to='teamid' alias='aa'>
                    <filter type='and'>
                    <condition attribute='teamid' operator='eq' uiname='AHD' uitype='team' value='{" + team + @"}' />
                    </filter>
                    </link-entity>
                    </link-entity>
                    </entity>
                    </fetch>";
            var entityCollection = Service.RetrieveMultiple(new FetchExpression(fetch));
            if (entityCollection.Entities.Count > 0)
                isMember = true;

            return isMember;
        }
    }
}
