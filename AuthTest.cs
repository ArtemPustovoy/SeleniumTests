using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumTests


{
    public class AuthTests
    {
        private IWebDriver driver;

        private readonly By _loginButton = By.XPath("//*[@id='btn-login-expanded']");
        private readonly By _inputMobileNumber = By.XPath("//*[@id='loginInput']");
        private readonly By _password = By.XPath("//*[@id='passwordInput']");
        private readonly By _passVisibilityButton = By.XPath("//*[@class='password-visibility-control']");
        private readonly By _contLoginButton = By.XPath("//*[@id='loginButton']");

        private const string _mobileNumber = "12345678";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Url = "https://moneyveo.ua";
            //driver.Navigate().GoToUrl("https://moneyveo.ua");
            driver.Manage().Window.Maximize();
        }

        [Test, Parallelizable]
        public void Test1()
        {
            var loginButton = driver.FindElement(_loginButton);
            loginButton.Click();

            var mobileNumber = driver.FindElement(_inputMobileNumber);
            mobileNumber.SendKeys(_mobileNumber);
            var password = driver.FindElement(_password);
            password.SendKeys(_mobileNumber);

            var passVisibilityButton = driver.FindElement(_passVisibilityButton);
            passVisibilityButton.Click();

            var contLoginButton = driver.FindElement(_contLoginButton);
            contLoginButton.Click();

            Thread.Sleep(4000);
            driver.Quit();
            Assert.Pass();
        }
    }
}