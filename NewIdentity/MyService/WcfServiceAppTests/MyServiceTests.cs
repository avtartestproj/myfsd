using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WcfServiceAppTests.MyServiceClient;

namespace WcfServiceApp.Tests
{
    [TestClass()]
    public class MyServiceTests
    {
        [TestMethod()]
        public void GetAllProductsTest()
        {
            Assert.Fail();
        }

        private static ServiceHost myServiceHost_;

        [ClassInitialize]
        public static void InitializeClass(TestContext ctx)
        {
            MyServiceTests.myServiceHost_ =
                new ServiceHost(typeof(MyService));
            MyServiceTests.myServiceHost_.Open();
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            MyServiceTests.myServiceHost_.Close();
        }

        [TestMethod()]
        public void InvokeServiceOperation()
        {
            using (MyServiceClient proxy = new MyServiceClient())
            {
                Product[] Prods = proxy.GetAllProducts();

                Assert.IsNotNull(Prods);
            }
        }
    }
}