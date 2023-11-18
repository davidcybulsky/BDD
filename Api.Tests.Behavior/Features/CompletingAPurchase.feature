#12
Feature: Completing a purchase
    As a Shopper
    I want to be able to purchase my products based on my cart 
    So that I can finalize my shopping 
Scenario: Shopper completes a purchase
    Given the shopper clicks purchase button in the cart page
    When he is on the purchase page
    And he completes the neccaessary payment and shipping information
    And confirms the purchase
    Then the purchased products will be removed from the cart