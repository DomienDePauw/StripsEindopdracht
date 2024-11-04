using StripsBL.Models;

namespace StripsDL;

public class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        p.ReadData();
    }

    public void ReadData(string path = @"C:\Users\Domie\OneDrive\Bureaublad\HoGent\2de-jaar-graduaat\PROG2\StripASP.NET\stripsData.txt")
    {
        using (var context = new StripContext())
        {
            var auteurs = new Dictionary<string, Auteur>();
            var reeksen = new Dictionary<string, Reeks>();
            var uitgeverijen = new Dictionary<string, Uitgeverij>();
            var strips = new HashSet<Strip>();

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
                        auteurs.TryAdd(a, new Auteur(a));
                    }

                    reeksen.TryAdd(reeksNaam, new Reeks(reeksNaam));
                    uitgeverijen.TryAdd(uitgeverijNaam, new Uitgeverij(uitgeverijNaam));

                    var strip = new Strip
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

