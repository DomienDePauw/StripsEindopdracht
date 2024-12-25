using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Model;
public class Auteur
{
    public Auteur(int id, string naam, string emailAdres)
    {
        Id = id;
        Naam = naam;
        EmailAdres = emailAdres;
    }

    public int Id { get; set; }
    public string Naam { get; set; }
    public string EmailAdres { get; set; }
    public List<Strip> Strips { get; set; }

}
