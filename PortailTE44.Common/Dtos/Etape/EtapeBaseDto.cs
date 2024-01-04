using PortailTE44.Common.Dtos.SousEtapes;

namespace PortailTE44.Common.Dtos.Etape
{
    public class EtapeBaseDto
    {
        public string Libelle { get; set; } = default!;
        public string? Description { get; set; }
        public string Statut { get; set; } = default!;
    }
}
