using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlHelper.Queryable
{
    public interface INoSqlOrderQueryable<out TEntity> where TEntity:class
    {

        IOrderedQueryable<TEntity> OrderedQueryable();

    }
}
