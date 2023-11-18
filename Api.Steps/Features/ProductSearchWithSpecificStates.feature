#7
Feature: Product Search with Specific States
    As a Shopper
    I want to research products with specific states (new, used)
    So that I can find the right items based on my preferences

Scenario: Shopper searches for products with specific states
    Given the shopper is on the Shoppy home page
    When the shopper selects a specific product state, such as "new"
    Then the shopper should only view items with the selected statee