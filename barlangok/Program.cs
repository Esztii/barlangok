using barlangok;
using System.Text;

List<Barlangok> barlangok = [];
using StreamReader sr = new("barlangok.txt", Encoding.UTF8);
sr.ReadLine();
while (!sr.EndOfStream) barlangok.Add(new(sr.ReadLine()));

Console.WriteLine($"4. feladat: Barlangok száma: {barlangok.Count}");

var f5 = barlangok.Where(f => f.Telepules.StartsWith("Miskolc")).Average(e => e.Melyseg);
Console.WriteLine($"5. feladat: Miskolci barlangok átlagos mélysége: {f5}m");

Console.WriteLine("6. feladat: Kérem a védettségi szintet:");
string vedettseg = Console.ReadLine();
var f6 = barlangok.Where(f => f.Vedettseg == vedettseg);
if(vedettseg.Count() == 0 || vedettseg != "fokozottan védett" || vedettseg!="védett" || vedettseg != "megkülönböztetetten védett")
{
    Console.WriteLine("Nincs ilyen védettségi szinttel rendelkező barlang az adatok között.");
}
else
{
    var f62 = barlangok.Where(f => f.Vedettseg == vedettseg).Max(f => f.Hossz).ToString();
    Console.WriteLine(f62);
}

var f7 = barlangok.GroupBy(f => f.Vedettseg).OrderBy(f => f.Key);
Console.WriteLine("Statisztika:");
foreach (var grp in f7) Console.WriteLine(
    $"{grp.Key}:" +
    $"{grp.Count()}"
        );
