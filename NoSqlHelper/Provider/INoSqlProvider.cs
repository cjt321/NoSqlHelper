using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace NoSqlHelper.Provider
{
    public interface INoSqlProvider<out TDatabase>
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        TDatabase Database { get; }

    }
}
