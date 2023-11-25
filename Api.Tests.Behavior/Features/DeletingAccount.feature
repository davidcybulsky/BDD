Feature: Deleting own account
	As a visitor
	I want to be able to delete my account
	So that I it is no longer there
Scenario: Visitor deletes account
	Given the visitor is logged into his account
	And he sees his main profile page
	When he gives instruction to delete his account
	And he agrees that he is sure he wants to delete it
	Then the account is deleted
	And the user is automatically logged out