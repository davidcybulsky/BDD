Feature: Seeing animals of specific enclosure
	As a user
	I want to be able to see animals that live in specific enclosure
	So that I know who lives there
Scenario: User checks animals that live in specific enclosure
	Given user sees list of animals
	When he gives instruction to only see animals of specific enclosure
	Then the list of animals of that enclosure will be displayed