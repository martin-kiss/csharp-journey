# Állatmenhely nyilvántartás

C# konzolalkalmazás (.NET 9), amely egy állatmenhely állatait és elhelyezési részlegeit tartja nyilván. A program ellenőrzi az adatok érvényességét, majd LINQ segítségével lekérdezéseket és statisztikákat készít belőlük.

## Funkciók

- Részlegek (`AnimalSection`) és állatok (`ShelterAnimal`) tárolása, minden állat pontosan egy részleghez tartozik
- Adatellenőrzés a propertykben, hibás érték esetén kivételdobással (például név hossza, életkor 0 és 25 között, testtömeg legfeljebb 150 kg, az érkezés dátuma nem lehet jövőbeli)
- Az állatok listázása faj, azon belül név szerinti sorrendben
- Átlagos testtömeg, legidősebb állat és a 10 kg-nál nehezebb állatok kiírása
- Fajonkénti darabszám (`GroupBy`)
- Legalább 180 napja a menhelyen lévő állatok kiírása
- Véletlenszerűen választott állat kiírása („Menhelyi ajánló")
- Keresés név vagy névrészlet alapján, kis- és nagybetűre nem érzékenyen

## Osztályok

- **`AnimalSection`**: egy részleg adatai (azonosító, név, maximális férőhely, beltéri-e)
- **`ShelterAnimal`**: egy állat adatai (azonosító, név, faj, életkor, testtömeg, érkezés dátuma, ivartalanított-e, részleg), a `ChangeWeight()` és `MoveToSection()` metódusokkal, valamint az `IsLongTermResident` számított propertyvel

## Futtatás

.NET 9 SDK szükséges.

```bash
dotnet run
```

A program kiírja a részlegeket és az állatokat, majd a lekérdezések eredményeit. Közben bekér egy nevet vagy névrészletet a kereséshez, például:

```text
bod
```

A program kiírja az összes találatot, vagy tájékoztatja a felhasználót, ha nincs találat.

## Dátum

2026. szeptember 23.
