using System;
namespace PortailTE44.DAL.Entities
{
	public class Theme : BaseEntity
	{
		public string Libelle { get; set; } = default!;
		public string? Description { get; set; }
		public string Icone { get; set; } = default!;
	}
}

