Feature: JourneyPlanner
Background: 
	Given user is on the TfL home page
	And the Tfl home page has loaded successfully

Scenario: Plan a journey
	When user plans a journey
	| FromStation     | ToStation     |
	| London Victoria | London Bridge |
	And user clicks Plan my journey
	Then user should be presented with the Journey Results page with the correct summary
	And user can see the fastest route
	
Scenario: Plan a journey Public Transport Faster
	When user plans a journey
	| FromStation     | ToStation    |
	| London Victoria | East Croydon |
	And user clicks Plan my journey
	Then user should be presented with the Journey Results page with the correct summary
	And user can see the fastest route

Scenario: Edit a journey
	Given user plans a journey 
		| FromStation     | ToStation     |
		| London Victoria | London Bridge |
	And user clicks Plan my journey
	And user should be presented with the Journey Results page with the correct summary
	When user changes the destination to 'London Waterloo'
	And user clicks Plan my journey in Edit Journey 
	Then user should be presented with the Journey Results page with the correct summary
	And user can see the fastest route

Scenario: Invalid field entry
	When user enters text that does not match a station name into the journey planner
	| FromStation | ToStation |
	| 5345        | 46436     |
	And user clicks Plan my journey
	Then user should be presented with the Journey Results page with an error message

Scenario: No destination entered
	Given user plans a journey from '<FromStation>'
	And user should remain on the TFL Home Page when user clicks on Plan my journey
	Then user sees an error message telling them that the to field is required
	Examples: 
		| FromStation     | 
		| London Victoria |

Scenario: No Source entered
	Given user plans a journey to '<ToStation>'
	And user should remain on the TFL Home Page when user clicks on Plan my journey
	Then user sees an error message telling them that the from field is required
	Examples: 
		| ToStation       | 
		| London Victoria | 