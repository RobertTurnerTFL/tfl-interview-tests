using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        ElsCalculator sut;
        decimal total;

        [Given(@"the calulator is on")]
        public void GivenTheCalulatorIsOn()
        {
          
            sut = new ElsCalculator();
        }
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(decimal p0, decimal p1)
        {
            total = sut.Add(p0, p1);
        }

        [When(@"I subtract '(.*)' and '(.*)'")]
        public void WhenISubtractAnd(decimal p0, decimal p1)
        {
            total = sut.Subtract(p0, p1); 
        }

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(decimal expectedNumber)
        {
            total.Should().Be(expectedNumber);
        }
    }
}
