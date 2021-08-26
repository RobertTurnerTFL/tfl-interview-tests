using TestAutomation.Framework.Interfaces;
using TestAutomation.PageObjects.Pages;

namespace TestAutomation.PageObjects.Factories
{
    public class PageObjectFactory : IPageObjectFactory
    {
        private readonly IWebDriverManager _webDriverManager;

        public PageObjectFactory(IWebDriverManager webDriverManager)
        {
            _webDriverManager = webDriverManager;
        }

        public LoginPage CreateLoginPage()
        {
            return new LoginPage(_webDriverManager);
        }
        public JourneyPlannerPage CreateJourneyPlannerPage()
        {
            return new JourneyPlannerPage(_webDriverManager);
        }
        public JourneyResultsPage CreateJourneyResultsPage()
        {
            return new JourneyResultsPage(_webDriverManager);
        }
        public EditJourneyPage CreateEditJourneyPage()
        {
            return new EditJourneyPage(_webDriverManager);
        }
    }
}