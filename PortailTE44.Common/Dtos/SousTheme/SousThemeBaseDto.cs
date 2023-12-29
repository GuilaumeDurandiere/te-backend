using System;
namespace PortailTE44.Common.Dtos.SousTheme
{
	public class SousThemeBaseDto
	{
        public string Libelle { get; set; } = default!;
        public string? LienExterne { get; set; }
        public bool DemandeSimple { get; set; }
        public string? TypeWorkflow { get; set; }
        public bool Accessible { get; set; }
        public string? Description { get; set; }
        public string MailReferent { get; set; } = default!;
    }
}

