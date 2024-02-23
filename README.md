# NeuroStellar - Igrannonica

Igrannonica je ASP.NET Core veb aplikacija za manipulaciju veštačkim neuronskim mrežama. Koristeći aplikaciju, početnicima iz oblasti veštačkih neuronskih mreža se omogućava razumevanje samog koncepta preprocesiranja, treniranja i testiranja neuronskih mreža. S druge strane, ekspertima se pruža manipulacija setovima podataka uz upotrebu brojnih parametara i mogućnost istovremenog nadgledanja toka procesa.  

## Opis projekta

**Izvršavanje eksperimenata**
 Izvršavanje eksperimenata je omogućeno prijavljenim korisnicima i sastoji se iz sledećih koraka:

**Izbor seta podataka**
 U navedenom koraku vrši se izbor seta podataka iz postojećih setova ili po potrebi korisnik može učitati željeni set podataka.

**Prikaz izabranog seta podataka**
 Nakon izvršenog izbora seta podataka, korisniku se tabelarno prikazuju učitani podaci.

**Preprocesiranje**
 Preprocesiranje se sastoji iz koraka koji korisniku omogućavaju:  izbor ulaznih kolona i izlazne kolone, uklanjanje greški, uklanjanje nedostajućih vrednosti, izbor tipa enkodiranja. Cilj navedenog koraka je uvećanje kvaliteta samog seta podataka. 

**Izbor parametara treniranja**
 Korisniku se pruža izbor parametara za treniranje mreže. Ponuđeni parametri treniranja su:

- Tip problema(vrednosti mogu biti:regresioni, binarno-klasifikacioni, multi-klasifikacioni)

- Broj skrivenih slojeva(celobrojna vrednost)

- Broj neurona skrivenih slojeva(bira se za svaki sloj pojedinačno, celobrojna vrednost)

- Optimizacija(moguće vrednosti: Adam, Adadelta, Adagrad, Ftrl, Nadam, SDG, SDGMomentum, RMSProp)

- Funkcija obrade gubitka(vrednosti variraju u zavisnosti od tipa problema)

- Funkcije aktivacije skrivenih slojeva(vrednosti zavise o tipa problema i definišu se za svaki sloj pojedinačno)

- Funkcija aktivacije izlaznog sloja(izbor zavisi od tipa problema) 
- Izbor metrika(ponuđeni izbor zavisi od tipa problema)


**Treniranje modela**
 Nakon izbora svih parametara, pruža se mogućnost treniranja modela.  
**Pregled rezultata treniranja**
 Uzevši u obzir prethodno izabrane metrike, korisniku se prikazuju rezultati treniranja.

**Predviđanja na osnovu postojećih treniranih modela**
 Nakon treniranja modela, obavlja se njegovo čuvanje u H5 formatu. Samim tim, omogućena je ponovna upotreba sačuvanog modela i vrši se predikcija za novi set podataka.

  


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
api.sln - start without debugging


## Autori

Danijel Anđelković

Ognjen Ćirković

Sonja Galović

Tamara Jerinić

Ivan Ljubisavljević

Nevena Bojović
