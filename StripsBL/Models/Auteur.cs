using System.ComponentModel.DataAnnotations;

namespace StripsBL.Models;

public class Auteur
{
    public Auteur()
    {

    }
    public Auteur(string naam)
    {
        Naam = naam;
    }
    public Auteur(string naam, string emailadres)
    {
        Naam = naam;
        EmailAdres = emailadres;
    }
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public string? EmailAdres { get; set; }
    public ICollection<Strip> Strips { get; set; } = new List<Strip>();
}
