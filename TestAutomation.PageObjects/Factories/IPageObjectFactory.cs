using TestAutomation.PageObjects.Pages;

namespace TestAutomation.PageObjects.Factories
{
    public interface IPageObjectFactory
    {
        LoginPage CreateLoginPage();
        TflPage CreateTflPage();
        JourneyResultsPage CreateJourneyResultsPage();
    }
}