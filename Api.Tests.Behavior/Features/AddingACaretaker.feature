Feature: Adding a caretaker
 As a administrator
 I want to be able to add new caretaker
 So that I can keep him/her
Scenario: Administrator adds a caretaker
 Given an administrator is logged in
 And he sees a list of that caretakers
 When he gives instruction to go to page for adding caretaker
 And he enters information about that caretaker
 And he gives instruction to add that caretaker
 Then the caretaker will be added to list