using StripsDL.Models;

namespace StripsDL;

public class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        p.DeleteDb();
        p.ReadData();
    }
    public void DeleteDb()
    {
        using (var context = new StripsContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("Database is opnieuw aangemaakt");
        }
    }
    public void ReadData(string path = @"C:\Users\Domie\OneDrive\Bureaublad\HoGent\2de-jaar-graduaat\PROG2\StripASP.NET\stripsData.txt")
    {
        using (var context = new StripsContext())
        {
            var auteurs = new Dictionary<string, AuteurEF>();
            var reeksen = new Dictionary<string, ReeksEF>();
            var uitgeverijen = new Dictionary<string, UitgeverijEF>();
            var strips = new HashSet<StripEF>();

            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(";");
                    int? reeksNr = null;
                    if (int.TryParse(data[0].Trim(), out int parsedReeksNr))
                    {
                        reeksNr = parsedReeksNr;
                    }
                    string titel = data[1].Trim();
                    string uitgeverijNaam = data[2].Trim();
                    string reeksNaam = data[3].Trim();
                    string[] auteursNamen = data[4]
                        .Split("|")
                        .Select(x => x.Replace("\"", "").Trim())
                        .ToArray();

                    foreach (var a in auteursNamen) 
                    {
                        auteurs.TryAdd(a, new AuteurEF(a));
                    }

                    reeksen.TryAdd(reeksNaam, new ReeksEF(reeksNaam));
                    uitgeverijen.TryAdd(uitgeverijNaam, new UitgeverijEF(uitgeverijNaam));

                    var strip = new StripEF
                    {
                        Titel = titel,
                        Uitgeverij = uitgeverijen[uitgeverijNaam],
                        Reeks = reeksen[reeksNaam],
                        ReeksNummer = reeksNr,
                    };

                    foreach (var a in auteursNamen) 
                    {
                        strip.Auteurs.Add(auteurs[a]);
                    }
                    strips.Add(strip);
                }
            }
            context.Strips.AddRange(strips);
            context.SaveChanges();
        }
    }
}

