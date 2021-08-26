using OpenQA.Selenium;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;
using TestAutomation;
using OpenQA.Selenium.Interactions;

namespace TestAutomation.PageObjects.Pages
{

    public class JourneyPlannerPage : BasePage<JourneyPlannerPage>
    {
        public JourneyPlannerPage(IWebDriverManager webDriverManager) : base(webDriverManager)
        {
        }

        private IWebElement FromInputTextBox => WebDriver.FindElement(By.Id("InputFrom"));
        private IWebElement ToInputTextBox => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement FromInputErrorTextBox => WebDriver.FindElement(By.Id("InputFrom-error"));
        private IWebElement ToInputErrorTextBox => WebDriver.FindElement(By.Id("InputTo-error"));
        private IWebElement PlanMyJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button")); //Can also use ID = "plan-journey-button"
        private IWebElement NewJourneyButton => WebDriver.FindElement(By.Id("jp-new-tab-home"));
        private IWebElement MyJourneysButton => WebDriver.FindElement(By.XPath("//*[@id=\"jp - fav - tab - home\"]/a")); // //Can also use LinkText = "#jp-fav"
        private IWebElement PlanAJourneyHeading => WebDriver.FindElement(By.XPath("//*[@id=\"hp - journey - planner\"]/div/div[1]/div[2]"));
        private IWebElement RecentJourneyDiv => WebDriver.FindElement(By.ClassName("hp-recent-journeys"));






        public bool PageLoaded => PlanMyJourneyButton.Displayed;
        public string InputFromError => FromInputErrorTextBox.Text;
        public string InputToError => ToInputErrorTextBox.Text;

        public JourneyPlannerPage Navigate()
        {
            WebDriverManager.WebDriver.Navigate().GoToUrl(WebDriverManager.RootUrl);
            //private IWebElement CookieBanner => WebDriver.FindElement(By.Id("cb - cookiebanner"));
            //private IWebElement AcceptAllCookiesButton => WebDriver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
            //private IWebElement DoneButton => WebDriver.FindElement(By.Id("cb-buttons"));
            return this;
        }
        public JourneyResultsPage CLickPlanMyJourneyButton()
        {
            PlanMyJourneyButton.Click();
            return new JourneyResultsPage(WebDriverManager).WaitForPageLoad();
        }

        public override JourneyPlannerPage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }
        public JourneyResultsPage PlanAJourneyWithFromAndToDestinations(string fromDestination, string toDestination)
        {
            PlanJourney(fromDestination, toDestination);
            return new JourneyResultsPage(WebDriverManager).WaitForPageLoad();
        }

        public JourneyPlannerPage PlanAJourneyWithNoDestinations(string fromDestination)
        {
            FromInputTextBox.Clear();
            FromInputTextBox.SendKeys(fromDestination);
            NewJourneyButton.Click(); // This was added as the list of suggested inputs was not making it possible to click the Plan Journey button, not ideal solution.

            //WebDriverWait.Until(driver => PlanMyJourneyButton.Enabled); // Attempt 1
            //Actions actions = new Actions(WebDriver); // Attempt 2
            //actions.MoveToElement(PlanMyJourneyButton);

            //There seems to be an issue where if the PlanJourneyButton is not in view then the test will fail. Above commented out codewas attempts to resolve that issue
            PlanMyJourneyButton.Click();
            return this;
        }
        public JourneyPlannerPage EnterJourneyLocations(string fromDestination, string toDestination)
        {
            EnterJourney(fromDestination, toDestination);
            return this;
        }
        public JourneyResultsPage ClickPlanJourneyButton()
        {
            PlanMyJourneyButton.Click();
            return new JourneyResultsPage(WebDriverManager).WaitForPageLoad();
        }
        private void PlanJourney(string fromDestination, string toDestination)
        {
            FromInputTextBox.SendKeys(fromDestination);
            ToInputTextBox.SendKeys(toDestination);
            PlanMyJourneyButton.Click();
        }
        private void EnterJourney(string fromDestination, string toDestination)
        {
            FromInputTextBox.SendKeys(fromDestination);
            ToInputTextBox.SendKeys(toDestination);
        }
    }
}