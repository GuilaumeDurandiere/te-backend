using PortailTE44.Common.Dtos.Demande;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface IFormulaireSimplifieService
	{
		Task<bool> FormulaireSimplifieResponsable(FormulaireSimplifieResponsableDto dto);
	}
}

