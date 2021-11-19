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


**User**
- [x] Enum för vilken roll användaren har, admin eller user.
- [x] String för personnummer
* User constructor måste ha en Enum och ett personnummer in!

- [ ] Spara i user vilka undersökningar som gjorts som en lista.

**User-Survey**
- [ ] String för kod till undersökning - 
- [ ] Bool för isFInished
- [ ] Metod för att Generera en unik kod för varje user till en undersökning.


**Att Ändra**
Datamanager - Dela i två delar, Load/Save Data
Question - Kanske byta titel till något annat?
User - Städa upp properties/metoder, var med konsekvent.
Titta igenom klasser för properties som kan vara private.
Ta en titt på Interfaces, använd till datamangers 


**FELHANTERING**
- Felmedelenade när en questionär kod skrivs in som inte matchar någon survey
- En Survey får inte ha tomt namn
- När du väljer vilken fråga du vill lägga till i en survey kan du välva alternativ som inte existerar
- Kan lägga till tomt frågetitel
- Multiplechoice option kan ha tomma alternativ
- Programmet crashar om man vill distrubera en survey som inte fins 
- en admin kan skapas med ett tomt lösenord