# Tower-Defense-Game

Tipul Jocului: Tower Defense   
Echipa: 10

## Prezentare Generală

Acest proiect își propune să creeze un joc de apărare cu turnuri în 3D, cu mecanici și caracteristici dinamice. Jocul este proiectat în jurul conceptului de apărare a teritoriului, unde jucătorii trebuie să construiască, să upgradeze turnuri și să își gestioneze strategic resursele pentru a-și proteja orașul de valuri tot mai puternice de inamici.

## Progresul în Joc

### Orașe

- Jocul se desfășoară pe o hartă 3D cu mai multe orașe, fiecare reprezentând o grupare de nivele.
- Jucătorii trebuie să termine un oraș pentru a debloca unul sau mai multe orașe noi.
- Diverse orașe au diferite grade de dificultate:
  - Orașe mici (ideale pentru tutoriale și prezentarea de funcționalități)
  - Orașe medii (niveluri obișnuite)
  - Orașe mari (orașe capitale, niveluri de tip boss-battle)

### Nivele

- Fiecare oraș este compus din mai multe nivele (un mod de reutilizare a hărților).
- Un nivel reprezintă un grup de etape/valuri și acționează ca un checkpoint la care jucătorul poate să revină.
- Nivelul următor începe cu resursele și configurația din nivelul anterior.

## Progresul în Etape

- La începutul fiecărui nivel, jucătorul are la dispoziție 5-7 minute pentru a-și pregăti orașul.
- După perioada de pregătire, inamicii încep să apară.
- După ce toți inamicii sunt înfrânți, se pregătește valul următor.
- În valurile ulterioare, jucătorul are doar 1-2 minute pentru pregătire.
- Ciclul continuă până când jucătorul este învins sau se atinge un număr specific de etape.

## Caracteristici ale Inamicilor

- Inamicii devin din ce în ce mai numeroși și mai puternici pe parcursul jocului.
- Inamicii au abilitatea de a:
  - Distruge orice tip de clădire în oraș.
  - Alege singuri traseul, schimbându-l dacă este blocat (în funcție de inteligența inamicului).
  - Se adapta în timp la dificultățile întâlnite (ex. capătă rezistență la anumite turnuri).

## Funcționalități în Dezvoltare

Există funcționalități care se vor defini pe măsură ce se lucrează la ele și încă nu sunt complet definite în descrierea jocului:

- Diverse tipuri de turnuri cu abilități unice.
- Tipuri variate de resurse pentru joc.
- Penalități pentru clădirile distruse.
