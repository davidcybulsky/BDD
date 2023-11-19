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
**Feature: Logging in** 
    As a visitor
    I want to be able to log in
    So that I can purchase tickets and see my tickets
Scenario: Visitor logs in
    Given the visitor is not logged in
    When he enters correct email and password 
    And he gives instruction to login
    Then he will be logged in
