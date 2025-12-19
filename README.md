# AbysaltoWebAPI
Minimalna implementacija jednog Web API servisa za košaricu artikla

# PRIJE POKRETANJA APLIKACIJE
1.Klonirajte projekt u file explorer

# POPULIRANJE BAZE PODATAKA
1.Otvorite PostgreSQL te napravite bazu s imenom "AbysaltoCart"
2.Kliknite desnim klikom na ime baze, odnosno na "AbysaltoCart"
3.Odaberite "Restore" opciju. Nakon toga će vam se otvoriti sučelje za odabir .sql datoteke
4.U drugom retku, pod "Filename", odaberite "AbysaltoDb.sql" datoteku koja se nalazi u root-u projekta
5.Nakon što ste odabrali datoteku, samo kliknite "Restore". Nakon toga će se baza populirati s kreiranim tablicama kao i s nekoliko testnih podataka

# POKRETANJE APLIKACIJA
1.Otvorite klonirani projekt s Visual Studiom
2.Samo kliknite zeleni Run gumb ili pritisnite F5 kako bi pokrenuli aplikaciju
3.Dočekat će vas SwaggerUI s 4 endpointa, 1 POST, 1 GET i 2 DELETE.
4.Kako bi testirali endpointe, prvo ih trebate autorizirazi. Ako ih probate testirati prije autorizacije, dobit će te natrag response "Api key missing".
5.Kako bi proveli autorizaciju, kliknite na gumb "Authorize" u gornjem desnom kutu iznad endpointa.
6.Kopirajte ApiKey unutar vitičastih zagrada, zalijepite ga u text box ispod te kliknite "Authorize". Nakon toga će te moći testirati sve endpointe.

# HEALTHCHECK API-ja
1.Nakon pokretanja API-ja, url će izgledati ovako "localhost:7xxx/swaggerui/index.html".
2.Kako bi ste provjerili zdravlje API-ja, zamijenite taj url s ovim "localhost:7xxx/health", odnosno samo zamijenite "swaggerui/index.html" sa "health".
