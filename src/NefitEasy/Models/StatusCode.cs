namespace NefitEasy.Models
{
    public class StatusCode
    {
        public string DisplayCode { get; }

        public int CauseCode { get; }

        public string Description
        {
            get
            {
                if (DisplayCode == "-A" && CauseCode == 208)
                {
                    return "Het cv-toestel bevindt zich in schoorsteenvegerbedrijf of in servicebedrijf.";
                }
                if (DisplayCode == "-H" && CauseCode == 200)
                {
                    return "Het cv-toestel bevindt zich in cv-bedrijf.";
                }
                if (DisplayCode == "=H" && CauseCode == 201)
                {
                    return "Het cv-toestel bevindt zich in warmwaterbedrijf.";
                }
                if (DisplayCode == "0A" && CauseCode == 202)
                {
                    return "Het cv-toestel wacht. Er is vaker dan 1x per 10 minuten een warmtevraag van een aan/uit- of een ModuLine-regeling geweest.";
                }
                if (DisplayCode == "0A" && CauseCode == 305)
                {
                    return "Het cv-toestel wacht na einde warmwaterbedrijf.";
                }
                if (DisplayCode == "0A" && CauseCode == 353)
                {
                    return "Het cv-toestel wacht. Het cv-toestel is binnen 24 uur nooit langer dan 20 minuten uit geweest.";
                }
                if (DisplayCode == "0C" && CauseCode == 283)
                {
                    return "Het cv-toestel  bereidt zich voor op een branderstart. De ventilator en de pomp worden aangestuurd.";
                }
                if (DisplayCode == "0E" && CauseCode == 265)
                {
                    return "Het cv-toestel wacht. Het cv-toestel schakelt geregeld in op laaglast om aan de warmtevraag te voldoen.";
                }
                if (DisplayCode == "0H" && CauseCode == 203)
                {
                    return "Het cv-toestel staat stand-by.";
                }
                if (DisplayCode == "0L" && CauseCode == 284)
                {
                    return "Het gasregelblok wordt aangestuurd.";
                }
                if (DisplayCode == "0P" && CauseCode == 205)
                {
                    return "Het cv-toestel wacht op het schakelen van de luchtdrukschakelaar.";
                }
                if (DisplayCode == "0U" && CauseCode == 270)
                {
                    return "Het cv-toestel wordt opgestart.";
                }
                if (DisplayCode == "0Y" && CauseCode == 204)
                {
                    return "Het cv-toestel wacht. De gemeten aanvoertemperatuur is hoger dan de berekende of ingestelde cv-watertemperatuur.";
                }
                if (DisplayCode == "0Y" && CauseCode == 276)
                {
                    return "De aanvoertemperatuursensor heeft een temperatuur gemeten die hoger is dan 95 ºC.";
                }
                if (DisplayCode == "0Y" && CauseCode == 277)
                {
                    return "De safetytemperatuursensor heeft een temperatuur gemeten die hoger is dan 95 ºC.";
                }
                if (DisplayCode == "0Y" && CauseCode == 285)
                {
                    return "De retourtemperatuursensor heeft een temperatuur gemeten die hoger is dan 95 ºC.";
                }
                if (DisplayCode == "0Y" && CauseCode == 359)
                {
                    return "De warmwatertemperatuursensor heeft een te hoge temperatuur gemeten.";
                }
                if (DisplayCode == "1A" && CauseCode == 316)
                {
                    return "De rookgastemperatuursensor heeft een te hoge temperatuur gemeten.";
                }
                if (DisplayCode == "1C" && CauseCode == 210)
                {
                    return "De rookgasthermostaat heeft een te hoge temperatuur gemeten en staat geopend.";
                }
                if (DisplayCode == "1P" && CauseCode == 346)
                {
                    return "De temperatuur van de rookgastemperatuursensor stijgt te snel.";
                }
                if (DisplayCode == "1U" && CauseCode == 317)
                {
                    return "De contacten van de rookgastemperatuursensor zijn kortgesloten.";
                }
                if (DisplayCode == "1Y" && CauseCode == 318)
                {
                    return "De contacten van de rookgastemperatuursensor zijn onderbroken.";
                }
                if (DisplayCode == "2A" && CauseCode == 343)
                {
                    return "Tijdens cv-bedrijf: de rookgastemperatuursensor meet een temperatuurstijging, maar de aanvoertemperatuursensor niet.";
                }
                if (DisplayCode == "2A" && CauseCode == 344)
                {
                    return "Tijdens warmwaterbedrijf: de rookgastemperatuursensor meet een temperatuurstijging, maar de aanvoertemperatuursensor niet.";
                }
                if (DisplayCode == "2C" && CauseCode == 348)
                {
                    return "Tijdens warmwaterbedrijf: de aanvoertemperatuur is hoger dan 85 ºC.";
                }
                if (DisplayCode == "2E" && CauseCode == 207)
                {
                    return "De cv-waterdruk is te laag.";
                }
                if (DisplayCode == "2E" && CauseCode == 357)
                {
                    return "Het ontluchtingsprogramma is actief.";
                }
                if (DisplayCode == "2F" && CauseCode == 260)
                {
                    return "De aanvoertemperatuursensor meet geen temperatuurstijging na een branderstart.";
                }
                if (DisplayCode == "2F" && CauseCode == 271)
                {
                    return "Het gemeten temperatuursverschil  tussen de aanvoer- en safetytemperatuursensor is te groot.";
                }
                if (DisplayCode == "2F" && CauseCode == 338)
                {
                    return "Branderstart te vaak afgebroken.";
                }
                if (DisplayCode == "2F" && CauseCode == 345)
                {
                    return "De aanvoertemperatuursensor meet geen temperatuurstijging na een branderstart.";
                }
                if (DisplayCode == "2H" && CauseCode == 358)
                {
                    return "De 3-wegklep wordt gedeblokkeerd.";
                }
                if (DisplayCode == "2L" && CauseCode == 266)
                {
                    return "De pomptest is mislukt.";
                }
                if (DisplayCode == "2L" && CauseCode == 329)
                {
                    return "De druksensor meet geen waterstroming.";
                }
                if (DisplayCode == "2P" && CauseCode == 212)
                {
                    return "De gemeten temperatuur door de aanvoertemperatuursensor of de safetytemperatuursensor, stijgt te snel.";
                }
                if (DisplayCode == "2P" && CauseCode == 341)
                {
                    return "De gemeten temperatuur door de aanvoertemperatuursensor of de retourtemperatuursensor, stijgt te snel.";
                }
                if (DisplayCode == "2P" && CauseCode == 342)
                {
                    return "De gemeten temperatuur door de aanvoertemperatuursensor stijgt te snel.";
                }
                if (DisplayCode == "2U" && CauseCode == 213)
                {
                    return "De gemeten temperatuur tussen de aanvoer- en de retourtemperatuursensor is te groot.";
                }
                if (DisplayCode == "2U" && CauseCode == 349)
                {
                    return "Het op laaglast gemeten temperatuurverschil tussen de aanvoertemperatuursensor en de retourtemperatuursensor is te groot.";
                }
                if (DisplayCode == "2Y" && CauseCode == 281)
                {
                    return "De pomp zit vast of draait in lucht.";
                }
                if (DisplayCode == "2Y" && CauseCode == 282)
                {
                    return "Het stuursignaal van de pomp ontbreekt.";
                }
                if (DisplayCode == "3A" && CauseCode == 264)
                {
                    return "Het stuursignaal of de spanning van de ventilator is tijdens bedrijf weggevallen.";
                }
                if (DisplayCode == "3C" && CauseCode == 217)
                {
                    return "Het ventilatortoerental is onregelmatig tijdens het opstarten.";
                }
                if (DisplayCode == "3F" && CauseCode == 273)
                {
                    return "Het cv-toestel is maximaal 2 minuten uitgeschakeld geweest, omdat het cv-toestel gedurende 24 uur continu in bedrijf is geweest. Dit is een veiligheidscontrole.";
                }
                if (DisplayCode == "3L" && CauseCode == 214)
                {
                    return "Ventilator draait niet tijdens de opstartfase (0C).";
                }
                if (DisplayCode == "3P" && CauseCode == 216)
                {
                    return "Het ventilatortoerental is te laag.";
                }
                if (DisplayCode == "3Y" && CauseCode == 215)
                {
                    return "Het ventilatortoerental is te hoog.";
                }
                if (DisplayCode == "4A" && CauseCode == 218)
                {
                    return "De aanvoertemperatuursensor heeft een temperatuur gemeten die hoger is dan 105 ºC.";
                }
                if (DisplayCode == "4A" && CauseCode == 332)
                {
                    return "De aanvoertemperatuursensor heeft een temperatuur gemeten die hoger is dan 110 ºC.";
                }
                if (DisplayCode == "4C" && CauseCode == 224)
                {
                    return "Een toestelthermostaat (bv. maximaal- of branderthermostaat) heeft een te hoge temperatuur gemeten en staat geopend.";
                }
                if (DisplayCode == "4E" && CauseCode == 225)
                {
                    return "Er is een overwacht groot temperatuurverschil gemeten in de dubbelsensor.";
                }
                if (DisplayCode == "4E" && CauseCode == 278)
                {
                    return "De sensortest is mislukt.";
                }
                if (DisplayCode == "4E" && CauseCode == 347)
                {
                    return "De retourtemperatuursensor heeft een hogere cv-watertemperatuur gemeten dan de aanvoertemperatuursensor. Na 10 minuten volgt een herstart.";
                }
                if (DisplayCode == "4E" && CauseCode == 375)
                {
                    return "De contacten de externe sensor (bv. solar-sensor) zijn kortgesloten.";
                }
                if (DisplayCode == "4E" && CauseCode == 376)
                {
                    return "De contacten de externe sensor (bv. solar-sensor) zijn onderbroken.";
                }
                if (DisplayCode == "4F" && CauseCode == 219)
                {
                    return "De safetytemperatuursensor heeft een temperatuur gemeten die hoger is dan 105 ºC.";
                }
                if (DisplayCode == "4L" && CauseCode == 220)
                {
                    return "De contacten van de safetytemperatuursensor zijn kortgesloten of de safetytemperatuursensor heeft een temperatuur gemeten die hoger is dan 130 ºC.";
                }
                if (DisplayCode == "4P" && CauseCode == 221)
                {
                    return "De contacten van de safetytemperatuursensor zijn onderbroken.";
                }
                if (DisplayCode == "4U" && CauseCode == 222)
                {
                    return "De contacten de aanvoertemperatuursensor zijn kortgesloten.";
                }
                if (DisplayCode == "4U" && CauseCode == 350)
                {
                    return "De contacten de aanvoertemperatuursensor zijn kortgesloten.";
                }
                if (DisplayCode == "4Y" && CauseCode == 223)
                {
                    return "De contacten van de aanvoertemperatuursensor zijn onderbroken.";
                }
                if (DisplayCode == "4Y" && CauseCode == 351)
                {
                    return "De contacten van de aanvoertemperatuursensor zijn onderbroken.";
                }
                if (DisplayCode == "5A" && CauseCode == -6)
                {
                    return "Door Nefit Service Tool/Handterminal gegenereerde storingscode.";
                }
                if (DisplayCode == "5C" && CauseCode == 226)
                {
                    return "Service Tool is aangesloten geweest.";
                }
                if (DisplayCode == "5F" && CauseCode == -1)
                {
                    return "Service Tool: servicetest duurt te lang.";
                }
                if (DisplayCode == "5H" && CauseCode == 268)
                {
                    return "Componententest.";
                }
                if (DisplayCode == "5Y" && CauseCode == -2)
                {
                    return "Service Tool: servicetest duurt te lang of  een het cv-toestelparameter is gewijzigd.";
                }
                if (DisplayCode == "6A" && CauseCode == 227)
                {
                    return "Er is onvoldoende ionisatiestroom gemeten na het ontsteken van de brander.";
                }
                if (DisplayCode == "6C" && CauseCode == 228)
                {
                    return "Er is een ionisatiestroom gemeten voordat de brander is gestart.";
                }
                if (DisplayCode == "6C" && CauseCode == 306)
                {
                    return "Er is een ionisatiestroom gemeten, nadat de brander gedoofd is.";
                }
                if (DisplayCode == "6H" && CauseCode == -7)
                {
                    return "Ionisatie valt weg kort na het ontsteken van de brander.";
                }
                if (DisplayCode == "6L" && CauseCode == 229)
                {
                    return "Er is onvoldoende ionisatiestroom gemeten tijdens het branden.";
                }
                if (DisplayCode == "6P" && CauseCode == 269)
                {
                    return "De ontstekingsunit is te lang aangestuurd.";
                }
                if (DisplayCode == "7A" && CauseCode == -8)
                {
                    return "De netspanning of ModuLine thermostaat wordt extern beïnvloed.";
                }
                if (DisplayCode == "7C" && CauseCode == 231)
                {
                    return "De netspanning is tijdens een vergrendelende storing onderbroken geweest.";
                }
                if (DisplayCode == "7F" && CauseCode == -9)
                {
                    return "Zekering F3 is defect";
                }
                if (DisplayCode == "7H" && CauseCode == 328)
                {
                    return "Er is een kortstondige onderbreking van de netspanning geweest.";
                }
                if (DisplayCode == "7L" && CauseCode == 261)
                {
                    return "De branderautomaat is defect.";
                }
                if (DisplayCode == "7L" && CauseCode == 280)
                {
                    return "De branderautomaat is defect.";
                }
                if (DisplayCode == "8C" && CauseCode == 373)
                {
                    return "De branderthermostaat heeft, vaker dan is toegestaan, een te hoge temperatuur gemeten.";
                }
                if (DisplayCode == "8C" && CauseCode == 374)
                {
                    return "Er is,  vaker dan toegestaan, onvoldoende ionisatiestroom gemeten tijdens het branden.";
                }
                if (DisplayCode == "8U" && CauseCode == 364)
                {
                    return "Het gasregelblok vertoont symptomen van veroudering.";
                }
                if (DisplayCode == "8U" && CauseCode == 365)
                {
                    return "Het gasregelblok vertoont symptomen van veroudering.";
                }
                if (DisplayCode == "8Y" && CauseCode == 232)
                {
                    return "Het externe schakelcontact is geopend.";
                }
                if (DisplayCode == "9A" && CauseCode == 235)
                {
                    return "De KIM is te nieuw voor de branderautomaat.";
                }
                if (DisplayCode == "9A" && CauseCode == 360)
                {
                    return "De geplaatste KIM correspondeert niet met de branderautomaat.";
                }
                if (DisplayCode == "9A" && CauseCode == 361)
                {
                    return "De geplaatste branderautomaat correspondeert niet met de KIM.";
                }
                if (DisplayCode == "9C" && CauseCode == 322)
                {
                    return "De branderautomaat ziet geen KIM.";
                }
                if (DisplayCode == "9C" && CauseCode == -10)
                {
                    return "De branderautomaat ziet geen KIM.";
                }
                if (DisplayCode == "9F" && CauseCode == -11)
                {
                    return "De branderautomaat is defect.";
                }
                if (DisplayCode == "9H" && CauseCode == 237)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "9H" && CauseCode == 267)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "9H" && CauseCode == 272)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "9L" && CauseCode == 234)
                {
                    return "De contacten van het gasregelblok zijn onderbroken.";
                }
                if (DisplayCode == "9L" && CauseCode == 238)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "9P" && CauseCode == 239)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "9U" && CauseCode == 233)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "C0" && CauseCode == 288)
                {
                    return "De waterdruk is te hoog of de contacten van de druksensor zijn onderbroken.";
                }
                if (DisplayCode == "C0" && CauseCode == 289)
                {
                    return "De contacten van de druksensor zijn kortgesloten.";
                }
                if (DisplayCode == "CA" && CauseCode == 286)
                {
                    return "De retourtemperatuursensor heeft een cv-retourtemperatuur gemeten die hoger is dan 105 ºC.";
                }
                if (DisplayCode == "CU" && CauseCode == 240)
                {
                    return "De contacten van de retourtemperatuursensor zijn kortgesloten.";
                }
                if (DisplayCode == "CY" && CauseCode == 241)
                {
                    return "De contacten van de retourtemperatuursensor zijn onderbroken.";
                }
                if (DisplayCode == "E1" && CauseCode == 242)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 243)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 244)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 245)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 247)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 248)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 249)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 255)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "E1" && CauseCode == 257)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EA" && CauseCode == 246)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EA" && CauseCode == 252)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EA" && CauseCode == 253)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EC" && CauseCode == 251)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EC" && CauseCode == 256)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EF" && CauseCode == 254)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EH" && CauseCode == 250)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EH" && CauseCode == 258)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EH" && CauseCode == 262)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EL" && CauseCode == 259)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EL" && CauseCode == 279)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EL" && CauseCode == 290)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EP" && CauseCode == 287)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "EY" && CauseCode == 263)
                {
                    return "De branderautomaat of de KIM is defect.";
                }
                if (DisplayCode == "A01" && CauseCode == 800)
                {
                    return "De buitentemperatuursensor is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A01" && CauseCode == 808)
                {
                    return "De warmwatertemperatuursensor van de eerste ww-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A01" && CauseCode == 809)
                {
                    return "De warmwatertemperatuursensor van de tweede ww-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A01" && CauseCode == 810)
                {
                    return "De warmwatervoorziening blijft koud of de warmwatertemperatuur is tijdens opwarming gedurende 2 uur niet gestegen.";
                }
                if (DisplayCode == "A01" && CauseCode == 811)
                {
                    return "De thermische desinfectie van de warmwaterboiler is niet gelukt of de temperatuur voor het desinfecteren van de warmwaterboiler is niet gehaald binnen 3 uur.";
                }
                if (DisplayCode == "A01" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk over de communicatiebus.";
                }
                if (DisplayCode == "A01" && CauseCode == 828)
                {
                    return "Waterdruksensor geeft storing.";
                }
                if (DisplayCode == "A02" && CauseCode == 816)
                {
                    return "Geen communicatie met het bedieningspaneel van de cv-ketel.";
                }
                if (DisplayCode == "A11" && CauseCode == 801)
                {
                    return "Er is een interne fout opgetreden.";
                }
                if (DisplayCode == "A11" && CauseCode == 802)
                {
                    return "De tijd is niet ingesteld.";
                }
                if (DisplayCode == "A11" && CauseCode == 803)
                {
                    return "De datum is niet ingesteld.";
                }
                if (DisplayCode == "A11" && CauseCode == 804)
                {
                    return "Er is een interne fout opgetreden.";
                }
                if (DisplayCode == "A11" && CauseCode == 806)
                {
                    return "De ruimtetemperatuursensor van de ModuLine-regeling is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A11" && CauseCode == 821)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A11" && CauseCode == 822)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A11" && CauseCode == 823)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A11" && CauseCode == 824)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A11" && CauseCode == 825)
                {
                    return "Er zijn 2 ModuLine-regelingen toegekend aan 1 cv-groep.";
                }
                if (DisplayCode == "A11" && CauseCode == 826)
                {
                    return "De ruimtetemperatuursensor van de ModuLine 400 regeling is defect of geeft onrealistische waarde.";
                }
                if (DisplayCode == "A11" && CauseCode == 827)
                {
                    return "De ruimtetemperatuursensor van de ModuLine 400 regeling is defect of geeft onrealistische waarde.";
                }
                if (DisplayCode == "A11" && CauseCode == 828)
                {
                    return "De waterdruksensor is defect of geeft onrealistische waarde.";
                }
                if (DisplayCode == "A12" && CauseCode == 815)
                {
                    return "De aanvoertemperatuursensor van de open verdeler is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A12" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de verdelermodule (WM10).";
                }
                if (DisplayCode == "A18" && CauseCode == 825)
                {
                    return "Er zijn 2 ModuLine-regelingen toegekend aan 1 cv-groep.";
                }
                if (DisplayCode == "A21" && CauseCode == 806)
                {
                    return "De ruimtetemperatuursensor van de ModuLine-regeling van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A21" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A21" && CauseCode == 829)
                {
                    return "Er is geen cv-groep toegekend aan de ModuLine-regeling, of er is een cv-groep toegekend aan een niet aanwezige ModuLine-regeling.";
                }
                if (DisplayCode == "A21" && CauseCode == 830)
                {
                    return "Er is een te lage batterijspanning voor de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A21" && CauseCode == 839)
                {
                    return "Er is geen radiocommunicatie met de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A21" && CauseCode == 842)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A21" && CauseCode == 843)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A22" && CauseCode == 806)
                {
                    return "De ruimtetemperatuursensor van de ModuLine-regeling van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A22" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A22" && CauseCode == 829)
                {
                    return "Er is geen cv-groep toegekend aan de ModuLine-regeling, of er is een cv-groep toegekend aan een niet aanwezige ModuLine-regeling.";
                }
                if (DisplayCode == "A22" && CauseCode == 830)
                {
                    return "Er is een te lage batterijspanning voor de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A22" && CauseCode == 839)
                {
                    return "Er is geen radiocommunicatie met de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A22" && CauseCode == 842)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A22" && CauseCode == 843)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A23" && CauseCode == 806)
                {
                    return "De ruimtetemperatuursensor van de ModuLine-regeling van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A23" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A23" && CauseCode == 829)
                {
                    return "Er is geen cv-groep toegekend aan de ModuLine-regeling, of er is een cv-groep toegekend aan een niet aanwezige ModuLine-regeling.";
                }
                if (DisplayCode == "A23" && CauseCode == 830)
                {
                    return "Er is een te lage batterijspanning voor de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A23" && CauseCode == 839)
                {
                    return "Er is geen radiocommunicatie met de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A23" && CauseCode == 842)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A23" && CauseCode == 843)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A24" && CauseCode == 806)
                {
                    return "De ruimtetemperatuursensor van de ModuLine-regeling van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A24" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A24" && CauseCode == 829)
                {
                    return "Er is geen cv-groep toegekend aan de ModuLine-regeling, of er is een cv-groep toegekend aan een niet aanwezige ModuLine-regeling.";
                }
                if (DisplayCode == "A24" && CauseCode == 830)
                {
                    return "Er is een te lage batterijspanning voor de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A24" && CauseCode == 839)
                {
                    return "Er is geen radiocommunicatie met de draadloze ModuLine-regeling van de betreffende cv-groep.";
                }
                if (DisplayCode == "A24" && CauseCode == 842)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A24" && CauseCode == 843)
                {
                    return "Er is geen ModuLine-regeling toegepast voor de betreffende cv-groep.";
                }
                if (DisplayCode == "A32" && CauseCode == 807)
                {
                    return "De aanvoertemperatuursensor van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A32" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de mengklepmodule (MM10) van de betreffende cv-groep.";
                }
                if (DisplayCode == "A33" && CauseCode == 807)
                {
                    return "De aanvoertemperatuursensor van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A33" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de mengklepmodule (MM10) van de betreffende cv-groep.";
                }
                if (DisplayCode == "A34" && CauseCode == 807)
                {
                    return "De aanvoertemperatuursensor van de betreffende cv-groep is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A34" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de mengklepmodule (MM10) van de betreffende cv-groep.";
                }
                if (DisplayCode == "A51" && CauseCode == 812)
                {
                    return "De zonneboilerregeling is verkeerd ingesteld.";
                }
                if (DisplayCode == "A51" && CauseCode == 813)
                {
                    return "De collectortemperatuursensor is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A51" && CauseCode == 814)
                {
                    return "De zonneboilertemperatuursensor is defect of geeft een onrealistische waarde.";
                }
                if (DisplayCode == "A51" && CauseCode == 816)
                {
                    return "Er is geen communicatie mogelijk met de zonneboilermodule (SM10).";
                }
                if (DisplayCode == "AD1" && CauseCode == 817)
                {
                    return "De luchttemperatuursensor is defect of geeft onrealistische waarde.";
                }
                if (DisplayCode == "AD1" && CauseCode == 818)
                {
                    return "De aanvoertemperatuur van het cv-toestel stijgt te weinig binnen 30 minuten.";
                }
                if (DisplayCode == "AD1" && CauseCode == 819)
                {
                    return "Niet van toepassing op gasgestookte cv-toestellen.";
                }
                if (DisplayCode == "AD1" && CauseCode == 820)
                {
                    return "Niet van toepassing op gasgestookte cv-toestellen.";
                }
                if (DisplayCode == "H01" && CauseCode == -13)
                {
                    return "De rookgastemperatuur is hoger dan normaal.";
                }
                if (DisplayCode == "H02" && CauseCode == -14)
                {
                    return "De ventilator draait langzamer dan normaal.";
                }
                if (DisplayCode == "H03" && CauseCode == -15)
                {
                    return "Het aantal bedrijfsuren voor de volgende onderhoudsbeurt is verlopen.";
                }
                if (DisplayCode == "H04" && CauseCode == -17)
                {
                    return "Onderhoudsmelding: de ionisatiestroom is lager dan normaal.";
                }
                if (DisplayCode == "H05" && CauseCode == -18)
                {
                    return "Onderhoudsmelding: de ontsteekspanning is hoger dan normaal.";
                }
                if (DisplayCode == "H06" && CauseCode == -19)
                {
                    return "Onderhoudsmelding: het aantal herstarts voor het in bedrijf brengen van de brander is meer dan normaal.";
                }
                if (DisplayCode == "H07" && CauseCode == -20)
                {
                    return "De  gemeten cv-waterdruk is te laag.  Het vermogen voor zowel cv-bedrijf als voor warmwaterbedrijf wordt beperkt.";
                }
                if (DisplayCode == "H08" && CauseCode == -21)
                {
                    return "De ingestelde onderhoudsdatum  is verlopen. Onderhoud gewenst.";
                }
                if (DisplayCode == "H11" && CauseCode == -25)
                {
                    return "De warmwateruitstroomtemperatuursensor is defect. De functie wordt overgenomen door de software van het cv-toestel.";
                }
                if (DisplayCode == "H12" && CauseCode == -26)
                {
                    return "De bewaartemperatuursensor is defect. De functie wordt overgenomen door de software van het cv-toestel.";
                }
                if (DisplayCode == "H13" && CauseCode == -27)
                {
                    return "De ingestelde maximale onderhoudsperiode, is overschreden. Onderhoud gewenst.";
                }
                if (DisplayCode == "H13" && CauseCode == -28)
                {
                    return "Onderhoudsperiode is ingesteld.";
                }
                if (DisplayCode == "H25" && CauseCode == -40)
                {
                    return "De contacten van de druksensor zijn onderbroken.";
                }
                if (DisplayCode == "Hre" && CauseCode == -48)
                {
                    return "Het cv-toestel wordt gereset.";
                }
                if (DisplayCode == "re" && CauseCode == -4)
                {
                    return "Het cv-toestel wordt gereset.";
                }
                return "Unknown";
            }
        }

        internal StatusCode(string displayCode, int causeCode)
        {
            DisplayCode = displayCode;
            CauseCode = causeCode;
        }
    }
}