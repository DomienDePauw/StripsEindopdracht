using System.ComponentModel.DataAnnotations;

namespace StripsDL.Models;
public class ReeksEF
{
    public ReeksEF()
    {

    }
    public ReeksEF(string naam)
    {
        Naam = naam;
    }
    public int Id { get; set; }
    [Required]
    public string Naam { get; set; }
    public ICollection<StripEF> Strips { get; set; } = new List<StripEF>();
}