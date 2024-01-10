using PortailTE44.Common.Dtos.RefTypeOffre;
using PortailTE44.Common.Dtos.Workflow;

namespace PortailTE44.Common.Dtos.SousTheme
{
    public class SousThemeResponseDto : SousThemeBaseDto
	{
		public int Id { get; set; }
        public WorkflowItemResponseDto? Workflow { get; set; }
		public RefTypeOffreDto RefTypeOffre { get; set; } = default!;
    }
}

