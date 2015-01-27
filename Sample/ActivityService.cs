using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Repository;
using SimplifyDDD.Service;
using SimplifyDDD.UnitOfWork;

namespace Sample
{
    public class ActivityService : BaseDomainService
    {
        private readonly MemberService _memberService;
        private readonly IDomainRepository _domainRepository;
        public ActivityService(MemberService memberService)
        {
            _memberService = memberService;
            _domainRepository = UnitOfWork.GetDomainRepository<ISampleDomainRepository>();
            UnitOfWork.Joint(_memberService);
        }

        public Activity GetActivity(string activityId)
        {
            return _domainRepository.GetByKey<Activity>(activityId);
        }

        public void AddActivity()
        {
            var activity = new Activity();
            _domainRepository.Add(activity);
            UnitOfWork.Commit();
        }

        public void JoinActivity(string activityId, string memberId)
        {
            var member = _memberService.GetMember(memberId);
            var activity = GetActivity(activityId);
            activity.Members.Add(member);
            UnitOfWork.Commit();
        }
    }
}
