using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplifyDDD.Entity;

namespace SimplifyDDD.Extension
{
    /// <summary>
    /// 分页扩展
    /// </summary>
    public static class PaginationExtension
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">类型实体</typeparam>
        /// <param name="input">输入</param>
        /// <param name="pageIndex">页码（从1开始）</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>分页对象</returns>
        public static PageModel<T> Page<T>(this IOrderedQueryable<T> input, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
                throw new ArgumentException("InvalidPageIndex");

            if (pageSize <= 0)
                throw new ArgumentException("InvalidPageSize");

            var pageModel = new PageModel<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = input.Count(),
                Result = input.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };
            pageModel.PageCount = (int)Math.Ceiling((decimal)pageModel.TotalCount / pageModel.PageSize);
            return pageModel;
        }
        
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">类型实体</typeparam>
        /// <param name="input">输入</param>
        /// <param name="pageIndex">页码（从1开始）</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>分页对象</returns>
        public static PageModel<T> Page<T>(this ICollection<T> input, int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
                throw new ArgumentException("InvalidPageIndex");

            if (pageSize <= 0)
                throw new ArgumentException("InvalidPageSize");

            var pageModel = new PageModel<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = input.Count(),
                Result = input.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };
            return pageModel;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">类型实体</typeparam>
        /// <param name="input">输入</param>
        /// <param name="pageIndex">页码（从1开始）</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>分页对象</returns>
        public static PageModel<T> Page<T>(this IOrderedEnumerable<T> input, int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
                throw new ArgumentException("InvalidPageIndex");

            if (pageSize <= 0)
                throw new ArgumentException("InvalidPageSize");

            var pageModel = new PageModel<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = input.Count(),
                Result = input.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
            };
            return pageModel;
        }
    }
}
