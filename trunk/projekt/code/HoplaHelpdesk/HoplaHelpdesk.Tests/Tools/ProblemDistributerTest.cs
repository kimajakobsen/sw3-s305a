using HoplaHelpdesk.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using HoplaHelpdesk.Models;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProblemDistributerTest and is intended
    ///to contain all ProblemDistributerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProblemDistributerTest
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
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
       
        }
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

        #region Public vars

        #endregion






        /// <summary>
        ///A test for GetDepartment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
       // [HostType("ASP.NET")]
       // [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
       // [UrlToTest("http://localhost:6399/")]
        public void GetDepartmentTest()
        {
            var dept1 = new Department() { DepartmentName = "Names" };
            var cat1 = new Category() { Name = "Name", Department = dept1 };
            var dept2 = new Department() { DepartmentName = "Names2" };
            var cat2 = new Category() { Name = "Nam2e", Department = dept2 };
            EntityCollection<Tag> tags = new EntityCollection<Tag>()
            {
                new Tag(){
                    Name = "Jolælhn",
                    Category = cat1
                }, 
               new Tag(){
                    Name = "Johlælæn",
                    Category = cat1
                }, 
                new Tag(){  Name = "Jælælohn", Category = cat1  }, 
                new Tag(){  Name = "Jælælohn", Category = cat1  }, 
                new Tag(){  Name = "Jælælohn", Category = cat1  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
            }; // TODO: Initialize to an appropriate value
            Department expected = dept1; // TODO: Initialize to an appropriate value

            Department actual;
            actual = ProblemDistributer.GetDepartment(tags);
            Assert.AreEqual(expected, actual);
         
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for GetDepartment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        // [HostType("ASP.NET")]
        // [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        // [UrlToTest("http://localhost:6399/")]
        public void GetDepartmentTest2()
        {
            EntityCollection<Tag> tags = new EntityCollection<Tag>()
            {
               
            }; // TODO: Initialize to an appropriate value
            Department expected = null; // TODO: Initialize to an appropriate value

            Department actual;
            actual = ProblemDistributer.GetDepartment(tags);
            Assert.AreEqual(expected, actual);

            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetStaff
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
      //  [HostType("ASP.NET")]
      //  [AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
      //  [UrlToTest("http://localhost:6399/")]
        public void GetStaffTest()
        {
            var dept1 = new Department() { DepartmentName = "Names" };
            var cat1 = new Category() { Name = "Name", Department = dept1 };
            var dept2 = new Department() { DepartmentName = "Names2" };
            var cat2 = new Category() { Name = "Nam2e", Department = dept2 };
            EntityCollection<Tag> tags = new EntityCollection<Tag>()
            {
                new Tag(){
                    Name = "Jolælhn",
                    Category = cat1
                }, 
               new Tag(){
                    Name = "Johlælæn",
                    Category = cat1
                }, 
                new Tag(){  Name = "Jælælohn", Category = cat1  }, 
                new Tag(){  Name = "Jælælohn", Category = cat1  }, 
                new Tag(){  Name = "Jælælohn", Category = cat1  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
            }; // TODO: Initialize to an appropriate value

            Problem Problem = new Problem(){ Tags = tags }; // TODO: Initialize to an appropriate value

            EntityCollection<Problem> worklist = new EntityCollection<Problem>() { new Problem(), new Problem(), new Problem(), new Problem(), new Problem(), new Problem(), new Problem() };
            EntityCollection<Problem> worklist2 = new EntityCollection<Problem>() { new Problem(), new Problem(), new Problem(), new Problem() };
            EntityCollection<Problem> worklist3 = new EntityCollection<Problem>() {  new Problem() };

            // In this test the problem belongs to dept1. John has the shorthest worklist, but is not staff. Mrt should get it.
            IPerson Johnny = new TestPerson() { Worklist = worklist, Department = dept1};
            IPerson MrT = new TestPerson() { Worklist = worklist2, Department = dept1 };
            IPerson John = new TestPerson() { Worklist = worklist3, Department = dept1, Name = "john" };
            IPerson MrTt = new TestPerson() { Worklist = worklist, Department = dept1 };
            EntityCollection<IPerson> PersonSet = new EntityCollection<IPerson>()
            {
               John, MrT, Johnny, MrTt
            };

           
            IPerson expected = MrT; 
            IPerson actual;
            actual = ProblemDistributer.GetStaff(Problem, PersonSet);
            Assert.AreEqual(expected, actual);
           // Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for GetStaff
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
       // [HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("C:\\Users\\John\\Documents\\sw3\\projekt\\code\\HoplaHelpdesk\\HoplaHelpdesk", "/")]
        //[UrlToTest("http://localhost:6399/")]
        public void GetStaffTest2()
        {
            var dept1 = new Department() { DepartmentName = "Names" };
            var cat1 = new Category() { Name = "Name", Department = dept1 };
            var dept2 = new Department() { DepartmentName = "Names2" };
            var cat2 = new Category() { Name = "Nam2e", Department = dept2 };
            EntityCollection<Tag> tags = new EntityCollection<Tag>()
            {
                new Tag(){
                    Name = "Jolælhn",
                    Category = cat1
                }, 
               new Tag(){
                    Name = "Johlælæn",
                    Category = cat1
                }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
                new Tag(){  Name = "Jælælohn", Category = cat2  }, 
            }; // TODO: Initialize to an appropriate value

            Problem Problem = new Problem() { Tags = tags }; // TODO: Initialize to an appropriate value

            EntityCollection<Problem> worklist = new EntityCollection<Problem>() { new Problem(), new Problem(), new Problem(), new Problem(), new Problem(), new Problem(), new Problem() };
            EntityCollection<Problem> worklist2 = new EntityCollection<Problem>() { new Problem(), new Problem(), new Problem(), new Problem() };
            EntityCollection<Problem> worklist3 = new EntityCollection<Problem>() { new Problem() };


            // Johnny is the only one working in  dept 2, and his worklist is very heavy. 
            // The problem belongs to dept2 so he should still get it.
            IPerson Johnny = new TestPerson() { Worklist = worklist, Department = dept2 };
            IPerson MrT = new TestPerson() { Worklist = worklist2, Department = dept1 };
            IPerson John = new TestPerson() { Worklist = worklist3, Department = dept1 };
            IPerson MrTt = new TestPerson() { Worklist = worklist, Department = dept1 };
            EntityCollection<IPerson> PersonSet = new EntityCollection<IPerson>()
            {
               John, MrT, Johnny, MrTt
            };


            IPerson expected = Johnny; 
            IPerson actual;
            actual = ProblemDistributer.GetStaff(Problem, PersonSet);
            Assert.AreEqual(expected, actual);
            // Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }

    public class TestPerson : IPerson{
        public  bool IsStaff()
        {
            if (Name == "john")
            {
                return false;
            }
            return true;
        }

        public double getWorkload()
        {
            return Worklist.Count;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public EntityCollection<Problem> Worklist { get; set; }
        public int Id { get; set; }
        public Department Department { get; set; }
    }
}
