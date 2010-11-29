using HoplaHelpdesk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for DepartmentTest and is intended
    ///to contain all DepartmentTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DepartmentTest
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
        /// Test that it does not throw an exception even tough none is found
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest()
        {

            Department target = new Department()
            {


            };
            target.BalanceWorkload();   
        }



        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest2()
        {
            var tag1 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 1  };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 2  };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 3  };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 4  };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 } };
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 } };
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 } };
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 } };

            var mike = new Person() { Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 30
            var john = new Person() { Worklist = new EntityCollection<Problem>() { prob4 } };               // = 10

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(mike.Worklist.Contains(prob1));
            Assert.IsTrue(mike.Worklist.Contains(prob2));
          
            Assert.IsTrue(john.Worklist.Contains(prob4));
            Assert.IsTrue(john.Worklist.Contains(prob3));
        }

    }

    
}
