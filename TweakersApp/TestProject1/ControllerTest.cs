using TweakersApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for ControllerTest and is intended
    ///to contain all ControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ControllerTest
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

        [TestMethod()]
        public void test()
        {

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
        ///A test for AddArtComment
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Saya\\Documents\\GitHub\\TweakersApp\\TweakersApp\\TweakersApp", "/")]
        [UrlToTest("http://localhost:2784/")]
        public void AddArtCommentTest()
        {
            Controller target = new Controller(); // TODO: Initialize to an appropriate value
            Comment comment = null; // TODO: Initialize to an appropriate value
            Article article = null; // TODO: Initialize to an appropriate value
            int UserId = 0; // TODO: Initialize to an appropriate value
            target.AddArtComment(comment, article, UserId);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
