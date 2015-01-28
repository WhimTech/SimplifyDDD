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

        public override IDomainRepository DomainRepository
        {
            get
            {
                return UnitOfWork.GetDomainRepository<ISampleDomainRepository>();
            }
        }

        public ActivityService(MemberService memberService)
        {
            _memberService = memberService;
            UnitOfWork.Joint(_memberService);
        }

        public Activity GetActivity(string activityId)
        {
            return DomainRepository.GetByKey<Activity>(activityId);
        }

        public void AddActivity(Activity activity)
        {
            DomainRepository.Add(activity);
            UnitOfWork.Commit();
        }

        public void JoinActiviyNotCommit(string activityId, string memberId)
        {
            var member = _memberService.GetMember(memberId);
            var activity = GetActivity(activityId);
            activity.Members.Add(member);
        }

        public void JoinActivity(string activityId, string memberId)
        {
            JoinActiviyNotCommit(activityId, memberId);
            UnitOfWork.Commit();
        }

        public void AddActivityMember(string activityId,Member member)
        {
            _memberService.AddMember(member);
            JoinActiviyNotCommit(activityId, member.Id);
            UnitOfWork.Commit();
        }
    }
}
