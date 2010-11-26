using HoplaHelpdesk.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HoplaHelpdesk.Models;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for TagETAMangagerTest and is intended
    ///to contain all TagETAMangagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TagETAMangagerTest
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
        ///A test for ManageTagTimes
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ManageTagTimesTest()
        {
            var Bjørn = new Tag()
                    {
                    SolvedProblems = 5,
                    TimeConsumed = 30
                    };

            Problem problem = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                    Bjørn                                        
                }, Added_date = new DateTime(2000, 1, 1, 11, 30, 30), SolvedAtTime = new DateTime(2000, 1, 2, 11, 40, 30)



            }; // TODO: Initialize to an appropriate value
            TagETAMangager.ManageTagTimes(problem);
            Assert.AreEqual(6, Bjørn.SolvedProblems);
            Assert.AreEqual(1480, Bjørn.TimeConsumed);
        }


       /// <summary>
        ///A test for ManageTagTimes
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ManageTagTimesTest2()
        {
            Problem problem = new Problem()
            {
                
                Added_date = new DateTime(2000, 1, 1, 11, 30, 30), SolvedAtTime = new DateTime(2000, 1, 2, 11, 40, 30)



            }; // TODO: Initialize to an appropriate value
            TagETAMangager.ManageTagTimes(problem);
        }
    }
}