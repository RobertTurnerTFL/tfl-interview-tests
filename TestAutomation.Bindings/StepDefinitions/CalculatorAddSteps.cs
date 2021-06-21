using System;
using TechTalk.SpecFlow;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        [Given(@"the calculator is on")]
        public void GivenTheCalculatorIsOn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(Decimal p0, Decimal p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the results should be '(.*)'")]
        public void ThenTheResultsShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
