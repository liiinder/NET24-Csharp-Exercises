# �vningsuppgifter med n�gra vanliga UI element i WPF

## 1. Klickr�knare

Bygg ett program med en knapp som h�ller reda p� hur m�nga g�nger man klickat p� den.

Det ska st� "Click: X" p� knappen, d�r X �r antalet g�nger man klickat p� knappen.

## 2. R�kna upp och ner i en label.

G�r ett program med en label som initialt visar v�rdet 5. Det ska finna en knapp "Increase" och en knapp "Decrease". Genom att klicka p� knapparna ska man kunna �ka eller minska v�rdet som visas p� label, ett steg i taget. V�rdet ska dock aldrig kunna bli l�gre �n 0, eller h�gre �n 9.

## 3. L�gg till Slider

Uppdatera programmet i uppgift 2 s� att det �ven finns en slider som kan s�ttas fr�n 0 till 9 (i hela steg, allts� endast heltal). Om man flyttar slidern s� kan v�rdet p� labeln �ndras. Observera att knapparna fortfarande ska finnas kvar, fungera som f�rut, och �ven uppdatera slidern.

## 4. Label med valbar position

Skapa ett nytt program med en label som visar sin egen x- och y-position (T.ex: "x = 43, y= 89")

Skapa en slider f�r att st�lla in x-positionen mellan 0-100, och en slider som g�r det samma f�r y-positionen.

N�r man drar i sliders s� ska labelns position uppdateras. D.v.s b�de texten som skrivs i labeln s� den reflekterar valda v�rden p� x och y; och dessutom labelns faktiska position i f�nstret.

***Bonus:*** *L�gg g�rna till en label i anslutning till vardera slider s� att det tydligt framg�r vad varje slider g�r. T.ex: "x-position:", respektive "y-position:"*

## 5. Gemensam slider f�r position

G�r en ny version av programmet i uppgift 4, d�r det nya programmet bara har en slider f�r att v�lja v�rdet. B�de x och y ska s�ttas till v�rdet man valt p� slidern (0-100).

Det ska ocks� finnas tv� checkboxar. En "Lock x-value." och en "Lock y-value". Dessa ska kunna l�sa x- och y-v�rden fr�n att uppdateras. D.v.s om man t.ex klickar i "Lock x-value" och sedan �ndrar v�rdet p� slidern s� ska knappens y-v�rde fortfarande uppdateras, medan x-v�rdet uppdateras f�rst n�r man klickar ur checkboxen igen.

***F�rtydligande:*** *Om man klickar i b�da checkboxar s� ska positionen inte uppdateras alls n�r man �ndrar v�rdet, f�rr�n man klickar ur checkboxarna: d� "hoppar" labeln till sin nya position.*

## 6. Formul�r f�r studenter

Utg� fr�n [XAML-uppgift 8 ("Formul�r f�r studenter")](https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/XAML.md), men ta bort "OK"-knappen.

L�gg till funktionalitet s� att n�r man v�ljer en student i listan s� visas den studentens f�rnamn, efternamn och email i formul�ret till h�ger i f�nstret; och om man uppdaterar n�got i formul�ret s� uppdateras den studenten i listan. 

***OBS!*** *Email visas inte i listan, men beh�ver �nd� lagras s� det nya v�rdet finns kvar n�r man v�xlar mellan studenterna via listan.*

## 7. L�gg till och ta bort studenter

Uppdatera programmet i uppgift 6 med en knapp f�r att l�gga till, och en knapp f�r att ta bort studenter.

Om ingen student �r vald ("selected") i listan s� ska "ta bort"-knappen vara inaktiverad (disabled); annars ska den valda studenten tas bort n�r man klickar p� "ta bort"-knappen.

Om man klickar p� "l�gg till"-knappen s� l�gg till en ny student i listan med f�rnamn "New", och tomma str�ngar f�r efternamn och email.

## 8. L�gg till en meny i programmet

Man kan skapa menyer med [\<Menu\> och \<MenuItem\>](https://wpf-tutorial.com/common-interface-controls/menu-control/).

L�gg till en meny i toppen av student appen med "File" och "Edit".

Under "File" ska det finnas ett "Exit" alternativ som avslutar programmet om man klickar p� den.

Under "Edit" ska det finnas en "Add Student" och en "Remove Student"; dessa ska fungera likadant som knapparna fr�n f�rra uppgiften.

***OBS!*** *Knapparna ska fortfarande finnas kvar och fungera som tidigare. Om ingen student �r markerad i listan s� m�ste b�de "Remove"-knappen, och motsvarande meny-alternativ bli "disabled".*

## 9. L�gg till en context menu i programmet

En [\<ContextMenu\>](https://wpf-tutorial.com/common-interface-controls/contextmenu/) �r den typ av meny som dyker upp n�r man h�gerklickar p� n�got element i programmet.

N�r man h�gerklickar i listan (\<ListBox\>) med studenter s� ska man f� upp en meny med alternativen "Add Student" och "Remove Student".

Det ska allts� finnas ytterligare ett s�tt att l�gga till och ta bort studenter.

***OBS!*** *Alla tre s�tten ska fungera, och alla tre "Remove" m�ste bli enabled/disabled beroende p� om det finns n�gon studenten som �r "selected".*

## 10. Siffror i rutn�t
Skapa ett nytt program, som n�r det startar ser ut ungef�r som [XAML-uppgift 6 ("Siffror i rutn�t")](https://github.com/everyloop/NET24-Csharp/blob/master/Exercises/XAML.md), med skillnaden att det ist�llet �r 10x10 \<Label\>-element med siffrorna 0-99.

## 11. Siffror i rutn�t med dynamisk storlek

L�gg till en slider i programmet ovan som man kan s�tta till heltal fr�n 1 till 10.

N�r v�rdet p� slidern �r 1 visas en label med v�rdet 0. 

N�r v�rdet p� slidern �r 2 visas 4 label i ett 2x2 rutn�t, med v�rden 0-3.

N�r v�rdet p� slidern �r 3 visas 9 label i ett 3x3 rutn�t, med v�rden 0-8.

...

N�r v�rdet p� slidern �r 10 visas 100 label i ett 10x10 rutn�t, med v�rden 0-99.

## 12 Knappar i rutn�t

G�r om programmet i uppgift 10 s� att det anv�nder knappar i st�llet f�r label f�r att visa siffrorna. Initialt ska knapparna visa siffrorna 0-99 p� samma s�tt som i uppgift 10.

Varje g�ng man klickar p� en knapp s� ska siffran r�kna ner med 1. N�r en knapp kommer till 0, och man klickar en g�ng till s� ska knappen b�rja om fr�n det v�rde som den hade n�r programmet startade.

D.v.s. den f�rsta knappen visar alltid 0; den andra knappen v�xlar mellan 1 och 0; den tredje v�xlar 2, 1, 0, och tillbaka till 2. etc. etc.


