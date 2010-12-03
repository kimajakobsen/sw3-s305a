using HoplaHelpdesk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Objects.DataClasses;
namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for CategoryTest and is intended
    ///to contain all CategoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CategoryTest
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
        ///A test for Hidden
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void HiddenTest()
        {
            var tags = new EntityCollection<Tag>(){
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true}
            };
            Category target = new Category()
            {
                Department = new Department
                {
                    Persons = new EntityCollection<Person>
                    {
                        new Person()
                    }
                },
                Tags=tags
            };// TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Hidden = expected;
            actual = target.Hidden;
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for Hidden
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void HiddenTest2()
        {
            var tags = new EntityCollection<Tag>(){
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = false},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true}
            };
            Category target = new Category()
            {
                Department = new Department
                {
                    Persons = new EntityCollection<Person>
                    {
                        new Person()
                    }
                },
                Tags = tags
            };// TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
           // target.Hidden = expected;
            actual = target.Hidden;
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Hidden
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void HiddenTest3()
        {
            var tags = new EntityCollection<Tag>(){
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true}
            };
            Category target = new Category()
            {
                Department = new Department
                {
                    Persons = new EntityCollection<Person>
                    {
                        new Person()
                    }
                },
                Tags = tags
            };// TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            // target.Hidden = expected;
            actual = target.Hidden;
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Hidden
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void HiddenTest4()
        {
            var tags = new EntityCollection<Tag>(){
                new Tag(){ Hidden = false},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true}
            };
            Category target = new Category()
            {
                Department = new Department
                {
                    Persons = new EntityCollection<Person>
                    {
                        new Person()
                    }
                },
                Tags = tags
            };// TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            target.Hidden = expected;
            actual = target.Hidden;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for Hidden
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void HiddenTest5()
        {
            var tags = new EntityCollection<Tag>(){
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true}
            };
            Category target = new Category()
            {

                
            };// TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            target.Hidden = false;
            actual = target.Hidden;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for Hidden
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void HiddenTest6()
        {
            var tags = new EntityCollection<Tag>(){
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true},
                new Tag(){ Hidden = true}
            };
            Category target = new Category()
            {

            
            };// TODO: Initialize to an appropriate value
            bool expected = true; // TODO: Initialize to an appropriate value
            bool actual;
            // target.Hidden = expected;
            actual = target.Hidden;
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }


    }
}
