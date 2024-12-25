using StripsBL.Model;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Mappers;
public static class AuteurMapper
{
    public static Auteur MapToDomain(AuteurEF db) => new Auteur(
        db.Id,
        db.Naam,
        db.EmailAdres
    );

    public static AuteurEF MapToEF(Auteur domain) => new AuteurEF
    {
        Id = domain.Id,
        Naam = domain.Naam,
        EmailAdres = domain.EmailAdres,
        Strips = domain.Strips.Select(StripMapper.MapToEF).ToList()
    };
}
