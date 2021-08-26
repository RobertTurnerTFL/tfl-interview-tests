using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomation.Bindings.Contexts;
using TestAutomation.PageObjects.Factories;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    // This class and all other binding classes should inherit from BaseSteps
    public class StepDefinitionExample : BaseSteps
    {
        public StepDefinitionExample(IPageObjectFactory pageObjectFactory, PageContext pageContext) : base(pageObjectFactory, pageContext)
        {
        }

        [Given(@"the Login page has been loaded")]
        public void GivenTheLoginPageHasBeenLoaded()
        {
            PageContext.LoginPage = PageObjectFactory.CreateLoginPage().Navigate();
        }

        [Given(@"I have successfully logged in to the Secure Area")]
        public void GivenIHaveSuccessfullyLoggedInToTheSecureArea()
        {
            var username = TestContext.Parameters["ValidUsername"];
            var password = TestContext.Parameters["ValidPassword"];

            LoginToSecureAreaPage(username, password);
        }

        [Given(@"user is on the TfL home page")]
        public void GivenTheTFLHomepageHasBeenLoaded()
        {
            PageContext.JourneyPlannerPage = PageObjectFactory.CreateJourneyPlannerPage().Navigate();
        }

        [When(@"user enters text that does not match a station name into the journey planner")]
        public void WhenUserEnterTextThatDoesNotMatchAStation()
        {
            var fromDestination = TestContext.Parameters["InvalidFromLocation"];
            var toDestination = TestContext.Parameters["InvalidToDestination"];
            EnterJourney(fromDestination, toDestination);
        }
        [When(@"user clicks Plan my journey")]
        public void WhenUserClickPlanMyJourney()
        {
            CLickPlanJourneyButton();
        }

        [When(@"I Logout")]
        public void WhenILogout()
        {
            PageContext.LoginPage = PageContext.SecureAreaPage.LogOut();
        }

        [When(@"user tries to plan a journey without a destination")]
        public void WhenUserPlansJourneyWithNoDestination()
        {
            string fromDestination = TestContext.Parameters["FromDestination"];
            PlanNoDestinationJourney(fromDestination);
        }

        [When(@"user plans a journey from London Victoria to London Bridge")]
        public void WhenUserPlansJourney()
        {
            string fromDestination = TestContext.Parameters["FromDestination"];
            string toDestination = TestContext.Parameters["ToDestination"];
            EnterJourney(fromDestination, toDestination);
            
        }
    
        [When(@"I log in with with the following details:")]
        public void WhenILogInWithWithTheFollowingDetails(Table table)
        {
            var loginDetails = table.CreateInstance<LoginDetails>();

            var username = loginDetails.Username;
            var password = loginDetails.Password;

            LoginToSecureAreaPage(username, password);
        }

        [When(@"I attempt to log in with '(.*)' and '(.*)'")]
        public void WhenIAttemptToLogInWithAnd(string username, string password)
        {
            TestContext.WriteLine($"Attempting log in in with invalid username: {username} and/or password: {password}");

            PageContext.LoginPage.LoginWithInvalidUsernameAndPassword(username, password);
        }

        [Then(@"I should be on a page titled '(.*)'")]
        public void ThenIShouldBeOnAPageTitled(string pageTitle)
        {
            PageContext.SecureAreaPage.Heading2Text.Should().Be(pageTitle);
        }

        [Then(@"the banner should read '(.*)'")]
        public void ThenTheBannerShouldRead(string errorMessage)
        {
            PageContext.LoginPage.BannerText.Should().Contain(errorMessage);
        }

        [Then(@"user sees an error message telling them that the To field is required")]
        public void ThenToErrorFieldShouldRead()
        {
            string errorMessage = "The To field is required.";
            PageContext.JourneyPlannerPage.InputToError.Should().Contain(errorMessage);
        }

        [Then(@"user should be presented with the Journey Results page with an error message")]
        public void ThenUserPresentedJourneyResultsWithError()
        {
            string errorMessage = "Sorry, we can't find a journey matching your criteria";
            PageContext.JourneyResultsPage.ErrorField.Should().Contain(errorMessage);
        }

        [Then(@"I should remain on the Login Page")]
        [Then(@"I should return to the Login Page")]
        public void ThenIShouldRemainOnTheLoginPage()
        {
            PageContext.LoginPage.Heading2Text.Should().Be("Login Page");
        }

        [Then(@"user should be presented with the Journey Results page with the correct summary")]
        public void ThenUserPresentedwithJourneyResult()
        {
            CLickPlanJourneyButton();
            PageContext.JourneyResultsPage.VerifyFromDestinationSummary().Should().Be(TestContext.Parameters["FromDestination"]);
            PageContext.JourneyResultsPage.VerifyToDestinationSummary().Should().Be(TestContext.Parameters["ToDestination"]);
        }

        [Then(@"user can see the fastest route")]
        public void ThenUserCanSeeFastestResult()
        {
            PageContext.JourneyResultsPage.FastestRouteDisplayed.Should().BeTrue();
        }




        private void LoginToSecureAreaPage(string username, string password)
        {
            TestContext.WriteLine($"Logging in with username: {username} and password: {password}");

            PageContext.SecureAreaPage =
                PageContext.LoginPage.LoginWithValidUsernameAndPassword(username, password);
        }

        private void PlanJourney(string fromDestination, string toDestination)
        {
            TestContext.WriteLine($"Planning journey from: {fromDestination} to: {toDestination}");

            PageContext.JourneyResultsPage =
                PageContext.JourneyPlannerPage.PlanAJourneyWithFromAndToDestinations(fromDestination, toDestination);
        }
        private void PlanNoDestinationJourney(string fromDestination)
        {
            TestContext.WriteLine($"Planning journey from: {fromDestination} to:");

            PageContext.JourneyPlannerPage =
                PageContext.JourneyPlannerPage.PlanAJourneyWithNoDestinations(fromDestination);
        }
        private void EnterJourney(string fromDestination, string toDestination)
        {
            TestContext.WriteLine($"Planning journey from: {fromDestination} to:");

            PageContext.JourneyPlannerPage =
                PageContext.JourneyPlannerPage.EnterJourneyLocations(fromDestination, toDestination);
        }

        private void CLickPlanJourneyButton()
        {
            TestContext.WriteLine($"Clicking Plan Journey Button");

            PageContext.JourneyResultsPage =
                PageContext.JourneyPlannerPage.ClickPlanJourneyButton();
        }
    }
}
