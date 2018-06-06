## Refaktoring

U kodu je urađen generalni refaktoring koji je pojednostavio i unaprijedio implementaciju i sam izgled koda u velikoj mjeri.
Kod je postao čitljiviji i dosta pogodniji za sve promjene u budućnosti. Refaktoring je rađen po knjizi za refaktoring, tako 
da prati i primjere obrađene na predavanjima.

Refaktoring uključuje zamjenu svih "magičnih brojeva" varijablama pa je samim tim i jednostavniji za naknadne promjene.
Osnovna prednost odnosno poboljšanje koje se dobija ovim refaktoringom je izmjena stvari vezanih za lokal ili događaj
na jednom mjestu u kodu.

Dodatna zaštita i bolja čitljivost koda postignuta je korištenjem privremenih varijabli. Trudili smo se na što bolji način
imenovati metode i atribute zbog lakšeg razumijevanja koda. Imena atributa i metodi su pisana malim početnim slovom, dok sve
sljedeće riječi počinju sa velikim slovom zbog bolje čitljivosti. 

Također korišteni su try-catch blokovi radi lakše obrade izuzetalka. Izuzetak koristimo kao indikator da je došlo do neke greške.
Potrebno je naglasiti i da su ispoštovane sve metode OOP, što uključuje i sam polimorfizam kojim smo smanjili korištenje if-ova.
Ubaceni su i try-catch blokovi radi lakse obrade izuzetaka. Kao indikator da je doslo do
neke greske koristimo izuzetak. Na kraju, potrebno je naglasiti da smo koristili polimorfizam,
cime smo postigli da smo smanjili koristenje if-ova.
