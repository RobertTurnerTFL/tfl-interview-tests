using System;
using TechTalk.SpecFlow;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        NickCalculator sut;

        [Given(@"the calculator is on")]
        public void GivenTheCalculatorIsOn()
        {
            sut = new NickCalculator();
        }
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(Decimal p0, Decimal p1)
        {
            decimal d = sut.Add(p0, p1);
        }
        
        [Then(@"the results should be '(.*)'")]
        public void ThenTheResultsShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
