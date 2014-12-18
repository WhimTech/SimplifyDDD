using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.UnitOfWork
{
    public class BaseService : IJoinable
    {
        private IUnitOfWork _unitOfWork;
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
        public virtual void Join(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.IsJointed = true;
        }
        public bool IsJointed { get; set; }
    }
}
