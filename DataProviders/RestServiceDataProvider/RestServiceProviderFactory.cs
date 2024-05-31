using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateReader.DataProviders.RestServiceDataProvider
{
    public class RestServiceProviderFactory : DataProviderFactory
    {
        public UrlConfig UrlConfig;

        public RestServiceProviderFactory(UrlConfig urlConfig)
        {
            UrlConfig = urlConfig;
        }

        public override IDataProvider CreateProvider()
        {
            return new RestServiceProvider(UrlConfig);
        }
    }
}
