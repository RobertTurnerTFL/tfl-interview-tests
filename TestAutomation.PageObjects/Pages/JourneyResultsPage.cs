using OpenQA.Selenium;
using TestAutomation.Framework.BasePages;
using TestAutomation.Framework.Interfaces;

namespace TestAutomation.PageObjects.Pages
{
    public class JourneyResultsPage : BasePage<JourneyResultsPage>
    {
        public JourneyResultsPage(IWebDriverManager webDriverManager) : base(webDriverManager)
        {
        }

        private IWebElement JourneyResultsHeadline => WebDriver.FindElement(By.ClassName("jp-results-headline"));
        private IWebElement EditJourneyButton => WebDriver.FindElement(By.ClassName("edit-journey"));
        private IWebElement FromDestinationField => WebDriver.FindElement(By.XPath("//*[@id=\"plan - a - journey\"]/div[1]/div[1]/div[1]/span[2]/strong"));
        private IWebElement ToDestinationField => WebDriver.FindElement(By.XPath("//*[@id=\"plan - a - journey\"]/div[1]/div[1]/div[2]/span[2]/strong"));
        private IWebElement FastestRoute => WebDriver.FindElement(By.ClassName("jp-result-transport publictransport clearfix"));
        private IWebElement ErrorMessageField => WebDriver.FindElement(By.ClassName("field-validation-error"));




        //*[@id="full-width-content"]/div/div[8]/div/div/div/div/div[2]/div[1]/span


        public bool PageLoaded => JourneyResultsHeadline.Displayed;
        public bool FastestRouteDisplayed => FastestRoute.Displayed;
        public string ErrorField => ErrorMessageField.Text;



        public override JourneyResultsPage WaitForPageElements()
        {
            WebDriverWait.Until(driver => PageLoaded);
            return this;
        }

        //public override JourneyResultsPage VerifyJourneySummary()
        //{
        //    WebDriverWait.Until(driver => PageLoaded);
        //    VerifyFromDestinationSummary();
        //    VerifyToDestinationSummary();
        //    return this;
        //}

        public string VerifyFromDestinationSummary()
        {
            string fromDestinationSummary = FromDestinationField.ToString();
            return fromDestinationSummary;
        }
        public string VerifyToDestinationSummary()
        {
            string toDestinationSummary = ToDestinationField.ToString();
            return toDestinationSummary;
        }


    }
}