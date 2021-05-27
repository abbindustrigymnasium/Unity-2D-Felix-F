# CityRunner
## Inledning

##### *Why did the programmer quit his job? Because he didn't get arrays (a raise).* 
Nu när jag gjort en intresseväckande inleding kan jag börja beskriva projektet.

I det här projektet har jag byggt ett 2D spel som liknar många andra "infinite runner" spel. I spelet springer min karaktär fårn vänster till höger i en omgivnig där målet är att springa så långt som möjligt och plocka upp så mycket pengar som möjligt på vägen. Mina personliga mål inför projektet var att bli bättre på C# och lära mig hur "procedural generation" fungerar då jag tycker att det är en rolig "mechanic" i spel. Jag hade lite förkunskap med unity men med projektet känner jag mig nu helt bekväm med 2D element i unity. 

## Djupare beskrivning

Karaktären i spelet kan "slidea", hoppa och dubbelhoppa. Karaktären springer även konstant åt höger. Det svåraste med rörelsen i spelet var att få dubbelhoppet att fungera. Lösningen jag hamnade på tillslut var att göra en groundcheck som kontrollerar en float som höjs varje gång man gör det första hoppet och sänks efter andra hoppet vilket hindrar ett tredje hopp. KEdjan terställs sedan när man nuddar marken. Ett annat problem var att få animationerna att byta till rätt animation beroende på vad man ger för inputs. Jag löste det men en hel del värden som kontrolleras men det finns fortfarande en bugg kvar i spelet där karaktären fastnar i första hopp animationen som jag inte hann lösa. 
Bakgrunden i spelet har även en parallax effekt som gör att den känns något 3-dimensionell även om det bara är 3 stillbilder jag skapade som rör sig i olika hastigheter jämfört med kameran. Om parallaxen är toppingen på tårtan så är väl min "procedural generation" hela kakan som projektet är byggt runt. Det tog ett tag att implimentera men nu genererar den en av tre olika "tiles" eller "chunks" så det är bara att skapa fler chunks och lägga till dem i scriptet så kan jag göra spelet hur varierat som helst.
Det sista jag la till var det riktiga "icing on the cake", post processing. Jag försökte få spelet att se ut som om det var spelat på en äldre TV med en avrundad skärm och "film grain" noise. Jag la även till motionblur som gör att spelet känns mer "smooth". 

## Avslut

Jag är väldigt nöjd med vad jag har åstakommit och jag tycker att jag uppnått mina ursprungliga mål. Spelet blev kul och utanande och jag fick utveckla min kunskap inom unity och C#. Det krävdes mycket tålamod och många timmar men då jag kunde följa min planner hela vägen gick det alltid framåt. Det var ett väldigt roligt och givande projekt där jag lärde mig väldigt mycket och hade kul på vägen och jag gör gärna ännu fler liknande projekt. 
