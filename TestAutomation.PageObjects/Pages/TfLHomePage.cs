using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;
using TestAutomation.PageObjects.Pages;

namespace TestAutomation.PageObjects.Pages
{
    public class TfLHomePage : BasePage<TfLHomePage>
    {
        //new TfLHomePage inherits from BasePage
        // Constructor 
        internal TfLHomePage(IWebDriverManager webDriverManager) : base(webDriverManager)
        {
        }

        // Inspecting IWebelements using different By methods on TfLHomePage
        private IWebElement fromField => WebDriver.FindElement(By.Id("InputFrom"));
        private IWebElement toField => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement planMyJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button"));
        private IWebElement Banner => WebDriver.FindElement(By.Id("InputTo-error"));
        public string BannerText => Banner.Text;
        private IWebElement acceptCookiesButton => WebDriver.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']"));
        private IWebElement doneButton => WebDriver.FindElement(By.Id("//*[@id='cb-buttons']"));
        public bool PageLoaded => planMyJourneyButton.Displayed;

        //Method to Navigate to Url
        public TfLHomePage Navigate()
        {
            WebDriverManager.WebDriver.Navigate().GoToUrl(WebDriverManager.RootUrl);
            return this;
        }
        
        // Method to input value in From field
        public void InputFromField(string source)
        {
           fromField.SendKeys(source);
        }

        // method to input value in To field
        public void InputToField(string destination)
        {
           toField.SendKeys(destination);
        }
        // Method to go to next Page Journey Results after clicking Plan My Journey button
        public JourneyResultsPage ClickPlanMyJourneyButton()
        {
            planMyJourneyButton.Click();
            return new JourneyResultsPage(WebDriverManager).WaitForPageLoad();
        }
        // Method to remain on TFLHomePage after clicking Plan My Journey button         
        public TfLHomePage ClickPlanMyDestinationNoDestination()
        {
            planMyJourneyButton.Click();
            return new TfLHomePage(WebDriverManager).WaitForPageLoad();
        }
        //Overridden method from the Base class
        public override TfLHomePage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }
        // Method to click on Cookies
        public void ClickAcceptCookiesButton()
        {
            string parentWindow = WebDriver.CurrentWindowHandle;
            IReadOnlyCollection<string> handles = WebDriver.WindowHandles;
            foreach (string handle in handles)
            {
                IWebDriver popup = WebDriver.SwitchTo().Window(handle);
                if (popup.Title.Contains("Cookies"))
                {
                    break;
                }

                //IJavaScriptExecutor jse = (IJavaScriptExecutor)WebDriver;
                //jse.ExecuteScript("arguments[0].scrollIntoView()", acceptCookiesButton);
                //acceptCookiesButton.Click();
                //ReadOnlyCollection<IWebElement> donebuttons = driver.FindElements(doneButton);
                //buttons[2].Click();
            }

        }

    }
}
