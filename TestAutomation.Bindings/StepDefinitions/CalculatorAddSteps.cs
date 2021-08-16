using System;
using TechTalk.SpecFlow;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        KawaljitCalculator SUT;

        [Given(@"the calculator is on")]
        public void GivenTheCalculatorIsOn()
        {
            SUT = new KawaljitCalculator();
        }
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(int firstNumber, int secondNumber)
        {
            int result;
            result = SUT.Add(firstNumber, secondNumber);
        }
       
        //[When(@"I add '(.*)' and '(.*)'")]
        //public void WhenIAddAnd(Decimal p0, Decimal p1)
        //{
        //    ScenarioContext.Current.Pending();
        //}
              
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }       
    }
}
