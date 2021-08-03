@Add
Feature: CalculatorAdd
	Simple calculator for adding two numbers


Scenario: Add two numbers
	Given the calculator is on
	When I add '50' and '70'
    Then the result should be '120'

	Scenario: Add two Decimal numbers
	Given the calculator is on
	When I add '50.5' and '70.6'
    Then the result should be '121.10'

	Scenario: Add two negative numbers
	Given the calculator is on
	When I add '-50' and '-70'
    Then the result should be '-120'

	Scenario: Add numbers
	Given the calculator is on
	When I add 50 and 70
    Then the result should be 120

	

