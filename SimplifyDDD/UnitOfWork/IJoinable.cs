using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyDDD.UnitOfWork
{
    public interface IJoinable
    {
        void Join(IUnitOfWork unitOfWork);
        bool IsJointed { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
