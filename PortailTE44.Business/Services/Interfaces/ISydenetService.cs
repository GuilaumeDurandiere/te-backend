namespace PortailTE44.Business.Services.Interfaces
{
    public interface ISydenetService
    {
        bool GetSydenetCompetencesByCommunauteCommune(string codeInsee);
        bool GetSydenetCompetencesByCommune(string codeInsee);
        bool GetSydenetServicesByCommunauteCommune(string codeInsee);
        bool GetSydenetServicesByCommune(string codeInsee);
        Task<bool> SynchronizeCollectivites();
        Task<bool> SynchronizeServiceCompetences();
    }
}
