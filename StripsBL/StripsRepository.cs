using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StripsDL;
using StripsDL.Models;

namespace StripsBL;

public class StripsRepository
{
    private readonly StripsContext _context;

    public StripsRepository(StripsContext context)
    {
        _context = context;
    }
    public Strip GetStripById(int id)
    {
        return _context.Strips
                       .Include(s => s.Auteurs)
                       .Include(s => s.Uitgeverij)
                       .Include(s => s.Reeks)
                       .FirstOrDefault(s => s.Id == id);
    }
    public Reeks GetReeksById(int id)
    {
        return _context.Reeksen
                       .Include(r => r.Strips)
                       .FirstOrDefault(r => r.Id == id);
    }

    public void UpdateReeksVanStrip(int stripId, int nieuweReeksId)
    {
        var strip = _context.Strips.Include(s => s.Reeks).FirstOrDefault(s => s.Id == stripId);
        if (strip == null)
        {
            throw new Exception($"Strip met id {stripId} niet gevonden.");
        }

        var nieuweReeks = _context.Reeksen.FirstOrDefault(r => r.Id == nieuweReeksId);
        if (nieuweReeks == null)
        {
            throw new Exception($"Reeks met id {nieuweReeksId} niet gevonden.");
        }

        strip.Reeks = nieuweReeks;
        _context.SaveChanges();
    }

    public void VoegAuteurToeAanStrip(int stripId, int auteurId)
    {
        var strip = _context.Strips.Include(s => s.Auteurs).FirstOrDefault(s => s.Id == stripId);
        if (strip == null)
        {
            throw new Exception($"Strip met id {stripId} niet gevonden.");
        }

        var auteur = _context.Auteurs.FirstOrDefault(a => a.Id == auteurId);
        if (auteur == null)
        {
            throw new Exception($"Auteur met id {auteurId} niet gevonden.");
        }

        if (strip.Auteurs.Contains(auteur))
        {
            throw new Exception("Deze auteur is al gekoppeld aan de strip.");
        }

        strip.Auteurs.Add(auteur);
        _context.SaveChanges();
    }
    public void VerwijderAuteurVanStrip(int stripId, int auteurId)
    {
        var strip = _context.Strips.Include(s => s.Auteurs).FirstOrDefault(s => s.Id == stripId);
        if (strip == null)
        {
            throw new Exception($"Strip met id {stripId} niet gevonden.");
        }

        var auteur = _context.Auteurs.FirstOrDefault(a => a.Id == auteurId);
        if (auteur == null)
        {
            throw new Exception($"Auteur met id {auteurId} niet gevonden.");
        }

        if (!strip.Auteurs.Contains(auteur))
        {
            throw new Exception("Deze auteur is niet gekoppeld aan de strip.");
        }

        strip.Auteurs.Remove(auteur);
        _context.SaveChanges();
    }

    public void UpdateUitgeverijVanStrip(int stripId, int uitgeverijId)
    {
        var strip = _context.Strips.Include(s => s.Uitgeverij).FirstOrDefault(s => s.Id == stripId);
        if (strip == null)
        {
            throw new Exception($"Strip met id {stripId} niet gevonden.");
        }

        var uitgeverij = _context.Uitgeverijen.FirstOrDefault(u => u.Id == uitgeverijId);
        if (uitgeverij == null)
        {
            throw new Exception($"Uitgeverij met id {uitgeverijId} niet gevonden.");
        }

        strip.Uitgeverij = uitgeverij;
        _context.SaveChanges();
    }

    public void UpdateAuteur(int auteurId, string nieuweNaam, string nieuweEmail)
    {
        var auteur = _context.Auteurs.FirstOrDefault(a => a.Id == auteurId);
        if (auteur == null)
        {
            throw new Exception($"Auteur met id {auteurId} niet gevonden.");
        }

        if (!string.IsNullOrWhiteSpace(nieuweNaam))
        {
            auteur.Naam = nieuweNaam;
        }
        if (!string.IsNullOrWhiteSpace(nieuweEmail))
        {
            auteur.EmailAdres = nieuweEmail;
        }

        _context.SaveChanges();
    }

    public void UpdateStripTitel(int stripId, string nieuweTitel)
    {
        var strip = _context.Strips.FirstOrDefault(s => s.Id == stripId);
        if (strip == null)
        {
            throw new ArgumentException($"Strip met id {stripId} niet gevonden.");
        }
        if (!string.IsNullOrWhiteSpace(nieuweTitel))
        {
            strip.Titel = nieuweTitel;
        }
        _context.SaveChanges();
    }

    public void UpdateUitgeverij(int uitgeverijId, string nieuweNaam, string nieuwAdres)
    {
        var uitgeverij = _context.Uitgeverijen.FirstOrDefault(u => u.Id == uitgeverijId);
        if (uitgeverij == null) 
        {
            throw new ArgumentException($"Uitgeverij met id {uitgeverijId} niet gevonden.");
        }
        if (!string.IsNullOrWhiteSpace(nieuweNaam)) 
        {
            uitgeverij.Naam = nieuweNaam;
        }
        if (!string.IsNullOrWhiteSpace(nieuwAdres))
        {
            uitgeverij.Adres = nieuwAdres;
        }
        _context.SaveChanges();
    }
}
