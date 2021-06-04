@add
Feature: CalculatorAdd
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add two numbers
    Given the calculator is on
	When I add '50' and '70'
	Then the results should be '120'

	Scenario: Add two decimal numbers
	Given the calculator is on
	When I add '2.2' and '4.4'
	Then the result should be '6.6'

	Scenario: Add two negative numbers
	Given the calculator is on
	When I add '-2.2' and '-4.4'
	Then the result should be '-6.6'