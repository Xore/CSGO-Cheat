login.php:
	hier sind die hardcoded MySQL Settings und Abfragen, nicht in der Application
	Simple $_GET Seite die Daten per Parameter erhalten aka Username/Password/HWID
	Return true/false -> später halt vielleicht noch n paar andere Sachen aka
	Offsets oder sonst irgendwas (alles erweiterbar)

	

usage:
	EXE ruft mit den eingegeben Daten "login.php?username=USERNAME&password=PASSWORD" auf
	Falls mit den Daten ein User vorhanden ist wird einfach nur true ausgegeben, ansonsten false
	einfach dann auf die Antwort des Servers gucken und abgleichen

	Erweiterbar mit HWID etc alles was man will