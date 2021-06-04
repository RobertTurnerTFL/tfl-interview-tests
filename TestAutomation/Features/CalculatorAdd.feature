@add
Feature: CalculatorAdd
	Simple calculator for adding two numbers

Scenario: Add two numbers
	Given the calculator is on
	When I add '50' and '70'
	Then the result should be '120'

Scenario: Add two decimal numbers
	Given the calculator is on
	When I add '2.2' and '4.4'
	Then the result should be '6.6'

	
Scenario: Add two negative numbers
	Given the calculator is on
	When I add '-2.2' and '-4.4'
	Then the result should be '-6.6'

	