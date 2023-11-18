#10
Feature: Checking cart
    As a Shopper
    I want to be able to check my cart
    So that I can see products that I am going to buy
Scenario: Shopper checks the cart
    Given the shopper is on the home page
    When he clicks "Cart" button
    Then he will be navigated to the cart page