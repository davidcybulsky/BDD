Feature: Seeing all tickets of all visitors
	As a administrator
	I want to be able to see all tickets of all visitors
	So that I know what are those
Scenario: Administrator checks all tickets of all visitors
	Given administrator is on site
	When he gives instruction to only see all tickets of all visitors
	Then the list of all tickets of all visitors will be displayed