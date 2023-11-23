Feature: Updating a caretaker
 As a administrator
 I want to be able to update existing caretaker
 So that I can update it
Scenario: Administrator updates a caretaker
 Given the administrator is logged in
 And he sees the list of that caretakers
 When he gives instruction to go to page for updating caretaker
 And he enters some information about that caretaker
 And he gives instruction to update that caretaker
 Then the caretaker will be updated