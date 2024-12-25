using StripsBL.Model;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Mappers;
public class UitgeverijMapper
{
    public static Uitgeverij MapToDomain(UitgeverijEF db) => new Uitgeverij
    {
        Id = db.Id,
        Naam = db.Naam,
        Adres = db.Adres ?? string.Empty,
    };

    public static UitgeverijEF MapToEF(Uitgeverij domain) => new UitgeverijEF
    {
        Id = domain.Id,
        Naam = domain.Naam,
        Adres = domain.Adres,
        Strips = domain.Strips.Select(StripMapper.MapToEF).ToList()
    };
}
