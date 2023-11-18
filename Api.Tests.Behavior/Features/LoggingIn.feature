#2
Feature: Login user to the Shoppy
    As a User
    I want to login 
    So that I can shop on Shoppy

Scenario: User succesfully login into Shoppy
    Given user is on the Shoppy login page
    When he enters valid username and password
    And he clicks login button
    Then he should be redirected to the Shoppy home page