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
        ///A test for GetWorkload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetWorkloadTest()
        {
            Tag Hund = new Tag() { TimeConsumed = 20, SolvedProblems = 1 };
            Problem problem2 = new Problem() 
            {
                
                Tags = new EntityCollection<Tag>()
                {
                    Hund
                }
            };
            var Rasmus = new Person()
            {
                Worklist = new EntityCollection<Problem>()
                {
                    problem2
                }
            };
            double expected = 20; // TODO: Initialize to an appropriate value
            double actual;
            actual = Rasmus.GetWorkload();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetWorkload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void AverageTimePerProblemTest()
        {
            var prob1 = new Problem() { Added_date = new DateTime(2010, 10, 2), SolvedAtTime = new DateTime(2010, 10, 3) };
            var prob2 = new Problem() { Added_date = new DateTime(2010, 10, 2), SolvedAtTime = new DateTime(2010, 10, 3) };
            var prob3 = new Problem() { Added_date = new DateTime(2010, 10, 2), SolvedAtTime = new DateTime(2010, 10, 3) };
            var prob4 = new Problem() { Added_date = new DateTime(2010, 10, 2), SolvedAtTime = new DateTime(2010, 10, 3) };
            var prob5 = new Problem() { Added_date = new DateTime(2010, 10, 2), SolvedAtTime = new DateTime(2010, 10, 3) };
            var target = new Person() { Name = "john", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3, prob4, prob5 } };
            int expected = 10*24*60;
            int actual;
            actual = target.AverageTimePerProblem();
            Assert.AreEqual(expected, actual);
        }




        /// <summary>
        ///A test for GetWorkload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void AverageTimePerProblemLastweekTest()
        {
            DateTime addDate = DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0));
            DateTime solveDate = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0));

            var prob1 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob2 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob3 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob4 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob5 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var target = new Person() { Name = "john", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3, prob4, prob5 } };
            int expected = 24*10*60;
            int actual;
            actual = target.AverageTimePerProblemLastWeek();
            Assert.AreEqual(expected, actual);
        }


        

        /// <summary>
        ///A test for GetWorkload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void AverageTimePerProblemLastweekTest2()
        {
            DateTime addDate = DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0));
            DateTime solveDate = DateTime.Now.Subtract(new TimeSpan(14, 0, 0, 0));

            var prob1 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob2 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob3 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob4 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            var prob5 = new Problem() { Added_date = addDate, SolvedAtTime = solveDate };
            /*
            var prob1 = new Problem() { Added_date = new DateTime(2010, 11, 20), SolvedAtTime = new DateTime(2010, 11, 21) };
            var prob2 = new Problem() { Added_date = new DateTime(2010, 11, 20), SolvedAtTime = new DateTime(2010, 11, 21) };
            var prob3 = new Problem() { Added_date = new DateTime(2010, 11, 20), SolvedAtTime = new DateTime(2010, 11, 21) };
            var prob4 = new Problem() { Added_date = new DateTime(2010, 11, 20), SolvedAtTime = new DateTime(2010, 11, 21) };
            var prob5 = new Problem() { Added_date = new DateTime(2010, 11, 20), SolvedAtTime = new DateTime(2010, 11, 21) };*/
            var target = new Person() { Name = "john", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3, prob4, prob5 } };
            int expected = 0;
            int actual;
            actual = target.AverageTimePerProblemLastWeek();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for GetWorkload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void AverageTimePerProblemTes2()
        {
            var target = new Person() { Name = "john", Worklist = new EntityCollection<Problem>() {} };
            int expected = 0;
            int actual;
            actual = target.AverageTimePerProblem();
            Assert.AreEqual(expected, actual);
        }


    }
}
