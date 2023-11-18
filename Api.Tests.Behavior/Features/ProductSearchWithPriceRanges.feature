#6
Feature: Product search with price ranges
    As a shopper
    I want to research for products with specific price range
    So that i can find right items based on my preferences
Scenario: Products searching with price ranges
    Given the shopper is on the Shoppy home page
    When he enters the price range values
    Then he should only view items in between those price ranges