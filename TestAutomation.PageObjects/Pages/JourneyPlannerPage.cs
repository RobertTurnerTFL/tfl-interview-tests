
using NUnit.Framework;
using OpenQA.Selenium;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;

namespace TestAutomation.PageObjects.Pages
{
    public class JourneyPlannerPage : BasePage<JourneyPlannerPage>
    {
        internal JourneyPlannerPage(IWebDriverManager webDriverManager) : base(webDriverManager)
        {
        }

        private IWebElement TransportForLondonHeading => WebDriver.FindElement(By.XPath("//h1[@class='tfl-name']"));
        private IWebElement JourneyResultsHeading => WebDriver.FindElement(By.XPath("//span[@class='jp-results-headline']"));
        private IWebElement FastestPublicTransportHeading => WebDriver.FindElement(By.XPath("//h2[contains(@class, 'publictransport')]"));
        private IWebElement CyclingOptionHeading => WebDriver.FindElement(By.XPath("//h2[text()='Cycling and other options']"));
        private IWebElement InputFromField => WebDriver.FindElement(By.Id("InputFrom"));
        private IWebElement InputToField => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement PlanMyJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button"));
        private IWebElement ErrorMessage => WebDriver.FindElement(By.XPath("//li[@class='field-validation-error']"));
        private IWebElement ErrorMessageInputTo => WebDriver.FindElement(By.XPath("//span[@id='InputTo-error']"));

        public string TransportForLondonText => TransportForLondonHeading.Text;
        public string JourneyResultsText => JourneyResultsHeading.Text;
        public string CyclingOptionText => CyclingOptionHeading.Text;
        public string FastestPublicTransportText => FastestPublicTransportHeading.Text;
        public string ErrorMessageText => ErrorMessage.Text;
        public string ErrorMessageInputToText => ErrorMessageInputTo.Text;
        public bool PageLoaded => TransportForLondonHeading.Displayed;

        public void EnterInputFrom(string journeyFrom)
        {
            InputFromField.SendKeys(journeyFrom);
        }
        public void EnterInputTo(string journeyTo)
        {
            InputToField.Clear();
            InputToField.SendKeys(journeyTo);
        }
        public void ClickOnPlanMyJourneyButton()
        {
            PlanMyJourneyButton.Click();
        }
        public void ValidateInputFromAndToInJourney(string journeyFrom, string journeyTo)
        {
            string InputFrom = WebDriver.FindElement(By.XPath("//strong[text()='" + journeyFrom + "']")).Text;
            Assert.AreEqual(journeyFrom, InputFrom);
            string InputTo = WebDriver.FindElement(By.XPath("//strong[text()='" + journeyTo + "']")).Text;
            Assert.AreEqual(journeyTo, InputTo);
        }

        public override JourneyPlannerPage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }
    }
}
