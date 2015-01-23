using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.Entity
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TKey">主键</typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
        DateTime CreateTime { get; set; }
    }
}
