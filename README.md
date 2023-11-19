# BDD
### Safari (zoo tylko że nowe)
## Encje
![alt text](https://github.com/davidcybulsky/BDD/blob/main/ENCJE_1.jpg)
![alt text](https://github.com/davidcybulsky/BDD/blob/main/ENCJE_2.jpg)

## Podstrony
Ogólnie to może i jest ich dużo, ale będą bardzo powtarzalne na zasadzie: w przypadku /animal tabelka ze zwierzętami, a /animal/{id} na górze wartości jego pól, a niżej tabelka z jego caretakerami. Można wiadomo dodawać inne podstrony jak wyjdzie w trakcie że trzeba 

**/zoo**

Strona startowa, będą tam godziny otwarcia zoo plus jakaś notka, że istniejemy od 3 lat i to jest bardzo długo i że mamy kaczki

**/login**

Dwa textfieldy – na email i hasło, przycisk „Login”, labelka „Not an user yet?” i obok przycisk „Sign up”

**/register**

Dwa textfieldy i przycisk „Register”

**/animal**

Tytuł „Animals” i tabelka ze zwierzętami, w tej tabelce jedynie najważniejsze info, jak chce się więcej to można kliknąć

**/animal/{id}**

Po kolei „pole: wartość”, a niżej tabelka z caretakerami jego

**/animal/add**

**/animal/update/{id}**

**/user**

To jest lista użytkowników widoczna tylko dla ADMINA

**/user/{id}**

Tutaj powinno móc się dostać z /user, jeżeli jest się adminem, lub jeżeli zwykłym śmiertelnikiem to z jakiegoś przycisku „Your Account” na navbarze, i jeżeli jesteśmy właśnie tym userem to powinniśmy widzieć swoje bilety (a admin może oczywiście widzieć bilety dowolnego usera)

**/caretaker**

Tabelka z opiekunami

**/caretaker/{id}**

Info o opiekunie plus lista zwierząt

**/caretaker/add**

**/caretaker/update/{id}**

**/species**

Lista gatunków

**/species/{id}**

Lista zwierząt należących do tego gatunku

**/tickets**

To jest widoczne tylko dla ADMINA – po prostu lista wszystkich biletów

**/buy**

Tutaj powinna być droplista na to na jaki chcemy enclosure pójść, jakiś sposób wybierania daty, powinna być wyświetlona wtedy cena, i przycisk „Buy”. I możemy tu się dostać tylko jak jesteśmy zalogowani

## Historyjki 
Są trzy role:  
**visitor** – osoba mająca na celu odwiedzenie safari, czyli kupno biletu, zalogowanie się itp.  
**administrator** – osoba która ma dostęp do wszystkiego, czyli jest właścicielem  
**user** – dowolna osoba, co weszła se na stronę 

***#1***  
**Feature: Logging in**  
    &emsp;As a visitor  
    &emsp;I want to be able to log in  
    &emsp;So that I can purchase tickets and see my tickets   
Scenario: Visitor logs in  
    &emsp;Given the visitor is not logged in  
    &emsp;When he enters correct email and password   
    &emsp;And he gives instruction to login  
    &emsp;Then he will be logged in  

**Feature: Signing up**  
     &emsp;As a visitor  
     &emsp;I want to be able to sign up  
     &emsp;So that I can purchase tickets and see my tickets  
Scenario: Visitor signs up  
     &emsp;Given the visitor is not logged in  
     &emsp;When he enters syntactically valid email and password   
     &emsp;And he gives instruction to register  
     &emsp; Then the account will be created  
     &emsp;And visitor will be automatically logged in  

**Feature: Seeing my tickets**  
    &emsp;As a visitor  
    &emsp;I want to be able to see my tickets  
    &emsp;So that I can see them  
Scenario: Visitor checks his tickets  
    &emsp;Given the visitor is logged in  
    &emsp;When he gives instruction to see his tickets  
    &emsp;Then his tickets will be displayed  

**Feature: Seeing the price of a ticket**    
    &emsp;As a visitor  
    &emsp;I want to be able to see a price of the ticket I want to buy  
    &emsp;So that I can decide if I want to buy it or not  
Scenario: Visitor checks the price of ticket  
    &emsp;Given the visitor is logged in  
    &emsp;When he chooses the enclosure he wants to go in  
    &emsp;And he chooses the day   
    &emsp;Then the price of this specific ticket will be displayed  

**Feature: Buying a ticket**  
    &emsp;As a visitor  
    &emsp;I want to be able to buy a ticket  
    &emsp;So that I can go to safari  
Scenario: Visitor buys a ticket  
    &emsp;Given the visitor is logged in  
    &emsp;And he chose the enclosure he wants to go in  
    &emsp;And he chose the day   
    &emsp;When he gives instruction to buy the ticket  
    &emsp;Then the ticket will be added to his account  

**Feature: Returning a ticket**  
    &emsp;As a visitor  
    &emsp;I want to be able to return a ticket  
    &emsp;So that I can return in  
Scenario: Visitor return a ticket  
    &emsp;Given the visitor is logged in  
    &emsp;And he sees his tickets  
    &emsp;When he gives instruction to return some ticket  
    &emsp;Then this ticket will be removed from his account  

**Feature: Seeing animals**  
    &emsp;As a user  
    &emsp;I want to be able to see animals that are currently in safari  
    &emsp;So that I know what animals are there  
Scenario: User checks animals  
    &emsp;Given user is on site  
    &emsp;When he gives instruction to see animals  
    &emsp;Then animals will be displayed  

**Feature: Seeing specific animal**  
    &emsp;As a user  
    &emsp;I want to be able to see info about specific animal  
    &emsp;So that I know something about it  
**Scenario: User checks specific animal**  
    &emsp;Given user sees list of animals  
    &emsp;When he gives instruction to see details of specific animal  
    &emsp;Then the information about that animal will be displayed  

**Feature: Adding an animal**  
    &emsp;As a administrator  
    &emsp;I want to be able to add new animal   
    &emsp;So that I can keep it  
**Scenario: Administrator adds an animal**  
    &emsp;Given administrator is logged in  
   &emsp; And he sees a list of animals  
    &emsp;When he gives instruction to go to page for adding animal  
    &emsp;And he enters information about that animal  
    &emsp;And he gives instruction to add that animal  
    &emsp;Then the animal will be added to list  

**Feature: Updating an animal**  
    &emsp;As a administrator  
    &emsp;I want to be able to update existing animal   
    &emsp;So that I can update it  
**Scenario: Administrator updates an animal**  
    &emsp;Given administrator is logged in  
    &emsp;And he sees a list of animals  
    &emsp;When he gives instruction to go to page for updating animal  
    &emsp;And he enters information about that animal  
    &emsp;And he gives instruction to update that animal  
    &emsp;Then the animal will be updated  

**Feature: Removing an animal**  
    &emsp;As a administrator  
    &emsp;I want to be able to remove animal   
    &emsp;So that I can remove it  
**Scenario: Administrator removes an animal** 
    &emsp;Given administrator is logged in  
    &emsp;And he sees a list of animals  
    &emsp;When he gives instruction to remove specific animal  
    &emsp;And he agrees that he is sure he wants to do it  
    &emsp;Then the animal will be removed from the list  

**Feature: Seeing animals of specific species**  
    &emsp;As a user  
    &emsp;I want to be able to see animals of specific species  
    &emsp;So that I know them  
**Scenario: User checks animals of specific species**  
    &emsp;Given user sees list of animals  
    &emsp;When he gives instruction to only see animals of specific species  
    &emsp;Then the list of animals of that species will be displayed  

**Feature: Seeing caretakers**  
    &emsp;As a user  
    &emsp;I want to be able to see caretakers that currently work on safari  
    &emsp;So that I know what caretakers are there  
Scenario: User checks caretakers  
    &emsp;Given user is on site  
    &emsp;When he gives instruction to see caretakers  
    &emsp;Then caretakers will be displayed  

**Feature: Seeing specific caretaker**  
    &emsp;As a user  
    &emsp;I want to be able to see info about specific caretaker  
    &emsp;So that I know something about him/her  
Scenario: User checks specific caretaker  
    &emsp;Given user sees list of caretakers  
    &emsp;When he gives instruction to see which animals are taken care of by this caretaker  
    &emsp;Then the information about that caretaker will be displayed  

**Feature: Adding a caretaker**  
    &emsp;As a administrator  
    &emsp;I want to be able to add new caretaker  
    &emsp;So that I can keep him/her  
Scenario: Administrator adds a caretaker  
    &emsp;Given administrator is logged in  
    &emsp;And he sees a list of caretakers  
    &emsp;When he gives instruction to go to page for adding caretaker  
    &emsp;And he enters information about that caretaker  
    &emsp;And he gives instruction to add that caretaker  
    &emsp;Then the caretaker will be added to list  

**Feature: Updating a caretaker**  
    &emsp;As a administrator  
    &emsp;I want to be able to update existing caretaker  
    &emsp;So that I can update it  
Scenario: Administrator updates a caretaker  
    &emsp;Given administrator is logged in  
    &emsp;And he sees a list of caretakers  
    &emsp;When he gives instruction to go to page for updating caretaker  
    &emsp;And he enters information about that caretaker  
    &emsp;And he gives instruction to update that caretaker  
    &emsp;Then the caretaker will be updated  

**Feature: Removing a caretaker**  
    &emsp;As a administrator  
    &emsp;I want to be able to remove caretaker  
    &emsp;So that I can remove it  
Scenario: Administrator removes an animal  
   &emsp; Given administrator is logged in  
    &emsp;And he sees a list of caretakers  
    &emsp;When he gives instruction to remove specific caretaker  
    &emsp;And he agrees that he is sure he wants to do it  
    &emsp;Then the caretaker will be removed from the list  
    
**Feature: Seeing animals of specific enclosure**  
    &emsp;As a user  
    &emsp;I want to be able to see animals that live in specific enclosure  
    &emsp;So that I know who lives there  
Scenario: User checks animals that live in specific enclosure  
    &emsp;Given user sees list of animals  
    &emsp;When he gives instruction to only see animals of specific enclosure  
    &emsp;Then the list of animals of that enclosure will be displayed  
    
**Feature: Deleting own account**  
    &emsp;As a visitor  
    &emsp;I want to be able to delete my account  
    &emsp;So that I it is no longer there  
Scenario: Visitor deletes account  
    &emsp;Given a visitor is logged in  
    &emsp;And he sees his profile page  
    &emsp;When he gives instruction to delete his account  
    &emsp;And he agrees that he is sure he wants to do it  
    &emsp;Then the account is deleted  
    &emsp;And the user is automatically logged out  

**Feature: Seeing all tickets of all visitors**  
    &emsp;As a administrator  
    &emsp;I want to be able to see all tickets of all visitors  
    &emsp;So that I know what are those  
Scenario: Administrator checks all tickets of all visitors  
    &emsp;Given administrator is on site  
    &emsp;When he gives instruction to only see all tickets of all visitors  
    &emsp;Then the list of all tickets of all visitors will be displayed  
