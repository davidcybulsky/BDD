#11
Feature: Removing product from the cart
    As a Shopper
    I want to be able to remove product from my cart
    So that I can change my shopping selection
Scenario: Shopper removes product from the cart
    Given shopper is on the cart page
    When the cart is not empty
    And he selects specific product
    And click remove button
    Then he will view the cart without this product 
