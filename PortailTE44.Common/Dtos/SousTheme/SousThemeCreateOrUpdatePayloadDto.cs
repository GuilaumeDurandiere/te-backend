namespace PortailTE44.Common.Dtos.SousTheme
{
    public class SousThemeCreateOrUpdatePayloadDto : SousThemeBaseDto
    {
        public int WorkflowId { get; set; }
        public int ThemeId { get; set; }
    }
}

