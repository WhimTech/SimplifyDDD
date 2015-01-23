using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifyDDD.Entity
{
    /// <summary>
    /// 基础模型
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 默认构造器
        /// 初始化标识和创建时间
        /// </summary>
        public BaseModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreateTime = DateTime.Now;
        }
        /// <summary>
        /// 标识（主键）
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
