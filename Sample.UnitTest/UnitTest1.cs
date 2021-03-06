﻿using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Persistence;
using SimplifyDDD;
using SimplifyDDD.Config;
using SimplifyDDD.EntityFramework;
using SimplifyDDD.EntLibLogging;
using SimplifyDDD.Extension;
using SimplifyDDD.Logging;
using SimplifyDDD.UnitOfWork;
using Microsoft.Practices.Unity;

namespace Sample.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SimplifyDDDConfiguration.Instance.RegisterEntityFramework();
            IoCFactory.Instance.CurrentContainer.RegisterType<DbContext, SampleDbContext>();
            var unitOfWork = IoCFactory.Resolve<IUnitOfWork>();
            var domainRepository = unitOfWork.GetDomainRepository();
            for (int i = 0; i < 10; i++)
            {
                var activity = new Activity();
                domainRepository.Add(activity);
            }
            unitOfWork.Commit();
            long count = 0;
            var pageActivities = domainRepository.FindAll<Activity>().ToList().Page(1, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SimplifyDDDConfiguration.Instance.RegisterEntLibLogging();
            var logFactory = IoCFactory.Resolve<ILoggerFactory>();
            var logger = logFactory.Create();
            logger.Debug("test");
        }

        [TestMethod]
        public void JoinableTest()
        {
            SimplifyDDDConfiguration.Instance.RegisterEntityFramework();
            IoCFactory.Instance.CurrentContainer.RegisterType<DbContext, SampleDbContext>();
            IoCFactory.Instance.CurrentContainer.RegisterType<ISampleDomainRepository, SampleDomainRespository>();
            var activityService = IoCFactory.Resolve<ActivityService>();
            var memberService = IoCFactory.Resolve<MemberService>();
            var activity = new Activity();
            var member = new Member();
            activityService.AddActivity(activity);
            activityService.AddActivityMember(activity.Id,member);
        }

    }
}
