#9 
Feature: Adding product to the cart
    As a Shopper
    I want to be able to add product to the cart
    So that I can check my items before making a purchase
Scenario: Shopper adds a product to the cart
    Given the shopper is on the product details page
    When he click "Add" button 
    Then he will see a succesfull message indicating that the products had been added