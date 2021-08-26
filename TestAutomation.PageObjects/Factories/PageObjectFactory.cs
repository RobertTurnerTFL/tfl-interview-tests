using TechTalk.SpecFlow;
using TestAutomation.Framework.Interfaces;
using TestAutomation.PageObjects.Pages;

namespace TestAutomation.PageObjects.Factories
{
    public class PageObjectFactory : IPageObjectFactory
    {
        private readonly IWebDriverManager _webDriverManager;

        private ScenarioContext _scenarioContext;

        public PageObjectFactory(IWebDriverManager webDriverManager, ScenarioContext scenarioContext)
        {
            _webDriverManager = webDriverManager;
            _scenarioContext = scenarioContext;
        }

        public LoginPage CreateLoginPage()
        {
            return new LoginPage(_webDriverManager);
        }

        public TflPage CreateTflPage()
        {
            return new TflPage(_webDriverManager, _scenarioContext);
        }

        public JourneyResultsPage CreateJourneyResultsPage()
        {
            return new JourneyResultsPage(_webDriverManager, _scenarioContext);
        }

    }
}