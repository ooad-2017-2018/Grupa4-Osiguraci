**Adapter pattern**

Omogućava da dva interfaca rade zajedno kao jedan, kada imamo jedan interface i pozivaju se metode a korisnik
očekuje rezultate iz drugog interface-a.
U našem slučaju nije korišten ovaj patern jer nemamo nekih interface-a koji bi radili kao jedan, ali da sada kupimo ili 
dobijemo novi interface koji ima implementirane metode za pretragu, ne bi prepravljali sve postojeće metode nego pomoću adapter 
paterna pozvali preko postojećih metoda nove.

**TemplateMethod pattern**

Omogućava izdvajanje određenih koraka algoritma u odvojene podklase.
Struktura algoritma se ne mijenja - mali dijelovi operacija se izdvajaju i ti se dijelovi mogu implementirati različito.
Nije iskorišten u našem projektu.

**Factory Method pattern**

Uloga Factory Method paterna je da omogući kreiranje objekata na način da podklase odluče koju klasu je instancirati. 
Različite podklase mogu na različite načine implementirati interfejs. 
Nije korišten u našem projektu jer ne postoji dobro mjesto za njegovu upotrebu.

**Strategy pattern**

Izdvaja algoritam iz matične klase i uključuje ga u posebne klase.
Pogodan je kada postoje različiti primjenjivi algoritmi (strategije) za neki problem.
Strategy patern omogućava klijentu izbor jednog od algoritma iz familije algoritama za korištenje.
Algoritmi su neovisni od klijenata koji ih koriste.
Nije iskorišten u našem projektu. 


**Singleton pattern**

Uloga Singleton paterna je da osigura da se klasa može instancirati samo jednom i da osigura globalni pristup kreiranoj instanci klase. 
Postoji više objekata koje je potrebno samo jednom instancirati i nad kojim je potrebna jedinstvena kontrola pristupa.
Nije iskorišten u našem projektu.
          
**State pattern**

Predstavlja dinamičku verziju Strategy paterna.
Objekat mijenja način ponašanja na osnovu trenutnog stanja.
Postiže se promjenom podklase unutar hijerarhije klasa.
Lokalizira svako stanje u posebnu klasu
Uklanja probleme sa razbacanim if iskazima u programu koji bi se koristilli za ispitivanje koje je stanje
Podržava Otvoren-Zatvoren princip.
Nije iskorišten u našem projektu.
