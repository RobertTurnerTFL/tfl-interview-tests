using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomation.Bindings.Contexts;
using TestAutomation.PageObjects.Factories;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class JourneyPlanner : BaseSteps
    {
        public JourneyPlanner(IPageObjectFactory pageObjectFactory, PageContext pageContext) : base(pageObjectFactory, pageContext)
        {
        }

        [StepDefinition(@"user is on the TfL home page")]
        public void GivenUserIsOnTheTfLHomePage()
        {
            PageContext.TflPage = PageObjectFactory.CreateTflPage().Navigate();
        }

        [StepDefinition(@"the Tfl home page has loaded successfully")]
        public void GivenTheTflHomePageHasLoadedSuccessfully()
        {
            PageObjectFactory.CreateTflPage().AcceptCookies();
            PageObjectFactory.CreateTflPage().WaitForPageElements();
        }

        [StepDefinition(@"user plans a journey from '(.*)' to '(.*)'")]
        public void WhenUserPlansAJourneyFromTo(string FromStation, string ToStation)
        {
            PageObjectFactory.CreateTflPage().EnterJourneyDetails("FromStation", FromStation);
            PageObjectFactory.CreateTflPage().EnterJourneyDetails("ToStation", ToStation);
            PageContext.JourneyResultsPage = PageObjectFactory.CreateTflPage().ClickPlanMyJourney();
        }

        [StepDefinition(@"user enters text that does not match a station name into the journey planner")]
        [StepDefinition(@"user plans a journey")]
        public void GivenUserPlansAJourney(Table table)
        {
            var JourneyDetails = table.CreateInstance<JourneyDetails>();
            PageObjectFactory.CreateTflPage().EnterJourneyDetails("FromStation",JourneyDetails.FromStation);
            PageObjectFactory.CreateTflPage().EnterJourneyDetails("ToStation", JourneyDetails.ToStation);
        }


        [StepDefinition(@"user plans a journey from '(.*)'")]
        public void GivenUserPlansAJourneyFrom(string FromStation)
        {
            PageObjectFactory.CreateTflPage().EnterJourneyDetails("FromStation", FromStation);
        }
        
        [StepDefinition(@"user plans a journey to '(.*)'")]
        public void GivenUserPlansAJourneyTo(string ToStation)
        {
            PageObjectFactory.CreateTflPage().EnterJourneyDetails("ToStation", ToStation);
        }
        
        [StepDefinition(@"user clicks Plan my journey")]
        public void WhenUserClicksPlanMyJourney()
        {
            PageContext.JourneyResultsPage = PageObjectFactory.CreateTflPage().ClickPlanMyJourney();
        }

        [StepDefinition(@"user should remain on the TFL Home Page when user clicks on Plan my journey")]
        public void GivenUserShouldRemainOnTheTFLHomePageWhenUserClicksOnPlanMyJourney()
        {
            PageContext.TflPage = PageObjectFactory.CreateTflPage().ClickPlanMyJourneyInvalidFromOrToStation();
        }


        [StepDefinition(@"user should be presented with the Journey Results page with the correct summary")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithTheCorrectSummary()
        {
            PageObjectFactory.CreateJourneyResultsPage().LastBreadCrumbText.Should().Be("Journey results");
            PageObjectFactory.CreateJourneyResultsPage().ValidateJourneyResults();
            PageObjectFactory.CreateJourneyResultsPage().ValidateIfMoreThanOneLocationMatchingFound();
        }

        [StepDefinition(@"user can see the fastest route")]
        public void ThenUserCanSeeTheFastestRoute()
        {
            PageObjectFactory.CreateJourneyResultsPage().ValidateIfFastestRouteIsDisplayed();
        }

        [StepDefinition(@"user should be presented with the Journey Results page with an error message")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithAnErrorMessage()
        {
            PageObjectFactory.CreateJourneyResultsPage().ErrorMessageDisplayedNoResultsFound().Should()
                .Be(JourneyDetails.InvalidValuesToBothFields);
        }

        [StepDefinition(@"user sees an error message telling them that the to field is required")]
        public void ThenUserSeesAnErrorMessageTellingThemThatTheToFieldIsRequired()
        {
            PageObjectFactory.CreateTflPage().GetErrorMessageTo().Should().Be(JourneyDetails.ToStationErrorMessage);
        }

        [StepDefinition(@"user sees an error message telling them that the from field is required")]
        public void ThenUserSeesAnErrorMessageTellingThemThatTheFromFieldIsRequired()
        {
            PageObjectFactory.CreateTflPage().GetErrorMessageFrom().Should().Be(JourneyDetails.FromStationErrorMessage);
        }

        [StepDefinition(@"user changes the destination to '(.*)'")]
        public void WhenUserChangesTheDestinationTo(string ToStation)
        {
            PageContext.JourneyResultsPage = PageContext.JourneyResultsPage.ClickEditJourney();
            PageContext.JourneyResultsPage.EditJourneyDetails("ToStation",ToStation);
        }
        [StepDefinition(@"user clicks Plan my journey in Edit Journey")]
        public void WhenUserClicksPlanMyJourneyInEditJourney()
        {
            PageContext.JourneyResultsPage = PageObjectFactory.CreateJourneyResultsPage().ClickPlanMyJourney();

        }


    }
}
