using StripsBL.Interfaces;
using StripsBL.Model;

namespace StripsBL.Service;

public class StripsService
{
    private readonly IStripsRepository _repository;

    public StripsService(IStripsRepository repository)
    {
        _repository = repository;
    }

    public Reeks GetReeksById(int id)
    {
        return _repository.GetReeksById(id);
    }

    public Strip GetStripById(int id)
    {
        return _repository.GetStripById(id);
    }

    public void UpdateReeksVanStrip(int stripId, int nieuweReeksId)
    {
        _repository.UpdateReeksVanStrip(stripId, nieuweReeksId);
    }

    public void VoegAuteurToeAanStrip(int stripId, int auteurId)
    {
        _repository.VoegAuteurToeAanStrip(stripId, auteurId);
    }

    public void VerwijderAuteurVanStrip(int stripId, int auteurId)
    {
        _repository.VerwijderAuteurVanStrip(stripId, auteurId);
    }

    public void UpdateUitgeverijVanStrip(int stripId, int uitgeverijId)
    {
        _repository.UpdateUitgeverijVanStrip(stripId, uitgeverijId);
    }

    public void UpdateAuteur(int auteurId, string nieuweNaam, string nieuweEmail)
    {
        if (string.IsNullOrWhiteSpace(nieuweNaam))
            throw new ArgumentException("De naam mag niet leeg zijn.");

        if (string.IsNullOrWhiteSpace(nieuweEmail))
            throw new ArgumentException("Het e-mailadres mag niet leeg zijn.");

        _repository.UpdateAuteur(auteurId, nieuweNaam, nieuweEmail);
    }

    public void UpdateStripTitel(int stripId, string nieuweTitel)
    {
        if (string.IsNullOrWhiteSpace(nieuweTitel))
            throw new ArgumentException("De titel mag niet leeg zijn.");

        _repository.UpdateStripTitel(stripId, nieuweTitel);
    }

    public void UpdateUitgeverij(int uitgeverijId, string nieuweNaam, string nieuwAdres)
    {
        if (string.IsNullOrWhiteSpace(nieuweNaam))
            throw new ArgumentException("De naam mag niet leeg zijn.");

        if (string.IsNullOrWhiteSpace(nieuwAdres))
            throw new ArgumentException("Het adres mag niet leeg zijn.");

        _repository.UpdateUitgeverij(uitgeverijId, nieuweNaam, nieuwAdres);
    }

}
