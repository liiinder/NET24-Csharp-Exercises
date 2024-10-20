# �vningsuppgifter med dialogrutor

## 1. Meddelande vid uppstart

Anv�nd MessageBox i f�nstrets konstruktor f�r att visa meddelandet "Application is about to start!". Visa ytterligare en MessageBox n�r f�nstrets "Loaded"-event triggas d�r du skriver "Application started!".

## 2. Fr�ga vid avslut

Lyssna p� f�nstrets "Closing"-event och visa en MessageBox med fr�gan "Are you sure you want to quit?". Om anv�ndaren v�ljer "No", avbryt st�ngning av f�nstret genom att s�tta Cancel = true p� CancelEventArgs-objektet som skickas med n�r eventet triggas.

## 3. App f�r att �ppna och visa textfiler.

Skapa en applikation d�r hela f�nstret best�r av en readonly TextBox. Programmet ska ha en meny med en File->Open som visar en OpenFileDialog, och en File->Exit som avslutar programmet.

N�r anv�ndaren valt en fil i OpenFileDialog s� ska filen l�sas in och visas i TextBoxen.

## 4. Text editor

Uppdatera appen fr�n uppgift 3 s� man �ven kan editera och spara filer.

L�gg �ven till scrollbars p� din TextBox, om du inte redan har det.

Visa filens namn i f�nstrets Title-property; om det finns osparade �ndringar visa en * efter filnamnet. Om det �r en ny text (ej inladdad fr�n fil) visa "Untitled Document" ist�llet f�r filnamnet.

L�gg till f�ljande i menyn:

**File->New**  
Om man har osparade �ndringar, visa en dialogruta som fr�gar om man vill spara f�rst:
- **YES:** Spara filen om den redan har ett filnamn, annars visa en SaveFileDialog. F�rst n�r filen �r sparad, t�m textboxen.
- **NO:** T�m textboxen (och s�tt Title="Untitled Document").
- **CANCEL:** Avbryt, och l�t anv�ndaren forts�tta editera den osparade texten.

**File->Save**  
Om det �r en "Untitled Document", g�r samma som *File->Save As;* annars spara filen med det filnamn den redan har.

**File->Save As**
Visa en SaveFileDialog d�r det f�rvalda filnamnet i dialogboxen �r det namn som filen redan har. (Om det �r en "Untitled Document", visa "Untitled Document.txt" som f�rvalt filnamn).

**Lyssna p� f�nstrets Closing-event.**  
Om det finns osparade �ndringar visa en MessageBox och hantera p� liknande s�tt som n�r man g�r nytt dokument, men avsluta ist�llet programmet.

Grattis, du har gjort en text editor!

***Extra-uppgift:*** *L�gg till en "Edit" meny med alternativ f�r Cut/Copy/Paste och implementera funktionalitet f�r dessa.*

***Extra-uppgift:*** *L�gg till en [\<StatusBar\>](https://wpf-tutorial.com/common-interface-controls/statusbar-control/) l�ngst ner i appen, som visar vilken rad och kolumn textmark�ren befinner sig p�, samt totalt antal tecken i filen.*

## 5. F�rgblandare

Skapa ett nytt program som har en knapp "Choose Color". N�r man klickar p� knappen ska en ny dialogruta �ppnas.

L�gg till ett nytt WPF-f�nster i ditt projekt. Detta ska bli dialogrutan som �ppnas fr�n huvudf�nstret.

G�r dialogrutan lagom stor f�r att f� plats med en \<Rectangle\> som visar den mixade f�rgen; 3 slider som representerar v�rden f�r R�tt, Gr�nt, Bl�tt; samt tv� knappar "Cancel" och "OK".

P� \<Rectangle\> kan du anv�nda properties "Width" och "Height" f�r att s�tta storleken; "Fill" och "Stroke" f�r att s�tta f�rgen p� rektangeln och rektangelns kantlinje. Det finns �ven en "StrokeThickness"-property.

Datorer anv�nder oftast 24-bitars f�rgv�rden, d�r f�rgen mixas av grundf�rgerna R�tt, Gr�nt, och Bl�tt (8 bitar var). Ofta anv�nds �ven ytterligare ett 8-bitas v�rde f�r "Alpha", vilket representerar genomskinlighet. En f�rg med Alpha-v�rde 255 (h�gsta v�rdet) �r helt ogenomskinlig, d.v.s man ser inget av bakgrunden igenom f�rgen. En f�rg med "Alpha"-v�rde 0 syns inte alls, utan man ser bara bakgrunden. �r Alpha-v�rdet 128 s� �r den en 50/50 blandning mellan bakgrunden och t.ex rektangeln som m�las med f�rgen.

Dina 3 \<Slider\> ska allts� representer R�tt, Gr�n, och Bl�tt. Ha g�rna en \<Label\> i anslutning till varje som visar f�r anv�ndaren vilken f�rg det �r. Varje \<Slider\> ska kunna st�llas till heltal fr�n 0 till 255. N�r man �ndrar v�rdet p� n�gon av dem s� ska f�rgen p� rektangeln uppdateras f�r att visa den mixade f�rgen.

I code-behind skapa en "new Color()" med R, G, och B properties satt efter v�rden p� dina 3 \<Slider\>. Kom �ven ih�g att s�tta A-propertyn (alpha) till 255, annars syns inte din f�rg (default 0).

Skapa sedan en "new SolidColorBrush(myColor)" och anv�nd den f�r rektangelns "Fill"-property.

Om du f�tt rektangeln att �ndra f�rg n�r man drar i sliders s� �r du n�stan klar. 

L�gg till en publik SolidColorBrush-property i din dialogbox som returnerar f�rgen, s� att den g�r att l�sa av efter vi st�ngt dialogboxen. Man ska �ven kunna s�tta propertyn s� att de 3 sliders initialisera med r�tt RGB-v�rden, och r�tt f�rg visas i rutan.

G�r s� att knapparna s�tter f�nstrets DialogResult till false respektive true, samt st�nger f�nstret.

## 6. F�rgpalett

Uppdatera huvudf�nstret fr�n uppgift 5 s� att det ist�llet f�r en knapp har en \<StackPanel\> med 8 \<Rectangle\> i.

N�r man klickar p� n�gon av de �tta rektanglarna s� ska dialogrutan f�r att mixa f�rger �ppnas med de inst�llningar som matchar f�rgen p� rektangeln man klickat p�.

Man ska allts� kunna anv�nda programmet f�r att �ndra och st�lla in f�rgerna p� var och en av de �tta rektanglarna s� att anv�ndaren kan skapa en egen palett av f�rger.

## 7. Pixel editor

Uppdatera programmet fr�n uppgift 6.

L�gg till ett rutn�t av 8x8 rektanglar, som visas under paletten.

Om man klickar p� en f�rg i paletten ska den markeras (t.ex med "Stroke" och/eller "StrokeThickness) s� man tydligt ser att den �r vald.

Om man klickar p� en ruta i rutn�tet s� ska den f� samma f�rg som �r markerad i paletten.

Om man h�gerklickar p� en f�rg i paletten s� ska dialogrutan f�r att �ndra f�rgen visas.

Om man �ndrar en f�rg som man redan m�lat med i rutn�tet s� ska alla rutor som anv�nder den f�rgen uppdateras.

Grattis, du har gjort en pixel editor!

***Tips:*** *Anv�nd MouseDown- eller MouseUp-eventet ist�llet f�r Click-eventet, d� den skickar med en MouseButtonEventArgs som du kan anv�nda f�r att kolla vilken knapp man klickade med. Du kan �ven kombinera MouseDown med MouseMove s� man kan h�lla nere musknappen och rita i flera rutor utan att beh�va klicka p� varje.*

***Extra-uppgift:*** *L�gg till en meny d�r man kan ladda in och spara bilderna. Spara i bin�rt format d�r de f�rsta 24 (RGB * 8) byten �r paletten, och de f�ljande 64 (8x8) byten �r palett-index f�r pixlarna. Kom ih�g att Visual Studio har en inbyggd hexeditor om du vill kontrollera inneh�llet i filerna.*

***Extra-uppgift:*** *L�gg till s� man �ven kan se den pixlade bilden i litet format (utan rutn�t) vid sidan av rutn�tet man m�lar i.*