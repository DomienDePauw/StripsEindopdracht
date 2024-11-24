using Microsoft.EntityFrameworkCore;
using StripsDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StripsBL.DTO;

namespace StripsBL
{
    public class StripsManager
    {
        private readonly StripsRepository _repository;

        public StripsManager(StripsRepository repository)
        {
            _repository = repository;
        }

        public ReeksDTO GetReeksById(int id)
        {
            var reeks = _repository.GetReeksById(id);
            if (reeks == null) return null;

            var reeksDTO = new ReeksDTO
            {
                Naam = reeks.Naam,
                Url = $"http://localhost:5263/api/Strips/beheer/Reeks/{reeks.Id}",
                Strips = reeks.Strips
                                .Select(s => new BasicStripsDTO(s.ReeksNummer ?? 0, s.Titel, $"http://localhost:5263/api/Strips/beheer/Strip/{s.Id}"))
                                .OrderBy(s => s.Nr)
                                .ToList()
            };
            return reeksDTO;
        }

        public StripsDTO GetStripById(int id)
        {
            var strip = _repository.GetStripById(id);

            if (strip == null) 
            {
                return null;
            }

            return 
                new StripsDTO
                (
                     url: $"http://localhost:5263/api/strips/beheer/strip/{strip.Id}",
                     titel: strip.Titel,
                     nr: strip.ReeksNummer,
                     reeks: strip.Reeks?.Naam,
                     reeksUrl: strip.Reeks != null ? $"http://localhost:5263/api/strips/beheer/reeks/{strip.Reeks.Id}" : null,
                     uitgeverij: strip.Uitgeverij?.Naam,
                     uitgeverijUrl: strip.Uitgeverij != null ? $"http://localhost:5263/api/strips/beheer/uitgeverij/{strip.Uitgeverij.Id}" : null,
                     auteurs: strip.Auteurs.Select(a => new AuteurDTO(
                     auteur: a.Naam,
                     url: $"http://localhost:5263/api/strips/beheer/auteur/{a.Id}"))
                     .ToList()
                );
        }

        public void UpdateAuteur(int auteurId, UpdateAuteurDTO updateDto)
        {
            if (string.IsNullOrWhiteSpace(updateDto.Naam))
                throw new ArgumentException("De naam mag niet leeg zijn.");

            if (string.IsNullOrWhiteSpace(updateDto.Email))
                throw new ArgumentException("Het e-mailadres mag niet leeg zijn.");

            _repository.UpdateAuteur(auteurId, updateDto.Naam, updateDto.Email);
        }

        public void UpdateReeksVanStrip(int stripId, int nieuweReeksId)
        {
            _repository.UpdateReeksVanStrip(stripId, nieuweReeksId);
        }

        public void UpdateStripTitel(int stripId, string nieuweTitel)
        {
            if (string.IsNullOrWhiteSpace(nieuweTitel))
                throw new ArgumentException("De titel mag niet leeg zijn.");

            _repository.UpdateStripTitel(stripId, nieuweTitel);
        }


        public void UpdateUitgeverijVanStrip(int stripId, int uitgeverijId)
        {
            _repository.UpdateUitgeverijVanStrip(stripId, uitgeverijId);
        }

        public void VerwijderAuteurVanStrip(int stripId, int auteurId)
        {
            _repository.VerwijderAuteurVanStrip(stripId, auteurId);
        }

        public void VoegAuteurToeAanStrip(int stripId, int auteurId)
        {
            _repository.VoegAuteurToeAanStrip(stripId, auteurId);
        }

        public void UpdateUitgeverij(int uitgeverijId, UpdateUitgeverijDTO updateDto)
        {
            if (string.IsNullOrWhiteSpace(updateDto.Naam))
                throw new ArgumentException("De naam mag niet leeg zijn.");

            if (string.IsNullOrWhiteSpace(updateDto.Adres))
                throw new ArgumentException("Het adres mag niet leeg zijn.");

            _repository.UpdateUitgeverij(uitgeverijId, updateDto.Naam, updateDto.Adres);
        }

    }


}
