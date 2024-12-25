using System.ComponentModel.DataAnnotations;

namespace StripsDL.Models;

public class AuteurEF
{
    public AuteurEF()
    {

    }
    public AuteurEF(string naam)
    {
        Naam = naam;
    }
    public AuteurEF(string naam, string emailadres)
    {
        Naam = naam;
        EmailAdres = emailadres;
    }
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public string? EmailAdres { get; set; }
    public ICollection<StripEF> Strips { get; set; } = new List<StripEF>();
}
