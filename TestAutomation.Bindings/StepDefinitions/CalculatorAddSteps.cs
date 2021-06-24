using System;
using TechTalk.SpecFlow;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        ElsCalculator sut;
        
        [Given(@"the calulator is on")]
        public void GivenTheCalulatorIsOn()
        {
          
            sut = new ElsCalculator();
        }
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(decimal p0, decimal p1)
        {
            var total = sut.Add(p0, p1);
        }
        

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
