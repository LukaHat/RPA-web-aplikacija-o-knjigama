1.	Uvod
1.1	Svrha aplikacije 

Kroz vježbu kolegija Razvoj poslovnih aplikacija radit će se jednostavna aplikacija za knjige koja podržava unos, uređivanje, brisanje, pretragu i opis knjiga u bazi. Aplikacija također, treba omogućiti brisanje i prikaz detalja pojedine knjige. Svaki unos podataka kroz aplikaciju treba uključivati provjeru valjanosti i za brisanje podataka je potrebna posebna potvrda korisnika. 
1.2	Korisnici aplikacije
Aplikaciji će moći pristupiti svi korisnici koji imaju internet i internet preglednik te žele pristupiti svim bitnim informacijama o knjigama na jednom centraliziranom mjestu. 
1.3	Koristi (benefiti) od aplikacije
Stvorit će se jedna centralna baza podataka o knjigama dostupna svima. Korisnici kada budu htjeli potražiti informacije o knjigama neće više morati pretraživati putem Google-a i koristiti više izbora za dobivanje informacija o nekoj knjizi jer će kroz aplikaciju moći dobiti sve potrebne informacije na jednom mjestu. Aplikacija će biti dostupna putem interneta, zahvaljujući tome korisnik ima mogućnost korištenja aplikacije u bilo koje vrijeme. 
2.	Zahtjevi
2.1	Funkcijski zahtjevi

Aplikacija mora omogućiti spremanje, uređivanje, pretraživanje, prikaz, traženje i brisanje knjiga u bazi podataka. 
2.2	Sistemski, hardverski i mrežni zahtjevi
Budući da će aplikacija biti razvijena u ASP.NET Core MVC-u ona treba biti smještena na Microsoft Web poslužitelju (eng. server). Preporučuju se sljedeće hardverske specifikacije:
Minimum četverojezgreni procesor 2.2 GHz
Minimum 30GB RAM memorije
Minimum 1TB prostora
Operativni sustav Windows server 2019. 

2.2.1 Web server
Preporučuje se korištenje Windows Azure-a za hostanje aplikacije.
Windows Azure može hostatii bilo koju ASP.NET Core MVC aplikaciju, uključujući i našu predloženu aplikaciju u ovom dokumentu.Instaliranje je vrlo jednostavno jer je Microsoft odgovoran za dodavanje resursa na poslužitelju za vrijeme visokog prometa. 
Troškovi su minimalni, oni ovise o količini podataka koji se prikazuju posjetiteljima te održavanje hardvera nije uključeno u njih.

2.2.2 Baze podataka
Preporučuje se korištenje SQL SERVER baze podataka unutar Windows Azure-a za temeljnu bazu podataka aplikacije. Što se tiče Web poslužitelja, ova preporuka osigurava visoku dostupnost za bazu podataka s dobrim omjerom vrijednosti za uložen novac. To posebno ima smisla ako je I Web aplikacija hostana na Windows Azure-u.
2.3	Sigurnost
U kasnijem razvoju aplikacije razvit će se sigurna identifikacija i zaštićena autentikacija gdje korisnička imena i lozinke ne smiju biti spremljena u obična tekstualna polja i datoteke, a ostali podaci korisnika kao što su adresa, telefonski brojevi, brojevi kreditnih kartica neće biti dostupni anonimnim pristupom.
2.4	Korisnički zahtjevi
Tablica. Korisnički zahtjevi
Rb.	Zahtjev	Vrsta korisnika (user / admin)
1.	Prikaz svih knjiga	Anonimni korisnik
2. 	Pretraga knjiga po žanru i naslovu	Anonimni korisnik
3.	Unos knjige	Registrirani korisnik
4. 	Uređivanje knjige	Registrirani korisnik
5.	Brisanje knjige	Administrator
6.	Provjera valjanosti podataka kod unosa i uređivanja	Registrirani korisnik
7.	Potvrda s pitanjem “Jeste li sigurni?” kod brisanja knjige	Administrator
8.	Prikaz detalja pojedine knjige	Anonimni korisnik
9.	Početna stranica dolaska na aplikaciju mora sadržavati osnovne informacije o svrsi aplikacije	Anonimni korisnik


2.5	Slučajevi (scenariji) korištenja (use-case dijagrami) 
Sljedeći slučajevi korištenja opisuju scenarije u kojima korisnici web aplikacije koriste predloženu aplikaciju za upravljanje knjigama. U tim slučajevima korištenja su uključene osnovne operacije, stoga ih ne treba smatrati konačnim. Kako napreduje razvoj dodatna funkcionalnost može biti dodana prema odluci SCRUM mastera.

2.5.1. Slučaj korištenja 1: Pregled knjiga	
Kada posjetitelj stranice pregledava knjige koji se nalaze u web aplikaciji, odvijaju se sljedeći koraci:
1.	Posjetitelj dolazi na početnu stranicu web mjesta kao anonimni korisnik ili klikne na link Početna stranica u izborniku ako se nalazio na drugoj stranici na istom web mjestu.
2.	Početna stranica prikazuje osnovni opis web aplikacije i sadrži gumbe za prikaz, pretraživanje i dodavanje novih knjiga. 
3.	Prikaz osnovnih informacija o razvojnom timu moguće je dobiti putem stranica O nama i Kontakt.
4.	Ako anonimni korisnik želi vidjeti sve knjige u bazi, mora kliknuti na link Popis knjiga u glavnom izborniku ili gumb prikaži na Početnoj stranici.
5.	Web aplikacija prikazuje popis knjiga. Za svaku knjigu se prikazuje Naziv knjige, Ime Autora, Godina izlaska knnjige, Žanr te Cijena.
6.	Ako anonimni korisnik želi pretraživati Knjige u bazi po Žanru i Nazivu, mora kliknuti na link Tražilica knjiga u glavnom izborniku.
7.	 Ako anonimni korisnik želi vidjeti detalje knjige, mora kliknuti na link Detalji za tu knjigu.
8.	Web aplikacija prikazuje detalje odabranog knjiga –Naziv knjige, Datum izlaska knjige, Žanr te Cijenu.
2.5.2.	Slučaj korištenja 2: Dodavanje nove knjige
Svi korisnici trebaju moći dodati novu knjigu. Kada korisnik dodaje novu knjigu, sljedeći koraci se odvijaju:
1.	Korisnik klikne na gumb Unos na Početnoj stranici ili na link Nova knjiga na stranicama Popis knjiga ili Tražilica knjiga.
2.	Korisnik upisuje podatke o novoj knjizi.
3.	Korisnik klikne na gumb Spremi.
4.	Ako su upisani podaci ispravni, web aplikacija sprema knjigu u bazu i vraća korisnika na stranicu Popis knjiga.
2.5.3.	 Slučaj korištenja 3: Uređivanje knjige

Kada korisnik uređuje knjigu, sljedeći koraci se odvijaju:
1.	Korisnik klikne na link Uredi u popisu knjiga na stranicama Popis knjiga ili  Tražilica knjiga.
2.	Korisnik mijenja postojeće podatke o knjizi.
3.	Korisnik klikne gumb Spremi promjene.
4.	Ako su upisani podaci točni, web aplikacija sprema promjene u bazi i prikazuje stranicu za Popis knjiga.

2.5.4.	Slučaj korištenja 4: Brisanje knjiga
Kad korisnik briše knjige iz baze podataka web aplikacije, sljedeći koraci se odvijaju:

1.	Korisnik klikne na link Obriši u popisu knjiga na stranicama Popis knjiga ili  Tražilica knjiga.
2.	Web aplikacija zahtijeva potvrdu o brisanju knjiga.
3.	Ako korisnik potvrđuje brisanje, knjiga je uklonjen iz baze.
4.	Web aplikacija prikazuje stranicu Popis knjiga.







