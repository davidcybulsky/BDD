#5
Feature: Products search
    As a Shopper
    I want to search for a specific product
    So that I can make better purchase decision

Scenario: Succesfully products searching
    Given the shopper is on the Shoppy home page
    When he clicks on the Search bar
    And he enters valid product name
    Then he should view product that he specified
