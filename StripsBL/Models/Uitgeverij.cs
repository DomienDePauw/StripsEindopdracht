using System.ComponentModel.DataAnnotations;

namespace StripsBL.Models;

public class Uitgeverij
{
    public Uitgeverij()
    {
        
    }
    public Uitgeverij(string naam)
    {
        Naam = naam;
    }
    public Uitgeverij(string naam, string adres)
    {
        Naam = naam;
        Adres = adres;
    }
    public int Id { get; set; }
    public string Naam { get; set; }
    public string? Adres { get; set; }
    public ICollection<Strip> Strips { get; set; } = new List<Strip>();
}