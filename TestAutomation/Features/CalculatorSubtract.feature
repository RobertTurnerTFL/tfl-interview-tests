@subtract
Feature: CalculatorSubtract
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of a number subtracted from another number

Scenario: Subtract two numbers
    Given the calculator is on
	When I subtract '50' from '70'
	Then the result should be '20'

	Scenario: Subtract two decimal numbers
	Given the calculator is on
	When I subtract '2.2' from '4.4'
	Then the result should be '2.2'

	Scenario: Subtract two negative numbers
	Given the calculator is on
	When I subtract '-2.2' from '-4.4'
	Then the result should be '-2.2'