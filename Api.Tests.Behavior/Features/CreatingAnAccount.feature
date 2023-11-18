#1
Feature: Creating an account
    As a User 
    I want to create an account
    So that I can shop on Shoppy

Scenario: User succesfully creates account 
    Given user is on the Shoppy signup page
    When he enters valid email, username and password
    And he clicks signup button
    Then he should be redirected to the login page and should see a succesful account created message 