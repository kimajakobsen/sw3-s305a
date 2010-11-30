﻿using HoplaHelpdesk.Models;
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
            var tag1 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 1 , Priority = 1  };  //(TimeConsumed / SolvedProblems) = 20
            var tag2 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 2  };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 3  };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 =  new Tag(){ TimeConsumed = 20, SolvedProblems = 2 , Priority = 4  };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };
           
            var mike = new Person() { Name="mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 40
            var john = new Person() { Name= "John", Worklist = new EntityCollection<Problem>() { prob4 } };               // = 10

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(mike.Worklist.Contains(prob1));
            Assert.IsTrue(john.Worklist.Contains(prob2));
            Assert.IsTrue(john.Worklist.Contains(prob4));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
        }

        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void BalanceWorkloadTest3()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 20
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };

            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 30
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob4 } };               // = 10

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(john.Worklist.Contains(prob1));
            Assert.IsTrue(mike.Worklist.Contains(prob2));
            Assert.IsTrue(john.Worklist.Contains(prob4));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
            Assert.AreEqual(mike.Workload, 20);
            Assert.AreEqual(john.Workload, 20);
        }



        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest4()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = true }; /// 10
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 10
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   // 10
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7,tag8 }, Reassignable = true }; // 10

            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 30
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob4, prob5 } };               // = 20

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
            Assert.IsTrue(john.Worklist.Contains(prob5));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
        
        }





        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest5()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7, tag8 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob4, prob5 } };               // = 20

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(john.Worklist.Contains(prob1));
            Assert.IsTrue(mike.Worklist.Contains(prob2));
            Assert.IsTrue(john.Worklist.Contains(prob4));
            Assert.IsTrue(john.Worklist.Contains(prob5));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
        }



        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest6()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = true }; /// 10
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 10
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //10
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7, tag8 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2 } }; // Workload = 10
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob4, prob5 } }; // = 10

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
            Assert.IsTrue(john.Worklist.Contains(prob5));
        }


        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest7()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7, tag8 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3,  prob4, prob5} }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { } };               // = 20

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(john.Worklist.Contains(prob1));
            Assert.IsTrue(john.Worklist.Contains(prob2));
            Assert.IsTrue(mike.Worklist.Contains(prob4));
            Assert.IsTrue(mike.Worklist.Contains(prob5));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
            Assert.AreEqual(mike.Workload, 40);
            Assert.AreEqual(john.Workload, 40);
        }





        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest8()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = false }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable =false };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = false };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = false };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7, tag8 }, Reassignable = false }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3, prob4, prob5 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { } };               // = 20

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
            Assert.IsTrue(mike.Worklist.Contains(prob4));
            Assert.IsTrue(mike.Worklist.Contains(prob5));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
        }

        /// <summary>
        /// only one person
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest9()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = false }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = false };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = false };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = false };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7, tag8 }, Reassignable = false }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3, prob4, prob5 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { } };               // = 20

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(mike.Worklist.Contains(prob1));
            Assert.IsTrue(mike.Worklist.Contains(prob2));
            Assert.IsTrue(mike.Worklist.Contains(prob4));
            Assert.IsTrue(mike.Worklist.Contains(prob5));
            Assert.IsTrue(mike.Worklist.Contains(prob3));
        }



        /// <summary>
        /// All staff has the same workload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest10()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob4} };               // = 20

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
            Assert.IsTrue(john.Worklist.Contains(prob3));
            Assert.IsTrue(john.Worklist.Contains(prob4));
           
        }





        /// <summary>
        /// Tag less problems
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest11()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> {  }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> {  }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> {  }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> {  }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> {  }, Reassignable = true }; // 10

            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob4 } };               // = 20

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
            Assert.IsTrue(john.Worklist.Contains(prob3));
            Assert.IsTrue(john.Worklist.Contains(prob4));

        }


        /// <summary>
        /// Extreme workload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest12()
        {
            var tag1 = new Tag() { TimeConsumed = 2000000, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag5 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob4 } };               // = 20

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(mike.Worklist.Contains(prob1));
            Assert.IsTrue(john.Worklist.Contains(prob2));
            Assert.IsTrue(john.Worklist.Contains(prob3));
            Assert.IsTrue(john.Worklist.Contains(prob4));

        }


        /// <summary>
        /// Extreme workload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest13()
        {
            var tag1 = new Tag() { TimeConsumed = 2000000, SolvedProblems = 1, Priority = 10 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag5 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2 } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob4 } };               // = 20

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue(mike.Worklist.Contains(prob1));
            Assert.IsTrue(john.Worklist.Contains(prob2));
            Assert.IsTrue(john.Worklist.Contains(prob3));
            Assert.IsTrue(john.Worklist.Contains(prob4));

        }

    }

    
}
