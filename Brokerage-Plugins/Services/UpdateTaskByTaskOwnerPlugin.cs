using Brokerage_Plugins.Helper;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Brokerage_Plugins.Services
{
    internal class UpdateTaskByTaskOwnerPlugin : PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTaskByTaskOwnerPlugin"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public UpdateTaskByTaskOwnerPlugin(string unsecure, string secure)
            : base(typeof(UpdateTaskByTaskOwnerPlugin))
        {

            // TODO: Implement your custom configuration handling.
        }


        /// <summary>
        /// Main entry point for he business logic that the plug-in is to execute.
        /// </summary>
        /// <param name="localContext">The <see cref="PluginBase.LocalPluginContext"/> which contains the
        /// <see cref="IPluginExecutionContext"/>,
        /// <see cref="IOrganizationService"/>
        /// and <see cref="ITracingService"/>
        /// </param>
        /// <remarks>
        /// For improved performance, Microsoft Dynamics 365 caches plug-in instances.
        /// The plug-in's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the plug-in. Also, multiple system threads
        /// could execute the plug-in at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in plug-ins.
        /// </remarks>
        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException("localContext");

            }
            var taskService = new TaskService(localContext);
            taskService.UpdateTaskByOwner();
            // TODO: Implement your custom Plug-in business logic.
        }
    }
}
