using System;
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
            SimplifyDDDConfiguration.Instance.RegisterPersistence();
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
            var pageActivities =
                domainRepository.FindAll<Activity>().ToList().Page(1, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SimplifyDDDConfiguration.Instance.RegisterLogging();
            var logger = IoCFactory.Resolve<ILogger>();
            logger.Debug("test");
        }
    }
}
