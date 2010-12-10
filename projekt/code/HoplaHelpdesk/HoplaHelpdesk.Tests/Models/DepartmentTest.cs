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

        

        #region Two Person test

        [TestMethod()]
        public void FutureImplementationBalanceWorkloadTestBlackBox1()
        {
            var tag1 = new Tag() { TimeConsumed = 100, SolvedProblems = 1, Priority = 10 };
            var tag2 = new Tag() { TimeConsumed = 500, SolvedProblems = 1, Priority = 9 };
            var tag3 = new Tag() { TimeConsumed = 5, SolvedProblems = 1, Priority = 8 };
            var tag4 = new Tag() { TimeConsumed = 5, SolvedProblems = 1, Priority = 7 };

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true, Description = "prob1" }; 
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true, Description = "prob2" }; 
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true, Description = "prob3" };  
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true, Description = "prob4" };

            var aaaa = new Person() { Name = "aaaa", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3, prob4 } };
            var bbbb = new Person() { Name = "bbbb", Worklist = new EntityCollection<Problem>()  };               

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    aaaa, bbbb
                }
            };

            target.FutureImplementationBalanceWorkload();

            Assert.IsTrue(prob1.AssignedTo == aaaa);
            Assert.IsTrue(prob2.AssignedTo == bbbb);
            Assert.IsTrue(prob3.AssignedTo == aaaa);
            Assert.IsTrue(prob4.AssignedTo == aaaa);

        }


        [TestMethod()]
        public void BalanceWorkloadTestBlackBox1()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 20
            var tag2 = new Tag() { TimeConsumed = 10, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 10, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 10, SolvedProblems = 1, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 10
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //10
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10

            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 40
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob4 } };               // = 10

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();
            Assert.IsTrue((john.Workload == 30 && mike.Workload == 20) || (john.Workload == 20 && mike.Workload == 30));
        }



        /// <summary>
        /// In this test we test that the tags will be moved around currectly.
        /// Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
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
            Assert.IsTrue((john.Workload == 30 && mike.Workload == 20) || (john.Workload == 20 && mike.Workload == 30));
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
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 20

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag5 }, Reassignable = true }; // 10

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
            Assert.AreEqual(40, john.Workload);
            Assert.AreEqual(40, mike.Workload);
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
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 20
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 200000
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            //var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag5 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2 } }; // Workload = 9999
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob4 } };               // = 30

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

        public void BalanceWorkloadTest14()
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

        public void BalanceWorkloadTest15()
        {
            var tag1 = new Tag() { TimeConsumed = 2000000, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 2000000
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 20
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true, SolvedAtTime = new DateTime() }; /// 200000
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { } }; //Workload = 0
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob1, prob4, prob2 } }; //Workload = 50

            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john
                }
            };
            target.BalanceWorkload();


            Assert.IsTrue(john.Worklist.Contains(prob1));
            Assert.IsTrue((john.Workload == 30 && mike.Workload == 20) || (john.Workload == 20 && mike.Workload == 30));
        }



        /// <summary>
        /// Extreme workload
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest16()
        {
            var tag1 = new Tag() { TimeConsumed = 2000000, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 2000000
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Title = "1", Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true }; /// 20
            var prob2 = new Problem() { Title = "2", Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true, SolvedAtTime = new DateTime() };  // 20
            var prob3 = new Problem() { Title = "3", Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };   //20
            var prob4 = new Problem() { Title = "4", Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };    //10
            var prob5 = new Problem() { Title = "5", Tags = new EntityCollection<Tag> { tag5 }, Reassignable = true }; // 10


            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { } }; // Workload = 60
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob3, prob1, prob4, prob2 } };               // = 20

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
            Assert.IsTrue(mike.Worklist.Contains(prob3));
            Assert.IsTrue(mike.Worklist.Contains(prob4));
        }


        /// <summary>
        /// only one person
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]

        public void BalanceWorkloadTest17()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 10
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10
            var tag5 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 5 };  //(TimeConsumed / SolvedProblems) = 10
            var tag6 = new Tag() { TimeConsumed = 20, SolvedProblems = 1, Priority = 6 };  //(TimeConsumed / SolvedProblems) = 10
            var tag7 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 7 };  //(TimeConsumed / SolvedProblems) = 10
            var tag8 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 8 };  //(TimeConsumed / SolvedProblems) = 10



            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1, tag5, tag6 }, Reassignable = true, SolvedAtTime = new DateTime() }; /// 20
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true, SolvedAtTime = new DateTime() };  // 20
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true, SolvedAtTime = new DateTime() };   //20
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true, SolvedAtTime = new DateTime() };    //10
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag7, tag8 }, Reassignable = true, SolvedAtTime = new DateTime() }; // 10


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

        public void BalanceWorkloadTest18()
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
            Assert.AreEqual(mike.Workload, 40);
            Assert.AreEqual(john.Workload, 40);
        }
        #endregion

        #region Multiple person Tests
        /// <summary>
        /// In this test we test that the tags will be moved around currectly. Mike has a workload of 30 and john's is 10. The problem with the highest priority should be moved to john, that'll be prob3
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void BalanceWorkloadTest19()
        {
            var tag1 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 1 };  //(TimeConsumed / SolvedProblems) = 20
            var tag2 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 2 };  //(TimeConsumed / SolvedProblems) = 10
            var tag3 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 3 };  //(TimeConsumed / SolvedProblems) = 10
            var tag4 = new Tag() { TimeConsumed = 20, SolvedProblems = 2, Priority = 4 };  //(TimeConsumed / SolvedProblems) = 10

            var prob1 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };
            var prob2 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };
            var prob3 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };
            var prob4 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };
            var prob5 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };
            var prob6 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };
            var prob7 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };
            var prob8 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };
            var prob9 = new Problem() { Tags = new EntityCollection<Tag> { tag1 }, Reassignable = true };
            var prob10 = new Problem() { Tags = new EntityCollection<Tag> { tag2 }, Reassignable = true };
            var prob11 = new Problem() { Tags = new EntityCollection<Tag> { tag3 }, Reassignable = true };
            var prob12 = new Problem() { Tags = new EntityCollection<Tag> { tag4 }, Reassignable = true };

            var mike = new Person() { Name = "mike", Worklist = new EntityCollection<Problem>() { prob1, prob2, prob3 } }; // Workload = 40
            var john = new Person() { Name = "John", Worklist = new EntityCollection<Problem>() { prob4 } };               // = 10
            var hans = new Person() { Name = "hans", Worklist = new EntityCollection<Problem>() { prob5, prob6, prob7,prob12 } }; // Workload = 40
            var kurt = new Person() { Name = "kurt", Worklist = new EntityCollection<Problem>() { prob8 } };               // = 10
            var ulla = new Person() { Name = "ulla", Worklist = new EntityCollection<Problem>() { prob9 } };               // = 10
            var peer = new Person() { Name = "peer", Worklist = new EntityCollection<Problem>() { prob10, prob11 } };  


            Department target = new Department()
            {
                Persons = new EntityCollection<Person>()
                {
                    mike, john, hans, kurt, ulla, peer
                }
            };
            target.BalanceWorkload();
            Assert.AreEqual(20, mike.Workload);
            Assert.AreEqual(20, john.Workload);
            Assert.AreEqual(20, hans.Workload);
            Assert.AreEqual(20, ulla.Workload);
            Assert.AreEqual(20, peer.Workload);
            Assert.AreEqual(20, kurt.Workload);
        }


        #endregion

    }

    
}
