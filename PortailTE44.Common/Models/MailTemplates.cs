namespace PortailTE44.Common.Models
{
	public class MailTemplates
	{
		public FormulaireSimplifieResponsableTemplate FormulaireSimplifieResponsable { get; set; } = default!;
		public FormulaireSimplifieUtilisateurTemplate FormulaireSimplifieUtilisateur { get; set; } = default!;
    }

	public class MailInfosTemplate
	{
		public string Subject { get; set; } = default!;
		public string Path { get; set; } = default!;
	}

	public class FormulaireSimplifieResponsableTemplate : MailInfosTemplate
	{

	}

	public class FormulaireSimplifieUtilisateurTemplate : MailInfosTemplate
	{

	}
}

