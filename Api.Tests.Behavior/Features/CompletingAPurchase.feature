#12
Feature: Completing a purchase
    As a Shopper
    I want to be able to purchase my products based on my cart 
    So that I can finalize my shopping 
Scenario: Shopper completes a purchase
    Given the shopper clicks the purchase button on the cart page
    When he is on the purchase page
    And he completes the necessary payment and shipping information
    And confirms the purchase
    Then the purchased products will be removed from the cart