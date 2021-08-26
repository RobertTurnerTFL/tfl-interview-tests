using TestAutomation.PageObjects.Pages;

namespace TestAutomation.Bindings.Contexts
{
    public class PageContext
    {
        public LoginPage LoginPage { get; set; }
        public SecureAreaPage SecureAreaPage { get; set; }
        public JourneyPlannerPage JourneyPlannerPage { get; set; }
        public JourneyResultsPage JourneyResultsPage { get; set; }
        public EditJourneyPage EditJourneyPage { get; set; }

    }
}
