using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifyDDD.Entity
{
    public class PageModel<T>
    {
        public PageModel()
        {
        }

        public PageModel(PageModel<T> pageModel)
        {
            this.PageCount = pageModel.PageCount;
            this.PageIndex = pageModel.PageIndex;
            this.PageSize = pageModel.PageSize;
            this.TotalCount = pageModel.TotalCount;
            this.Result = pageModel.Result;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long PageCount { get; set; }
        public long TotalCount { get; set; }
        public ICollection<T> Result { get; set; }
    }
}
