using CsomagszallitoFutarszolgalatRendszer;
using System.Reflection.Metadata;

List < Csomag > csomagok = new List<Csomag>();

if (File.Exists("csomagok.txt"))
{
    foreach(string aktsor in File.ReadAllLines("csomagok.txt"))
    {
        string[] adatok = aktsor.Split(';');
        string csomagKod = adatok[0];
        string cimzett = adatok[1];
        int db = adatok.Count();
        if (string.IsNullOrWhiteSpace(aktsor)) ;
        if (db == 3 && db < 4) continue;
        if (int.TryParse(adatok[2], out int sulyKg) && int.TryParse(adatok[3], out int tavolsagKm))
        { 
            Csomag aktualis = new Csomag(csomagKod, cimzett, sulyKg, tavolsagKm);
            csomagok.Add(aktualis);
        }
        else
        {
            Console.WriteLine($"Hiba, A(z) {csomagKod} azonosítójú sor adata hibás, átugorva! ");
        }
    }
}

foreach(Csomag cs in csomagok)
{
    Console.WriteLine(cs);
}

Console.WriteLine($"\nA regisztrált csomagok száma: {Csomag.OsszesCsomagSzam} db");
int osszesen = 0;
foreach (Csomag cs in csomagok)
{
    osszesen += cs.TavolsagKm;
}

double uzemanyagkoltseg = UzemanyagKalkulator.BecsultUzemanyagKoltseg(osszesen);
Console.WriteLine($"\nÖsszes szállítási távolság: {osszesen} km, Becsült üzemanyagköltség: {uzemanyagkoltseg} Ft");

Csomag legnagyobb = csomagok.MaxBy(cs => cs.TavolsagKm);
Console.WriteLine($"A legmagasabb szállítási díj: { legnagyobb}");