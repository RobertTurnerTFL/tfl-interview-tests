using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomation.Bindings.Contexts;
using TestAutomation.PageObjects.Factories;
using TestAutomation.PageObjects.Pages;
using TestAutomation.Bindings;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class JourneyPlannerSteps :BaseSteps
    {
        
        //Parameterised Constructor created
        public JourneyPlannerSteps(IPageObjectFactory pageObjectFactory, PageContext pageContext) : base(pageObjectFactory, pageContext)
        {
        }

        [Given(@"user is on the TfL home page")]
        public void GivenUserIsOnTheTfLHomePage()
        {
            PageContext.TfLHomePage = PageObjectFactory.CreateTfLHomePage().Navigate();
           // PageContext.TfLHomePage.ClickAcceptCookiesButton();
        }
        [When(@"user plans a journey from '(.*)' to '(.*)'")]
        [Given(@"user plans a journey from '(.*)' to '(.*)'")]
        public void WhenUserPlansAJourneyFromTo(string source, string destination)
        {
            PageContext.TfLHomePage.InputFromField(source);
            PageContext.TfLHomePage.InputToField(destination);
            PageContext.JourneyResultsPage = PageContext.TfLHomePage.ClickPlanMyJourneyButton();
        }

        [Then(@"user should be presented with the Journey Results page with the correct summary")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithTheCorrectSummary()
        {
            PageContext.JourneyResultsPage.Heading1Text.Should().Be("Journey results");
        }



        [When(@"user changes the destination to '(.*)'")]
        public void WhenUserChangesTheDestinationTo(string destination)
        {
           
            PageContext.JourneyResultsPage.ClickEditJourneyLink();
            PageContext.JourneyResultsPage.InputToField(destination);
            PageContext.JourneyResultsPage.ClickUpdateJourneyButton();
        }

        [When(@"user tries to enter '(.*)' and '(.*)'")]
        public void WhenUserTriesToEnterAnd(string source, string destination)
        {
            PageContext.TfLHomePage.InputFromField(source);
            PageContext.TfLHomePage.InputToField(destination);
            PageContext.TfLHomePage.ClickPlanMyJourneyButton();

        }


        [Then(@"user should be presented with the Journey Results page with an '(.*)'")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithAn(string errormessage)
        {
            PageContext.JourneyResultsPage.BannerText.Should().Contain(errormessage);
        }

        [Then(@"user sees an error message telling them that the '(.*)'")]
        public void ThenUserSeesAnErrorMessageTellingThemThatThe(string errormessage)
        {
            PageContext.TfLHomePage.BannerText.Should().Contain(errormessage);           
            
        }


        //[Given(@"user plans a journey from London Victoria to London Bridge")]
        //[When(@"user plans a journey from London Victoria to London Bridge")]
        //public void GivenUserPlansAJourneyFromLondonVictoriaToLondonBridge()
        //{
        //    PageContext.TfLHomePage.InputFromField();
        //    PageContext.TfLHomePage.InputToField();
        //}
        
        
        //[When(@"user changes the destination to London Waterloo")]
        //public void WhenUserChangesTheDestinationToLondonWaterloo()
        //{
        //    PageContext.JourneyResultsPage.ClickEditJourneyLink();
        //    PageContext.JourneyResultsPage.InputToField();
        //}
        
        
        [When(@"user clicks Plan my journey")]
        public void WhenUserClicksPlanMyJourney()
        {
            PageContext.TfLHomePage.ClickPlanMyJourneyButton();
        }

        [When(@"user tries to plan a journey with '(.*)' and '(.*)'")]
        public void WhenUserTriesToPlanAJourneyWithAnd(string source, string destination)
        {
            Console.WriteLine("Reached here");
            PageContext.TfLHomePage.InputFromField(source);
            Console.WriteLine("Reached here2");
            PageContext.TfLHomePage.ClickPlanMyDestinationNoDestination();
        }
     
        
        [Then(@"user can see the fastest route")]
        public void ThenUserCanSeeTheFastestRoute()
        {
            PageContext.JourneyResultsPage.VerifyFastestRoute();
        }       

        private void GotoJourneyResultsPage()
        {
            PageContext.JourneyResultsPage =
                PageContext.TfLHomePage.ClickPlanMyJourneyButton();
        }
    }
}
