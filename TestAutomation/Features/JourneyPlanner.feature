Feature: JourneyPlanner

#Background step that is shared by all scenarios to reduce duplication.
Background: 
     Given user is on the TfL home page 
		  
Scenario: Plan a journey
	#Given user is on the TfL home page
	When user plans a journey from 'London Victoria' to 'London Bridge'
	Then user should be presented with the Journey Results page with the correct summary
	And user can see the fastest route

Scenario: Edit a journey
	Given user plans a journey from 'London Victoria' to 'London Bridge'
	When user changes the destination to 'Waterloo'
	Then user should be presented with the Journey Results page with the correct summary
	And user can see the fastest route

Scenario Outline: Invalid field entry
	#Given user is on the TfL home page
	#When user enters text that does not match a station name into the journey planner
	When user tries to enter '<source>' and '<destination>'	
	And user clicks Plan my journey
	Then user should be presented with the Journey Results page with an 'errormessage'
	Examples:
	| source | destination | errormessage                                          |
	| @      | @           | Sorry, we can't find a journey matching your criteria |
	            

Scenario Outline: No destination entered
	#Given user is on the TfL home page
	When user tries to plan a journey with '<source>' and '<destination>'
	Then user sees an error message telling them that the 'The To field is required.'
	Examples:
	| source          | destination |
	| London Victoria |             | 