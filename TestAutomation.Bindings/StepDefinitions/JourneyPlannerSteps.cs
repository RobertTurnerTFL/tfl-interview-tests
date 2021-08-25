using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomation.Bindings.Contexts;
using TestAutomation.PageObjects.Factories;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class JourneyPlannerSteps : BaseSteps
    {
        public JourneyPlannerSteps(IPageObjectFactory pageObjectFactory, PageContext pageContext) : base(pageObjectFactory, pageContext)
        {
        }
        [Given(@"user is on the TfL home page")]
        public void GivenUserIsOnTheTfLHomePage()
        {
            PageContext.JourneyPlannerPage.TransportForLondonText.Should().Be("Transportfor London");
        }

        [When(@"user plans a journey from (.*) to (.*)")]
        public void WhenUserPlansAJourneyFromTo(string journeyFrom, string journeyTo)
        {
            PageContext.JourneyPlannerPage.EnterInputFrom(journeyFrom);
            PageContext.JourneyPlannerPage.EnterInputTo(journeyTo);
            PageContext.JourneyPlannerPage.ClickOnPlanMyJourneyButton();
        }


        [When(@"user plans a journey from London Victoria to London Bridge")]
        public void WhenUserPlansAJourneyFromLondonVictoriaToLondonBridge()
        {
            PageContext.JourneyPlannerPage.ClickOnPlanMyJourneyButton();
        }

        [When(@"user changes the destination to London Waterloo")]
        public void WhenUserChangesTheDestinationToLondonWaterloo()
        {

        }

        [When(@"user enters text that does not match a station name into the journey planner")]
        public void WhenUserEntersTextThatDoesNotMatchAStationNameIntoTheJourneyPlanner()
        {

        }

        [When(@"user clicks Plan my journey")]
        public void WhenUserClicksPlanMyJourney()
        {

        }

        [When(@"user tries to plan a journey without a destination")]
        public void WhenUserTriesToPlanAJourneyWithoutADestination()
        {

        }
        [Then(@"user should be presented with the Journey Results page with the correct summary of (.*) and (.*)")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithTheCorrectSummaryOfAnd(string journeyFrom, string journeyTo)
        {
            PageContext.JourneyPlannerPage.JourneyResultsText.Should().Be("Journey results");
            PageContext.JourneyPlannerPage.ValidateInputFromAndToInJourney(journeyFrom, journeyTo);

        }
        [When(@"user changes the destination to (.*)")]
        public void WhenUserChangesTheDestinationTo(string journeyTo)
        {

            PageContext.JourneyPlannerPage.EnterInputTo(journeyTo);
        }


        [Then(@"user can see the fastest route")]
        public void ThenUserCanSeeTheFastestRoute()
        {
            PageContext.JourneyPlannerPage.CyclingOptionText.Should().Be("Cycling and other options");
            PageContext.JourneyPlannerPage.FastestPublicTransportText.Should().Be("Fastest by public transport");
        }
        [Then(@"user should be presented with the Journey Results page with an (.*)")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithAn(string errorMessage)
        {
            PageContext.JourneyPlannerPage.ErrorMessageText.Should().Be(errorMessage);
        }

        [Then(@"user sees an (.*) telling them that the To field is required")]
        public void ThenUserSeesAnTellingThemThatTheToFieldIsRequired(string errorMessage)
        {
            PageContext.JourneyPlannerPage.ErrorMessageInputToText.Should().Be(errorMessage);
        }

    }
}
