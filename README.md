# TP_WebServices_Reservations

Cette API est en SOAP et a été développée en C#

API : 192.168.234.5:53365

Elle est composée de 3 méthodes :
- GetVoitures(username=string, password=string) : renvoie une liste de voitures disponibles
- GetInfosVoiture(username=string, password=string, voitureId=int) : renvoie une voiture avec ses informations 
- ReserverVoiture(username=string, password=string, voitureId=int, dateResaStart=YYY-MM-DD, dateResaEnd=YYY-MM-DD) : renvoie un boolean si voiture réservée ou non

Pour chaque méthode il faut saisir des identifiants :

Groupe A : user = webA pass = services
Groupe B : user = webB pass = services
Groupe C : user = webC pass = services
Groupe D : user = webD pass = services
Groupe E : user = webE pass = services
Groupe F : user = webF pass = services
