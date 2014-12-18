using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplifyDDD.Entity;

namespace SimplifyDDD.Extension
{
    public static class PageExtension
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="pageIndex">页码（从0开始）</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PageModel<T> Page<T>(this IOrderedQueryable<T> input, int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
                throw new ArgumentException("InvalidPageIndex");

            if (pageSize <= 0)
                throw new ArgumentException("InvalidPageSize");
            var pageModel = new PageModel<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            pageModel.Result = input.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            pageModel.TotalCount = input.Count();
            pageModel.PageCount = (int)Math.Ceiling((decimal)pageModel.TotalCount / pageModel.PageSize);
            return pageModel;
        }
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
                Result = input.Skip(pageIndex * pageSize).Take(pageSize).ToList()
            };
            return pageModel;
        }
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
                Result = input.Skip(pageIndex * pageSize).Take(pageSize).ToList()
            };
            return pageModel;
        }
    }
}
