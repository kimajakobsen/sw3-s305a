using HoplaHelpdesk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for PersonTest and is intended
    ///to contain all PersonTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Person Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lasse\\Documents\\Visual Studio 2010\\Projects\\HoplaHelpdesk\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void PersonConstructorTest()
        {
            Person target = new Person();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreatePerson
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lasse\\Documents\\Visual Studio 2010\\Projects\\HoplaHelpdesk\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void CreatePersonTest()
        {
            int id = 0; // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            Person expected = null; // TODO: Initialize to an appropriate value
            Person actual;
            actual = Person.CreatePerson(id, name, email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetWorkload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetWorkloadTest()
        {
          //  Tag Bjørn = new Tag() { AverageTimeSpent = 60 };
          //  Tag Hund = new Tag() { AverageTimeSpent = 120 };
          //  Tag Kat = new Tag() { AverageTimeSpent = 180 };

            Problem problem1 = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                //    Bjørn, Kat
                }

            };
            Problem problem2 = new Problem() 
            {
                Tags = new EntityCollection<Tag>()
                {
                 //   Hund
                }
            };
            var Rasmus = new Person()
            {
                Problems = new EntityCollection<Problem>()
                {
                    problem1, problem2
                }
            };
            double expected = 120; // TODO: Initialize to an appropriate value
            double actual;
            actual = Rasmus.GetWorkload();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsStaff
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Lasse\\Documents\\Visual Studio 2010\\Projects\\HoplaHelpdesk\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void IsStaffTest()
        {
            Person target = new Person(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsStaff();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
