using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifyDDD.Entity
{
    /// <summary>
    /// 分页模型
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class PageModel<T>
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PageModel()
        {
        }

        /// <summary>
        /// 复制构造函数
        /// </summary>
        /// <param name="pageModel">分页模型对象</param>
        public PageModel(PageModel<T> pageModel)
        {
            this.PageCount = pageModel.PageCount;
            this.PageIndex = pageModel.PageIndex;
            this.PageSize = pageModel.PageSize;
            this.TotalCount = pageModel.TotalCount;
            this.Result = pageModel.Result;
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 条目总数
        /// </summary>
        public long TotalCount { get; set; }

        /// <summary>
        /// 分页实体对象列表
        /// </summary>
        public ICollection<T> Result { get; set; }
    }
}
