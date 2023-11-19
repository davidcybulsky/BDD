Feature: Seeing my tickets
    As a visitor
    I want to be able to see my tickets
    So that I can see them
Scenario: Visitor checks his tickets
    Given the visitor is logged in
    When he gives instruction to see his tickets
    Then his tickets will be displayed