using System;
using TechTalk.SpecFlow;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        Calculator sut;


        [Given(@"the calculator is on")]
        public void GivenTheCalculatorIsOn()
        {
            sut = new Calculator();   
        }
        
       
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(decimal p0, decimal p1)
        {
            var d = sut.Add(p0, p1);  
        }
        
        
     
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
