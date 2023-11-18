#17 
Feature: Adding products for sale
    As a user
    I want to be able to add products for sale
    So that I can make money
Scenario: Adding products for sale
    Given the user is on the account section
    When he clicks on product managment
    And he clicks add product for sale
    And he completes all the required information about the product 
    Then his product will be available to buy