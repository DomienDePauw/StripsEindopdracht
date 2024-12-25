using System.ComponentModel.DataAnnotations;

namespace StripsDL.Models;

public class UitgeverijEF
{
    public UitgeverijEF()
    {
        
    }
    public UitgeverijEF(string naam)
    {
        Naam = naam;
    }
    public UitgeverijEF(string naam, string adres)
    {
        Naam = naam;
        Adres = adres;
    }
    public int Id { get; set; }
    public string Naam { get; set; }
    public string? Adres { get; set; }
    public ICollection<StripEF> Strips { get; set; } = new List<StripEF>();
}