using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//*[@name='q']");
        By GoogleSearIcon = By.XPath("//*[@name='btnK']");
        By UnoSquareGoogleResult = By.XPath("//h3[contains(text(),'Unosquare: Digital Transformation Services | Agile')]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//*[@href='/Services' and @class='nav-link']");
        By PracticeAreas = By.XPath("//*[@href='/PracticeAreas' and @class='nav-link']");
        By ContactUs = By.XPath("//*[@href='/ContactUs' and @class='nav-link link-blue']");
        //Locators for Assertion
        By OurDna = By.XPath("//*[@href='/OurDna' and @class='nav-link']");
        By ArticlesAndEvents = By.XPath("//*[@href='/Articles' and @class='nav-link']");

        #endregion 
        static void Main(string[] args)
        {

            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            //Wirite the locator for the Google Search Bar
            element = Browser.FindElement(program.GoogleSearchBar);

            // Write Assert True that element is present [Google Search] button
            Assert.IsTrue(element.Displayed);

            //Send the text "Unosquare" to the Text Bar
            program.SendText(element, "Unosquare");

            // Click on the Search Button
            element = Browser.FindElement(program.GoogleSearIcon);
            element.Click();

            // Write Assert Equal [Unosquare: Digital Transformation Services | Agile Staffing ...] vs [Element.text]
            element = Browser.FindElement(program.UnoSquareGoogleResult);
            String unosquareText = "Unosquare: Digital Transformation Services | Agile Staffing ...";
            Assert.AreEqual(unosquareText, element.Text);

            // Locate the first result corresponding to Unosquare and click on the Link
            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            // Write Assert True that element is present [Our Dna] menu object
            element = Browser.FindElement(program.OurDna);
            Assert.IsTrue(element.Displayed);

            // Write Assert True that element is present [Articles & Events] menu object
            element = Browser.FindElement(program.ArticlesAndEvents);
            Assert.IsTrue(element.Displayed);

            // Write Assert Equal [Digital transformation solutions] vs [Element.text] h2 ojbect

            //Locate the Service Menu and Click the element
            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            //Locate the Practice Areas Menu and Click the Element
            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            //Locate the Contact Us Menu and Click the Element
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

        }
    }
}
