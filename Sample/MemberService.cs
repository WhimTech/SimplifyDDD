using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Repository;
using SimplifyDDD.Service;

namespace Sample
{
    public class MemberService : BaseDomainService
    {
        private readonly IDomainRepository _domainRepository;

        public MemberService()
        {
            _domainRepository = UnitOfWork.GetDomainRepository<ISampleDomainRepository>();
        }

        public Member GetMember(string memberId)
        {
            return _domainRepository.GetByKey<Member>(memberId);
        }

        public void AddMember()
        {
            var member = new Member();
            _domainRepository.Add(member);
            UnitOfWork.Commit();
        }
    }
}
