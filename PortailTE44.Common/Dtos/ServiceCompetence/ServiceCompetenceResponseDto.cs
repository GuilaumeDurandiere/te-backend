namespace PortailTE44.Common.Dtos.ServiceCompetence
{
    public class ServiceCompetenceResponseDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; } = default!;
        public string SydenetId { get; set; } = default!;
        public bool Competence { get; set; } = default!;
    }
}
