using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WebDriverHelloWorld
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Navegando com o Chrome
            using (IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver())
            {
                SearchAndNavigateTest(driver);
            }

            //Navegando com o Firefox
            using (IWebDriver driver = new OpenQA.Selenium.Firefox.FirefoxDriver())
            {
                SearchAndNavigateTest(driver);
            }
        }

        private static void SearchAndNavigateTest(IWebDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl("http://www.bing.com/");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
                IWebElement searchInput = driver.FindElement(By.Id("sb_form_q"));
                searchInput.SendKeys("aplicacoesweb selenium");
                searchInput.SendKeys(Keys.Return);

                IWebElement webSiteAnchor = driver.FindElement(By.XPath(("//a[contains(@href,\"aplicacoesweb.blogspot\")]")));
                webSiteAnchor.Click();
            }
            finally
            {
                driver.Close();
            }
        }
    }
}
