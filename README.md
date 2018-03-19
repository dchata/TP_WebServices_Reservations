# TP_WebServices_Reservations

SOAP API en c# (192.168.234.5:53365/ReservationVoiture.svc)
Agrégation : la saisie des paramètres se fait dans l'url du client

Elle est composée de 3 méthodes :
- GetVoitures(username=string, password=string) : renvoie une liste de voitures disponibles
- GetInfosVoiture(username=string, password=string, voitureId=int) : renvoie une voiture avec ses informations 
- ReserverVoiture(username=string, password=string, voitureId=int, dateResaStart=YYYY-MM-DD, dateResaEnd=YYYY-MM-DD) : renvoie un boolean si voiture réservée ou non

Pour chaque méthode il faut saisir des identifiants :

Groupe A : user = webA pass = services
Groupe B : user = webB pass = services
Groupe C : user = webC pass = services
Groupe D : user = webD pass = services
Groupe E : user = webE pass = services
Groupe F : user = webF pass = services
