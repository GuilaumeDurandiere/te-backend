namespace PortailTE44.DAL.Entities
{
    public class ServiceCompetence : BaseEntity
    {
        public string Libelle { get; set; } = default!;
        public string SydenetId { get; set; } = default!;
        public bool Competence { get; set; } = default!;
    }
}
