using PortailTE44.Common.Dtos.Demande;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface IDemandeService
	{
		Task<bool> DemandeFormulaireSimplifieResponsable(DemandeFormulaireSimplifieResponsableDto dto);
	}
}

