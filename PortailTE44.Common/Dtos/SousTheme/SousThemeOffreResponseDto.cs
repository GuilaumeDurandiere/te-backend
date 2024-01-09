namespace PortailTE44.Common.Dtos.SousTheme
{
    public class SousThemeOffreResponseDto
    {
        public int Id { get; set; }
        public string Libelle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Couleur { get; set; } = default!;
        public string? Icone { get; set; }
        public string TypeOffre { get; set; } = default!;
    }
}
