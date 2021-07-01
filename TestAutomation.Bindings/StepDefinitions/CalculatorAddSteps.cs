using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        Calculator sut;
        decimal total;

        [Given(@"the calculator is on")]
        public void GivenTheCalculatorIsOn()
        {
            sut = new Calculator();   
        }
       
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(decimal p0, decimal p1)
        {
            total = sut.Add(p0, p1);  
        }        
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(decimal expectedNumber)
        {
            total.Should().Be(expectedNumber);
        }
    }
}
