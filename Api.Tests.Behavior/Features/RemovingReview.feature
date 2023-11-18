#15
Feature: Removing review
    As a shopper
    I want to be able to remove my reviews
    So that I dont want to keep this opinion any longer
Scenario: Shopper removes a review
    Given the shopper has previously written a review
    When the shopper is on the review section
    And clicks Remove my opinion
    Then his opinion will be removed from the review section