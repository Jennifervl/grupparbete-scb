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
- [ ] Spara i user vilka undersökningar som gjorts som en lista.

**User-Survey**
- [ ] String för kod till undersökning - 
- [ ] Bool för isFInished
- [ ] Metod för att Generera en unik kod för varje user till en undersökning.
