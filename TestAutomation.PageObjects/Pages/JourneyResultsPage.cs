using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.PageObjects.Pages;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;
using OpenQA.Selenium;

namespace TestAutomation.PageObjects.Pages
{
    public class JourneyResultsPage : BasePage<JourneyResultsPage>   //new JourneyResultsPage inherits from BasePage
    {
        // Constructor 
        public JourneyResultsPage(IWebDriverManager webDriverManager) : base(webDriverManager)
        {
        }
        // Inspecting IWebelements using different By methods on JourneyResults Page
        private IWebElement summary => WebDriver.FindElement(By.XPath("//div[contains(@class, 'journey-result-summary') and contains(., 'London Victoria')]"));
        private IWebElement fastestRoutes => WebDriver.FindElement(By.XPath("//div[contains(@class, 'scroller') and contains(., 'Showing the fastest routes')]"));
        private IWebElement editJourneyLink => WebDriver.FindElement(By.XPath("//span[.='Edit journey']"));
        private IWebElement toField => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement updateJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button"));

        private IWebElement Banner => WebDriver.FindElement(By.ClassName("field-validation-error"));
        public string BannerText => Banner.Text;
        
        public bool PageLoaded => summary.Displayed;

        //Method to verify Summary on JourneyResults page
        public void VerifyJourneyResultsSummaryPage()
        {
            summary.Text.Contains("London Victoria");
           // Console.WriteLine("Summary Successfull");
        }
        // Method to verify fastest routes text on the Page
        public void VerifyFastestRoute()
        {
            fastestRoutes.Text.Contains("Showing the fastest routes");
           // Console.WriteLine("Fastest Routes Successfull");
        }
        // Method to click on Edit Journey button
        public void ClickEditJourneyLink()
        {
            editJourneyLink.Click();

        }
        //Method to edit value in To field
        public void InputToField(string destination)
        {
            toField.Clear();
            toField.SendKeys(destination);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);        
        }
        //Method to click update Journey button
        public void ClickUpdateJourneyButton()
        {
            updateJourneyButton.Click();
        }
        //Overridden method from the Base class
        public override JourneyResultsPage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }

    }
}
