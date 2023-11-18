#14
Feature: Modyfing review
    As a shopper
    I want to be able to modify my reviews
    So that I can update my opinion 
Scenario: Shopper modifies a review
    Given the shopper has previously written a review
    When the shopper is on the review section
    And clicks Modify a review
    And he will write the new opinion
    And he will click save changes
    Then his opinion will be updated in the review section