using HoplaHelpdesk.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Models;
using System.Collections.Generic;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProblemSearchTest and is intended
    ///to contain all ProblemSearchTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProblemSearchTest
    {
        CategoryTagSelectionViewModel catTag = null; // TODO: Initialize to an appropriate value
        List<Problem> problems = null; // TODO: Initialize to an appropriate value
        List<Tag> tags = null;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current Act.
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

        #region Test Initialize
        [TestInitialize()]
        public void MyTestInitialize()
        {    
            catTag = new CategoryTagSelectionViewModel
            {
                Categories = new List<CategoryWithListViewModel>
                {
                    new CategoryWithListViewModel
                    {
                        Id = 0,
                        TagList = new List<Tag>
                        {
                            new Tag
                            {
                                Id = 0,
                                Category_Id = 0,
                                IsSelected = false
                            },
                            new Tag
                            {
                                Id = 1,
                                Category_Id = 0,
                                IsSelected = false
                            }
                        }
                    },
                    new CategoryWithListViewModel
                    {
                        Id = 1,
                        TagList = new List<Tag>
                        {
                            new Tag
                            {
                                Id = 2,
                                Category_Id = 1,
                                IsSelected = false
                            },
                            new Tag
                            {
                                Id = 3,
                                Category_Id = 1,
                                IsSelected = false
                            }
                        }
                    }
                }
            };



            tags = new List<Tag>
            {
                catTag.Categories[0].TagList[0],
                catTag.Categories[0].TagList[1],
                catTag.Categories[1].TagList[0],
                catTag.Categories[1].TagList[1]
            };


            problems = new List<Problem>{
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[0],
                        tags[1]
                    },
                    Id = 0
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[0],
                        tags[1]
                    },
                    Id = 1
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    {
                    },
                    Id = 2
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[0]
                    },
                    Id = 3
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    {
                        tags[1]
                    },
                    Id = 4
                },
                new Problem
                {
                    Tags = new System.Data.Objects.DataClasses.EntityCollection<Tag>
                    { 
                        tags[3]
                    },
                    Id = 5
                }
            };

        }
        #endregion

        /// <summary>
        ///A test for Search
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        #region Test 1: Search for tag 0 and 1, minimum number of problems = 2
        [TestMethod()]
        public void SearchTest1()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 2;

            tags[0].IsSelected = true;
            tags[1].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[0],
                problems[1]
            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag,problems,tags,minNoProb);
            #endregion

            #region Assertions
            Assert.IsTrue(actual.Count >= minNoProb);
            Assert.AreEqual(expected.Count,actual.Count);
            for (int i = 0 ; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            //Assert.Inconclusive("Verify the correctness of this test method.");
            #endregion
        }
        #endregion

        #region Test 2: Search for tag 0 and 1, minimum number of problems = 4
        [TestMethod()]
        public void SearchTest2()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 4;

            tags[0].IsSelected = true;
            tags[1].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[0],
                problems[1],
                problems[3],
                problems[4]

            };
            #endregion


            #region Act
            actual = ProblemSearch.Search(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.IsTrue(actual.Count >= minNoProb);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion

        #region Test 3: Search for tag 0, minimum number of problems = 6
        [TestMethod()]
        public void SearchTest3()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 6;

            tags[0].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[3],
                problems[0],
                problems[1],
                problems[2],
                problems[4],
                problems[5]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.IsTrue(actual.Count >= minNoProb);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion
    }
}