using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StripsBL.Model;

namespace StripsBL.Interfaces;
public interface IStripsRepository
{
    Strip GetStripById(int id);
    Reeks GetReeksById(int id);
    void UpdateReeksVanStrip(int stripId, int reeksId);
    void VoegAuteurToeAanStrip(int stripId, int auteurId);
    void VerwijderAuteurVanStrip(int stripId, int auteurId);
    void UpdateUitgeverijVanStrip(int stripId, int uitgeverijId);
    void UpdateAuteur(int auteurId, string nieuweNaam, string nieuweEmail);
    void UpdateStripTitel(int stripId, string nieuweTitel);
    void UpdateUitgeverij(int uitgeverijId, string nieuweNaam, string nieuwAdres);
}

