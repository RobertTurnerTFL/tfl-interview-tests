using OpenQA.Selenium;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;

namespace TestAutomation.PageObjects.Pages
{
    public class EditJourneyPage : BasePage<EditJourneyPage>
    {
        public EditJourneyPage(IWebDriverManager webDriverManager) : base(webDriverManager)
        {
        }

        private IWebElement FromInputTextBox => WebDriver.FindElement(By.Id("InputFrom"));
        private IWebElement ToInputTextBox => WebDriver.FindElement(By.Id("InputTo"));
        private IWebElement UpdateJourneyButton => WebDriver.FindElement(By.Id("plan-journey-button"));
        private IWebElement ValidationErrorField => WebDriver.FindElement(By.ClassName("field-validation-error"));



        public bool PageLoaded => UpdateJourneyButton.Displayed;

        public string ValidationError => ValidationErrorField.Text;

        public override EditJourneyPage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }
        public JourneyResultsPage UpdateAJourneyWithValidFromAndToDestinations(string fromDestination, string toDestination)
        {
            UpdateJourney(fromDestination, toDestination);
            return new JourneyResultsPage(WebDriverManager).WaitForPageLoad();
        }

        private void UpdateJourney(string fromDestination, string toDestination)
        {
            FromInputTextBox.SendKeys(fromDestination);
            ToInputTextBox.SendKeys(toDestination);
            UpdateJourneyButton.Click();
        }
    }
}