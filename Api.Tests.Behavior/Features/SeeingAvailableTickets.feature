Feature: Seeing available tickets to buy
    As a visitor
    I want to be able to see a tickets i can buy
    So that I can decide if I want to buy it or not
Scenario: Visitor checks the price of ticket
    Given tickets are in db
    When he wants to see available tickets
	Then he can see the details of each ticket