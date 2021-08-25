Feature: JourneyPlanner

Scenario: Plan a journey
	Given user is on the TfL home page
	When user plans a journey from <JourneyFrom> to <JourneyTo>
	Then user should be presented with the Journey Results page with the correct summary of <JourneyFrom> and <JourneyTo>
	And user can see the fastest route

	Examples:
		| JourneyFrom                  | JourneyTo                            |
		| London Victoria Rail Station | London Bridge, London Bridge Station |

Scenario: Edit a journey
	When user plans a journey from <JourneyFrom> to <JourneyTo>
	When user changes the destination to <JourneyTo>
	Then user should be presented with the Journey Results page with the correct summary of <JourneyFrom> and <JourneyTo>
	And user can see the fastest route

	Examples:
		| JourneyFrom                  | JourneyTo                            |
		| London Victoria Rail Station | London Bridge, London Bridge Station |
		|                              | London Waterloo Station              |

Scenario: Invalid field entry
	Given user is on the TfL home page
	When user plans a journey from <JourneyFrom> to <JourneyTo>
	And user clicks Plan my journey
	Then user should be presented with the Journey Results page with an <ErrorMessage>

	Examples:
		| JourneyFrom  | JourneyTo    | ErrorMessage                                                                |
		| notinthelist | notinthelust | Journey planner could not find any results to your search. Please try again |

Scenario: No destination entered
	Given user is on the TfL home page
	When user plans a journey from <JourneyFrom> to <JourneyTo>
	Then user sees an <ErrorMessage> telling them that the To field is required

	Examples:
		| JourneyFrom                  | JourneyTo | ErrorMessage              |
		| London Victoria Rail Station |           | The To field is required. |