using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.Service
{
    /// <summary>
    /// 领域服务基类型
    /// </summary>
    public class BaseDomainService : IDomainService
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = IoCFactory.Resolve<IUnitOfWork>();
                }
                return _unitOfWork;
            }
        }

        public virtual IDomainRepository DomainRepository
        {
            get { return UnitOfWork.GetDomainRepository(); }
        }

        /// <summary>
        /// 加入工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public virtual void Join(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.IsJointed = true;
        }

        /// <summary>
        /// 是否已经加入了某个工作单元
        /// </summary>
        public bool IsJointed { get; set; }
    }
}
