# NeuroStellar - Igrannonica

Igrannonica je ASP.NET Core veb aplikacija za manipulaciju ve�ta�kim neuronskim mre�ama. Koriste�i aplikaciju, po�etnicima iz oblasti ve�ta�kih neuronskih mre�a se omogu�ava razumevanje samog koncepta preprocesiranja, treniranja i testiranja neuronskih mre�a. S druge strane, ekspertima se pru�a manipulacija setovima podataka uz upotrebu brojnih parametara i mogu�nost istovremenog nadgledanja toka procesa.  

## Opis projekta

###Izvr�avanje eksperimenata
Izvr�avanje eksperimenata je omogu�eno prijavljenim korisnicima i sastoji se iz slede�ih koraka:

####Izbor seta podataka 
U navedenom koraku vr�i se izbor seta podataka iz postoje�ih setova ili po potrebi korisnik mo�e u�itati �eljeni set podataka.

####Pikaz izabranog seta podataka
Nakon izvr�enog izbora seta podataka, korisniku se tabelarno prikazuju u�itani podaci.

####Preprocesiranje
Preprocesiranje se sastoji iz koraka koji korisniku omogu�avaju:  izbor ulaznih kolona i izlazne kolone, uklanjanje gre�ki, uklanjanje nedostaju�ih vrednosti, izbor tipa enkodiranja. Cilj navedenog koraka je uve�anje kvaliteta samog seta podataka. 

####Izbor parametara treniranja
Korisniku se pru�a izbor parametara za treniranje mre�e. Ponu�eni parametri treniranja su:
*Tip problema(vrednosti mogu biti:regresioni, binarno-klasifikacioni, multi-klasifikacioni)
*Broj skrivenih slojeva(celobrojna vrednost)
*Broj neurona skrivenih slojeva(bira se za svaki sloj pojedina�no, celobrojna vrednost)
*Optimizacija(mogu�e vrednosti: Adam, Adadelta, Adagrad, Ftrl, Nadam, SDG, SDGMomentum, RMSProp)
*Funkcija obrade gubitka(vrednosti variraju u zavisnosti od tipa problema)
*Funkcije aktivacije skrivenih slojeva(vrednosti zavise o tipa problema i defini�u se za svaki sloj pojedina�no)
*Funkcija aktivacije izlaznog sloja(izbor zavisi od tipa problema) 
*Izbor metrika(ponu�eni izbor zavisi od tipa problema)

####Treniranje modela
Nakon izbora svih parametara, pru�a se mogu�nost treniranja modela.  

####Pregled rezultata treniranja
Uzev�i u obzir prethodno izabrane metrike, korisniku se prikazuju rezultati treniranja.

####Predvi�anja na osnovu postoje�ih treniranih modela
Nakon treniranja modela, obavlja se njegovo �uvanje u H5 formatu. Samim tim, omogu�ena je ponovna upotreba sa�uvanog modela i vr�i se predikcija za novi set podataka.
  


## Pokretanje aplikacije

### Neophodne komponente

* .NET 6.0
* NodeJS
* MongoDB
* Python

### Instalacija

* Za instalaciju zahtevanih datoteka potrebnih da bi se pokrenuo angular web sajt:
```
npm install -g @angular/cli
cd .\frontend\
npm install
```
* Za instalaciju .NET:
Visual Studio Installer > (Izaberite vasu verziju Visual Studio editora) > Modify > ASP.NET and web development > Modify

### Pokretanje programa

* Frontend
```
ng serve
```
 - za pokretanje na drugom portu:
```
ng serve --port=80
```

* Backend
```
api.sln - start without debugging
```

## Autori

Danijel Anđelković

Ognjen Ćirković

Sonja Galović

Tamara Jerinić

Ivan Ljubisavljević

Nevena Bojović