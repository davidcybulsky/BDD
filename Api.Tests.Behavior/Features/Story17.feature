Feature: Removing a caretaker
 As a administrator
 I want to be able to remove caretaker
 So that I can remove it
Scenario: Administrator removes an animal
  Given administrator is logged in
 And he sees a list of caretakers
 When he gives instruction to remove specific caretaker
 And he agrees that he is sure he wants to do it
 Then the caretaker will be removed from the list