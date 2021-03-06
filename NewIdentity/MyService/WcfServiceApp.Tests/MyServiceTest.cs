// <copyright file="MyServiceTest.cs" company="Cognizant">Copyright © Cognizant 2018</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfServiceApp;

namespace WcfServiceApp.Tests
{
    /// <summary>This class contains parameterized unit tests for MyService</summary>
    [PexClass(typeof(MyService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MyServiceTest
    {
        /// <summary>Test stub for GetAllProducts()</summary>
        [PexMethod(MaxBranches = 20000)]
        public List<Product> GetAllProductsTest([PexAssumeUnderTest]MyService target)
        {
            List<Product> result = target.GetAllProducts();
            //return result;
            Assert.IsTrue(result.Count > 1);
            //Assert.AreEqual(a[0], 5);
            // TODO: add assertions to method MyServiceTest.GetAllProductsTest(MyService)
            Assert.AreEqual(result.Count > 1, true);
            return result;
        }
    }
}
