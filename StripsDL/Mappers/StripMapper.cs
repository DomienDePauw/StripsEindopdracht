using StripsBL.Model;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Mappers;
public class StripMapper
{
    public static Strip MapToDomain(StripEF db) => new Strip
    {
        Id = db.Id,
        Titel = db.Titel,
        Reeks = ReeksMapper.MapToDomain(db.Reeks),
        ReeksNummer = db.ReeksNummer ?? 0,
        Uitgeverij = UitgeverijMapper.MapToDomain(db.Uitgeverij),
        Auteurs = db.Auteurs.Select(AuteurMapper.MapToDomain).ToList()
    };

    public static StripEF MapToEF(Strip domain) => new StripEF
    {
        Id = domain.Id,
        Titel = domain.Titel,
        Reeks = ReeksMapper.MapToEF(domain.Reeks),
        ReeksNummer = domain.ReeksNummer,
        Uitgeverij = UitgeverijMapper.MapToEF(domain.Uitgeverij),
        Auteurs = domain.Auteurs.Select(AuteurMapper.MapToEF).ToList()
    };
}
