using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.UnitOfWork
{
    /// <summary>
    /// 可联合的工作
    /// </summary>
    public interface IJoinableWork
    {
        /// <summary>
        /// 加入工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        void Join(IUnitOfWork unitOfWork);

        /// <summary>
        /// 是否已经加入了某个工作单元
        /// </summary>
        bool IsJointed { get; }

        /// <summary>
        /// 工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
