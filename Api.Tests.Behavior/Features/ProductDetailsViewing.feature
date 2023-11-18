#4
Feature: Product details viewing
    As a Shopper
    I want to view a details of products
    So that I can make better purchase decision

Scenario: Succesfully viewing product details
    Given the shopper is on the Shoppy home page
    When he selects specific product 
    Then he should view product details page
