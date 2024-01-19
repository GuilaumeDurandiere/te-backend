using PortailTE44.Common.Dtos.FormulaireAdhesion;

namespace PortailTE44.Business.Services.Interfaces
{
	public interface IFormulaireAdhesionService
	{
        Task<bool> SendMailFormulaireAdhesion(FormulaireAdhesionPayloadDto dto);
    }
}

