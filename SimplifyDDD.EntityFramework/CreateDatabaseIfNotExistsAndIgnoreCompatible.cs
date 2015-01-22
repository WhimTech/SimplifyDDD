using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SimplifyDDD.EntityFramework
{
    /// <summary>
    /// 当数据库不存在时创建数据库，同时忽略上下文兼容性检查
    /// </summary>
    public class CreateDatabaseIfNotExistsAndIgnoreCompatible<TContext> : IDatabaseInitializer<TContext>
        where TContext : DbContext
    {
        public virtual void InitializeDatabase(TContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
                Seed(context);
                context.SaveChanges();
            }
        }

        protected virtual void Seed(TContext context)
        {
        }
    }
}
