using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlHelper.Queryable
{
    public interface INoSqlQueryable<out TEntity> where TEntity : class
    {

        IQueryable<TEntity> Queryable();

    }
}
