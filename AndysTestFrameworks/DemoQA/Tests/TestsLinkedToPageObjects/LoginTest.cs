using AndysTestFrameworks.DemoQA.PageObjects;
using AndysTestFrameworks.DemoQA.Tests.Base;


namespace AndysTestFrameworks.DemoQA.TestCases.TestsLinkedToPageObjects
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void TestLoginOnDemoQASitePageFactory()
        {
            Pages.Login.GoTo();
            Pages.Login.LoginToApplication();
        }

    }
}
