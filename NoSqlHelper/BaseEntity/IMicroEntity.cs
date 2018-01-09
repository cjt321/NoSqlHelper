using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSqlHelper.BaseEntity
{
    public interface IMicroEntity<TPrimaryKey> //where TPrimaryKey:struct 
    {
        //
        // 摘要:
        //     Unique identifier for this entity.
        TPrimaryKey id { get; set; }

        string BaseDocumentEntityType { get; set; }

        //
        // 摘要:
        //     Checks if this entity is transient (not persisted to database and it has not
        //     an Abp.Domain.Entities.IEntity`1.Id).
        //
        // 返回结果:
        //     True, if this entity is transient
        bool IsTransient();
    }
}