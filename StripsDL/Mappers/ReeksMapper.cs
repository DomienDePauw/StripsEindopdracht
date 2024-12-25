using StripsBL.Model;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Mappers;
public class ReeksMapper
{
    public static Reeks MapToDomain(ReeksEF db) => new Reeks
    {
        Id = db.Id,
        Naam = db.Naam,
        Strips = db.Strips.Select(s => new Strip
        {
            Id = s.Id,
            Titel = s.Titel,
            ReeksNummer = s.ReeksNummer ?? 0,
        }).ToList()
    };

    public static ReeksEF MapToEF(Reeks domain) => new ReeksEF
    {
        Id = domain.Id,
        Naam = domain.Naam,
        Strips = domain.Strips.Select(StripMapper.MapToEF).ToList()
    };
}
