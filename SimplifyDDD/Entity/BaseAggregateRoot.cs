using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.Entity
{
    /// <summary>
    /// 聚合根基类型（字符串类型主键）
    /// </summary>
    public class BaseAggregateRoot : BaseModel, IAggregateRoot<string>
    {
    }
}
