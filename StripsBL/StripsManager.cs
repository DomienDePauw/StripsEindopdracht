using Microsoft.EntityFrameworkCore;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL
{
    public class StripsManager
    {
        private readonly StripsRepository _repository;

        public StripsManager(StripsRepository repository)
        {
            _repository = repository;
        }

        public StripsDTO GetStripById(int id)
        {
            var strip = _repository.GetById(id);

            if (strip == null)
                return null;

            return new StripsDTO
            {
                Url = $"http://localhost:5263/api/strips/beheer/strip/{strip.Id}",
                Titel = strip.Titel,
                Nr = strip.ReeksNummer,
                Reeks = strip.Reeks.Naam,
                ReeksUrl = strip.Reeks != null ? $"http://localhost:5263/api/strips/beheer/reeks/{strip.Reeks.Id}" : null,
                Uitgeverij = strip.Uitgeverij.Naam,
                UitgeverijUrl = strip.Uitgeverij != null ? $"http://localhost:5263/api/strips/beheer/uitgeverij/{strip.Uitgeverij.Id}" : null,
                Auteurs = strip.Auteurs.Select(a => new AuteurDTO
                {
                    Auteur = a.Naam,
                    Url = $"http://localhost:5263/api/strips/beheer/auteur/{a.Id}"
                }).ToList()
            };
        }
    }


}
