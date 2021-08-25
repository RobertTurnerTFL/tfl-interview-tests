using TechTalk.SpecFlow.Assist;

namespace TestAutomation.Bindings.StepDefinitions
{
    public class JourneyDetails
    {
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public string ErrorMessage { get; set; }

        public const string ToStationErrorMessage = "The To field is required.";

        public const string FromStationErrorMessage = "The From field is required.";

        public const string InvalidValuesToBothFields =
            "Journey planner could not find any results to your search. Please try again";
    }
}