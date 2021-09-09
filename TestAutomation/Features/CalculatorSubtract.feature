@subtract
Feature: CalculatorSubtract
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Scenario: CalculatorSubtract
	Given the calulator is on
	When I subtract '50' and '20'
	Then the result should be '30'
