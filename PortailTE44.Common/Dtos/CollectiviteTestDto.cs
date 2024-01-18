namespace PortailTE44.Common.Dtos
{
    public class CollectiviteTestDto
    {
        public int IdEudonet { get; set; } = default!;
        public string Libelle { get; set; } = default!;
        public bool CommunauteCommune { get; set; }
    }
}
