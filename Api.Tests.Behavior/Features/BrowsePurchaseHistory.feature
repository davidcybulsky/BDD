#16
Feature: Browse purchase history
    As a shopper
    I want to be able to check my purchase history
    So that I can analyze what I've bought
Scenario: User can see all products that he's bought
    Given the shopper is on the home page
    When he clicks my account section
    Then he will see all products that he's bought