#19
Feature: Updating products for sale
    As a user
    I want to update information for my product for sale
    So that I can better manage of the produts I am selling
Scenario: Update products for sale
    Given the user is on product mangment page
    When he selects specific product to update
    And he modifies all the information 
    And he clicks save 
    Then he will see updated product