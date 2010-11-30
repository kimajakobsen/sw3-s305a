using HoplaHelpdesk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data.Objects.DataClasses;
using System.Collections.Generic;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProblemTest and is intended
    ///to contain all ProblemTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProblemTest
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
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
          public void GetPriorityTest()
        {
            Problem target = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 }
                }

            };

            Double expected = 3; // TODO: Initialize to an appropriate value
            Double actual;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetPriorityTest2()
        {
            Problem target = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 8 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 9 }
                }

            };

            Double expected = Math.Round((Double)(3+3+8+3+9)/5, 2); // TODO: Initialize to an appropriate value
            Double actual;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
          //  Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetPriorityTest3()
        {
            Problem target = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 8 },
                    new Tag(){ Priority = 1 },
                    new Tag(){ Priority = 9 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 8 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 9 }
                }

            };

            Double expected = Math.Round((Double)(3+3+8+1+9+3+3+8+3+9) / 10, 2); // TODO: Initialize to an appropriate value
            Double actual;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
          ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetPriorityTest4()
        {
            Problem target = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                
                }

            };

            Double expected = 0; // TODO: Initialize to an appropriate value
            Double actual;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetPriorityTest5()
        {
            Problem target = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 },
                    new Tag(){ Priority = 0 }
                }

            };

            Double expected = 0; // TODO: Initialize to an appropriate value
            Double actual;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
      //      Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void GetPriorityTest6()
        {
            Problem target = new Problem()
            {
                Tags = new EntityCollection<Tag>()
                {
                    new Tag(){ Priority = 5 },
                    new Tag(){ Priority = 3 },
                    new Tag(){ Priority = 2 },
                }

            };

            Double expected = 3.33; // TODO: Initialize to an appropriate value
            Double actual;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ProblemSortTest()
        {
            Problem prob1 = new Problem() { Tags = new EntityCollection<Tag>(){ new Tag(){ Priority = 1 }     }    };
            Problem prob2 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 2 } } };
            Problem prob3 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 3 } } };
            Problem prob4 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 4 } } };

            var list = new List<Problem>() { prob1, prob2, prob3, prob4 };
            
          
            Assert.AreEqual(list[0], prob1);
            Assert.AreEqual(list[1], prob2);
            Assert.AreEqual(list[2], prob3);
            Assert.AreEqual(list[3], prob4);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ProblemSortTest2()
        {
            Problem prob1 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 4 } } };
            Problem prob2 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 3 } } };
            Problem prob3 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 2 } } };
            Problem prob4 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };

            var list = new List<Problem>() { prob1, prob2, prob3, prob4 };
          /*  list.Sort(delegate(Problem p1, Problem p2)
              {
                  return p2.Priority.CompareTo(p1.Priority);
              });
           * */
            list.Sort(Problem.GetComparer());
            Assert.AreEqual(list[0], prob1);
            Assert.AreEqual(list[1], prob2);
            Assert.AreEqual(list[2], prob3);
            Assert.AreEqual(list[3], prob4);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ProblemSortTest3()
        {
            Problem prob1 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
            Problem prob2 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 2 } } };
            Problem prob3 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 3 } } };
            Problem prob4 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 4 } } };

            var list = new List<Problem>() { prob1, prob2, prob3, prob4 };
            list.Sort(Problem.GetComparer());

            Assert.AreEqual(list[0], prob4);
            Assert.AreEqual(list[1], prob3);
            Assert.AreEqual(list[2], prob2);
            Assert.AreEqual(list[3], prob1);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ProblemSortTest4()
        {
            Problem prob1 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
            Problem prob2 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 2 } } };
            Problem prob3 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 3 } } };
            Problem prob4 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 4 } } };
            Problem prob5 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 5 } } };
            var list = new List<Problem>() { prob3, prob1,prob5, prob2, prob4 };
            list.Sort(Problem.GetComparer());

            Assert.AreEqual(list[0], prob5);
            Assert.AreEqual(list[1], prob4);
            Assert.AreEqual(list[2], prob3);
            Assert.AreEqual(list[3], prob2);
            Assert.AreEqual(list[4], prob1);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ProblemSortTest5()
        {
            Problem prob1 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
            Problem prob2 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 2 } } };
            Problem prob3 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 3 } } };
            Problem prob4 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 4 } } };
            Problem prob5 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 5 } } };
            Problem prob6 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
            Problem prob7 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
            Problem prob8 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
            Problem prob9 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };
           
            var list = new List<Problem>() { prob8, prob9,prob3, prob1, prob5, prob2, prob4, prob6 };
            
            list.Sort(Problem.GetComparer());

            Assert.AreEqual(list[0], prob5);
            Assert.AreEqual(list[1], prob4);
            Assert.AreEqual(list[2], prob3);
            Assert.AreEqual(list[3], prob2);
          //  Assert.AreEqual(list[4], prob1);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for GetPriority
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void ProblemSortTest6()
        {
            Problem prob1 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 4 } } };
            Problem prob2 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 3 } } };
            Problem prob3 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 2 } } };
            Problem prob4 = new Problem() { Tags = new EntityCollection<Tag>() { new Tag() { Priority = 1 } } };

            var list = new List<Problem>() { prob4, prob3, prob2, prob1 };
            /*  list.Sort(delegate(Problem p1, Problem p2)
                {
                    return p2.Priority.CompareTo(p1.Priority);
                });
             * */
            list.Sort(Problem.GetComparer());
            Assert.AreEqual(list[0], prob1);
            Assert.AreEqual(list[1], prob2);
            Assert.AreEqual(list[2], prob3);
            Assert.AreEqual(list[3], prob4);
            ///  Assert.Inconclusive("Verify the correctness of this test method.");
        }

        #region Not used
        /*
        /// <summary>
        ///A test for Added_date
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        public void Added_dateTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> expected = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> actual;
            target.Added_date = expected;
            actual = target.Added_date;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AssignedTo
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void AssignedToTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            Person expected = null; // TODO: Initialize to an appropriate value
            Person actual;
            target.AssignedTo = expected;
            actual = target.AssignedTo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AssignedToReference
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void AssignedToReferenceTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            EntityReference<Person> expected = null; // TODO: Initialize to an appropriate value
            EntityReference<Person> actual;
            target.AssignedToReference = expected;
            actual = target.AssignedToReference;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CommentSet
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void CommentSetTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            EntityCollection<Comment> expected = null; // TODO: Initialize to an appropriate value
            EntityCollection<Comment> actual;
            target.CommentSet = expected;
            actual = target.CommentSet;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Deadline
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void DeadlineTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> expected = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> actual;
            target.Deadline = expected;
            actual = target.Deadline;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Description
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void DescriptionTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Description = expected;
            actual = target.Description;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Id
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void IdTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Id = expected;
            actual = target.Id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsDeadlineApproved
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void IsDeadlineApprovedTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            Nullable<bool> expected = new Nullable<bool>(); // TODO: Initialize to an appropriate value
            Nullable<bool> actual;
            target.IsDeadlineApproved = expected;
            actual = target.IsDeadlineApproved;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Persons
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void PersonsTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            EntityCollection<Person> expected = null; // TODO: Initialize to an appropriate value
            EntityCollection<Person> actual;
            target.Persons = expected;
            actual = target.Persons;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PersonsId
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void PersonsIdTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.PersonsId = expected;
            actual = target.PersonsId;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Reassignable
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void ReassignableTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            Nullable<bool> expected = new Nullable<bool>(); // TODO: Initialize to an appropriate value
            Nullable<bool> actual;
            target.Reassignable = expected;
            actual = target.Reassignable;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Solutions
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void SolutionsTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            EntityCollection<Solution> expected = null; // TODO: Initialize to an appropriate value
            EntityCollection<Solution> actual;
            target.Solutions = expected;
            actual = target.Solutions;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SolvedAtTime
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void SolvedAtTimeTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> expected = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> actual;
            target.SolvedAtTime = expected;
            actual = target.SolvedAtTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Tags
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void TagsTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            EntityCollection<Tag> expected = null; // TODO: Initialize to an appropriate value
            EntityCollection<Tag> actual;
            target.Tags = expected;
            actual = target.Tags;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Title
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        [UrlToTest("http://localhost:6399/")]
        public void TitleTest()
        {
            Problem target = new Problem(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Title = expected;
            actual = target.Title;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
         */
        #endregion
    }
         
}
