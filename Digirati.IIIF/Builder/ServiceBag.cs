using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digirati.IIIF.Model;

namespace Digirati.IIIF.Builder
{
    /// <summary>
    /// Keeps track of services asserted so that the first time you assert the whole object and thereafter just by ID.
    /// </summary>
    public class ServiceBag
    {
        private readonly HashSet<string> loginServicesAsserted = new HashSet<string>();

        /// <summary>
        /// 
        /// These will either be the raw URIs, or objects depending on whether we have already asserted them in the sequence
        /// 
        /// if loginServicesAsserted contains the service ID, return the ID. otherwise return the full service.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public object[] GetServicesToAssert(IService[] services)
        {
            var servicesToAssert = new object[services.Length];
            for (int svcIdx = 0; svcIdx < services.Length; svcIdx++)
            {
                var serviceId = services[svcIdx].Id;
                if (loginServicesAsserted.Contains(serviceId))
                {
                    servicesToAssert[svcIdx] = serviceId;
                }
                else
                {
                    servicesToAssert[svcIdx] = services[svcIdx];
                }
            }
            MarkServicesAsAsserted(services);
            return servicesToAssert;
        }

        private void MarkServicesAsAsserted(IService[] services)
        {
            for (int svcIdx = 0; svcIdx < services.Length; svcIdx++)
            {
                var serviceId = services[svcIdx].Id;
                loginServicesAsserted.Add(serviceId);
            }
        }
    }
}
