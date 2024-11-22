using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Models;
public class Strip
{
    public Strip()
    {

    }
    public Strip(string titel, int reeksNummer)
    {
        Titel = titel;
        ReeksNummer = reeksNummer;
    }
    public Strip(string titel, List<Auteur> auteurs, Uitgeverij uitgeverij, Reeks reeks, int reeksNummer)
    {
        Titel = titel;
        Auteurs = auteurs;
        Uitgeverij = uitgeverij;
        Reeks = reeks;
        ReeksNummer = reeksNummer;
    }

    public int Id { get; set; }
    [Required]
    public string Titel { get; set; }
    [Required]
    public ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
    [Required]
    public Uitgeverij Uitgeverij { get; set; }
    public Reeks Reeks { get; set; }
    public int? ReeksNummer { get; set; }
}
