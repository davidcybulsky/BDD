#20
Feature: Removing products for sale
    As a user
    I want to be able to remove my products from sale
    So that I can better manage of products I am selling
Scenario: Adding products for sale
    Given the user is on the product managment page
    When the user selects specific product
    And click remove product
    Then product will be removed from sale