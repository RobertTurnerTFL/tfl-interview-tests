using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace TestAutomation.Bindings.StepDefinitions
{
    [Binding]
    public class CalculatorAddSteps
    {
        NickCalculator sut;
        decimal total;

        [Given(@"the calculator is on")]
        public void GivenTheCalculatorIsOn()
        {
            sut = new NickCalculator();
        }
        
        [When(@"I add '(.*)' and '(.*)'")]
        public void WhenIAddAnd(Decimal p0, Decimal p1)
        {
            total = sut.Add(p0, p1);
        }
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultsShouldBe(decimal expectedNumber)
        {
            total.Should().Be(expectedNumber);
        }
    }
}
