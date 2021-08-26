using TestAutomation.PageObjects.Pages;

namespace TestAutomation.Bindings.Contexts
{
    public class PageContext
    {
        public LoginPage LoginPage { get; set; }
        public SecureAreaPage SecureAreaPage { get; set; }
        public TflPage TflPage { get; set; }
        public JourneyResultsPage JourneyResultsPage { get; set; }

    }
}
