# SCB - Team blue
Statens statistiska centralbyrås elektroniska undersökningsplattform

Ett program för att administrera/skapa samt besvara undersökningar.

# Admin-läge
* Lägga in undersökning med frågor
* Välja vilken skala frågorna besvaras med 

# Användarläge
* Kod för att access en viss undersökning.
* Svara på frågor.
* Svaren måste vara anonyma, men det ska lagras att en viss användare har svarat på en viss undersökning.


# Arbetsuppdelning
* Ali - Menysystem
* Daniel - Survey
* Ola - Datamanager
* Jennifer - Frågor
* Görgen - User/Roll och User-survey


**Att Ändra**
Datamanager - Dela i två delar, Load/Save Data
Question - Kanske byta titel till något annat?
User - Städa upp properties/metoder, var med konsekvent.
Titta igenom klasser för properties som kan vara private.
Ta en titt på Interfaces, använd till datamangers 


**FELHANTERING**
- Felmedelenade när en questionär kod skrivs in som inte matchar någon survey *FIXED*
- En Survey får inte ha tomt namn *FIXED*
- När du väljer vilken fråga du vill lägga till i en survey kan du välva alternativ som inte existerar *FIXED*
- Kan lägga till tomt frågetitel   *FIXED*
- Kan lägga till tomma 1 till 10 labels *FIXED*
- Multiplechoice option kan ha tomma alternativ *FIXED*
- Programmet crashar om man vill distrubera en survey som inte fins 
- en admin kan skapas med ett tomt lösenord 
- AdminCommands rad 179 behöver try catch om användare mata string program crushar.