using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;

namespace TestAutomation.PageObjects.Pages
{
    public class TflPage : BasePage<TflPage>
    {
        private ScenarioContext _scenarioContext;

        internal TflPage(IWebDriverManager webDriverManager,ScenarioContext scenarioContext) : base(webDriverManager)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        private IWebElement PlanJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button"));
        private IWebElement CookieDoneButton =>
            WebDriver.FindElement(By.XPath("//button[contains(@onclick,'endCookieProcess')]"));
        private IWebElement FromStation => WebDriver.FindElement(By.Id("InputFrom"));
        private IWebElement ToStation => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement ErrorMissingTo => WebDriver.FindElement(By.Id("InputTo-error"));
        private IWebElement ErrorMissingFrom => WebDriver.FindElement(By.Id("InputFrom-error"));

        public bool PageLoaded => PlanJourneyButton.Displayed;

        public TflPage Navigate()
        {
            WebDriverManager.WebDriver.Navigate().GoToUrl(WebDriverManager.RootUrl);
            return this;
        }
        public void AcceptCookies()
        {
            //Accepts cooking popup from the screen
            WebDriverWait.Until(
                ExpectedConditions.ElementExists(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"))).Click();
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(CookieDoneButton)).Click();
        }

        public override TflPage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }

        public void EnterJourneyDetails(string field,string StationName)
        {
            IWebElement Field = null;
            switch (field.ToLower())
            {
                case "fromstation":
                    Field = FromStation;
                    _scenarioContext.Remove("From Station");
                    _scenarioContext.Add("From Station", StationName);
                    break;
                case "tostation":
                    Field = ToStation;
                    _scenarioContext.Remove("To Station");
                    _scenarioContext.Add("To Station", StationName);
                    break;
            }
            Field.SendKeys(Keys.LeftShift + Keys.Home);
            Field.SendKeys(StationName);
        }

        public JourneyResultsPage ClickPlanMyJourney()
        {
            PlanJourneyButton.Click();
            return new JourneyResultsPage(WebDriverManager,_scenarioContext).WaitForPageLoad();
        }

        public string GetErrorMessageFrom() => ErrorMissingFrom.Text;

        public string GetErrorMessageTo() => ErrorMissingTo.Text;

        public TflPage ClickPlanMyJourneyInvalidFromOrToStation()
        {
            PlanJourneyButton.Click();
            return this;
        }
    }
}