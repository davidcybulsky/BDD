#13
Feature: Adding review 
    As a shopper
    I want to be able to add reviews after I purchased the product
    So that other shoppers can make better purchase
Scenario: Shopper adding reviews
    Given the shopper is on the reviews section
    When he clicks Add review 
    And he creates a product review
    And he clicks completes
    Then his opinion will be added to the review section