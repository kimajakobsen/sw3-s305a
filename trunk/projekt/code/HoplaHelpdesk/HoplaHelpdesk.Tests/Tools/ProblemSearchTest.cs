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
                    Id = 1,
                    SolvedAtTime = new DateTime(2010,12,5)
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
                    Id = 4,
                    SolvedAtTime = new DateTime(2010,12,5)
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


        #region Search code coverage
        #region Test 1: Search for no tag, minimum number of problems = 0
        [TestMethod()]
        public void A0_D0_SearchForNoTagNoProblems()
        {
            #region Arrange
            List<Problem> expected = null;
            List<Problem> actual = null;
            int minNoProb = 0;

            expected = new List<Problem>();
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            #endregion
        }
        #endregion

        #region Test 2: Search for no tag, minimum number of problems = 1
        [TestMethod()]
        public void A0_D1_SearchForNoTagOneProblem()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 1;

            expected = new List<Problem>
            {
                problems[2]
            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion

        #region Test 3: Search for no tag, minimum number of problems = 6
        [TestMethod()]
        public void A0_Dx_SearchForNoTagSixProblems()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 6;

            expected = new List<Problem> 
            { 
                problems[2],
                problems[3],
                problems[4],
                problems[5],
                problems[0],
                problems[1]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion

        #region Test 4: Search for tag 3, minimum number of problems = 1
        [TestMethod()]
        public void A1_B1_C1_D0_SearchForTag3OneProblem()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 1;

            tags[3].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[5]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
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

        #region Test 5: Search for tag 3, minimum number of problems = 2
        [TestMethod()]
        public void A1_B1_C1_D1_SearchForTag3TwoProblem()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 2;

            tags[3].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[5],
                problems[2]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
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

        #region Test 6: Search for tag 3, minimum number of problems = 4
        [TestMethod()]
        public void A1_B1_C1_Dx_SearchForTag3TwoProblem()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 4;

            tags[3].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[5],
                problems[2],
                problems[3],
                problems[4]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
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

        #region Test 7: Search for tag 0 and 1, minimum number of problems = 4
        [TestMethod()]
        public void Ax_Bx_Cx_D0_SearchForTag0And1FourProblems()
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
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
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

        #region Test 8: Search for tag 0 and 1, minimum number of problems = 5
        [TestMethod()]
        public void Ax_Bx_Cx_D1_SearchForTag0And1FiveProblems()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 5;

            tags[0].IsSelected = true;
            tags[1].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[0],
                problems[1],
                problems[3],
                problems[4],
                problems[2]

            };
            #endregion


            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
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

        #region Test 9: Search for tag 0 and 1, minimum number of problems = 6
        [TestMethod()]
        public void Ax_Bx_Cx_Dx_SearchForTag0And1SixProblems()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 6;

            tags[0].IsSelected = true;
            tags[1].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[0],
                problems[1],
                problems[3],
                problems[4],
                problems[2],
                problems[5]

            };
            #endregion


            #region Act
            actual = ProblemSearch.Search(catTag, problems, minNoProb);
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
        #endregion

        #region Search boundry exceed + sorting
        #region Test 1: Search for tag 3, minimum number of problems = 10
        [TestMethod()]
        public void SearchTestForBigMinNoProbValue()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 10;

            tags[3].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[5],
                problems[2],
                problems[3],
                problems[4],
                problems[0],
                problems[1]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion

        #region Test 2: Search for tag 2, minimum number of problems = 10
        [TestMethod()]
        public void SearchForTagNoProblems()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 10;

            expected = new List<Problem> 
            { 
                problems[2],
                problems[3],
                problems[4],
                problems[5],
                problems[0],
                problems[1]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion

        #region Test 3: Search for no tag, minimum number of problems = 10
        [TestMethod()]
        public void SearchForNoTag()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 10;

            expected = new List<Problem> 
            { 
                problems[2],
                problems[3],
                problems[4],
                problems[5],
                problems[0],
                problems[1]

            };
            #endregion

            #region Act
            actual = ProblemSearch.Search(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion
        #endregion

        #region Search solved first additional tests, mainly sorting
        #region Test 1: SearchSolvedFirst for tag 0 and 1, minimum number of problems = 4
        [TestMethod()]
        public void SearchSolvedFirstBasicTest()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 4;

            tags[0].IsSelected = true;
            tags[1].IsSelected = true;
            expected = new List<Problem> 
            { 
                problems[1],
                problems[0],
                problems[4],
                problems[3]
            };
            #endregion

            #region Act
            actual = ProblemSearch.SearchSolvedFirst(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.IsTrue(actual.Count >= minNoProb);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            //Assert.Inconclusive("Verify the correctness of this test method.");
            #endregion
        }
        #endregion

        #region Test 2: SearchSolvedFirst for no tag, minimum number of problems = 10
        [TestMethod()]
        public void SearchSolvedFirstForNoTag()
        {
            #region Arrange
            List<Problem> expected = null; // TODO: Initialize to an appropriate value
            List<Problem> actual = null;
            int minNoProb = 10;

            expected = new List<Problem> 
            { 
                problems[4],
                problems[1],
                problems[2],
                problems[3],
                problems[5],
                problems[0]

            };
            #endregion

            #region Act
            actual = ProblemSearch.SearchSolvedFirst(catTag, problems, tags, minNoProb);
            #endregion

            #region Assertions
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id);
            }
            #endregion
        }
        #endregion
        #endregion
    }
}