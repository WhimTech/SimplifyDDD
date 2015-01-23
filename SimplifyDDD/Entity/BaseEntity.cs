using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.Entity
{
    /// <summary>
    /// 实体基类型（字符串类型主键）
    /// </summary>
    public class BaseEntity : BaseModel, IEntity<string>
    {
    }
}
