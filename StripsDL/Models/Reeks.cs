using System.ComponentModel.DataAnnotations;

namespace StripsDL.Models;
public class Reeks
{
    public Reeks()
    {

    }
    public Reeks(string naam)
    {
        Naam = naam;
    }
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public ICollection<Strip> Strips { get; set; } = new List<Strip>();
}