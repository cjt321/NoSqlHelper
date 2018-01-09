using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration.Startup;
using NoSqlHelper.Configuration.Config;

namespace NoSqlHelper.Configuration
{
    public static class MoSqlHelperConfigurationExtensions
    {

        public static INoSqlHelperModuleConfiguration AbpMongoDb(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<INoSqlHelperModuleConfiguration>();
        }

    }
}
