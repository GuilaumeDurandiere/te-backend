namespace PortailTE44.Common.Models
{
	public class MailTemplates
	{
		public FormulaireSimplifieResponsableTemplate FormulaireSimplifieResponsable { get; set; } = default!;
		public FormulaireSimplifieUtilisateurTemplate FormulaireSimplifieUtilisateur { get; set; } = default!;
		public FormulaireAdhesionResponsableOffreTemplate FormulaireAdhesionResponsableOffre { get; set; } = default!;
		public FormulaireAdhesionResponsableCollectiviteTemplate FormulaireAdhesionResponsableCollectivite { get; set; } = default!;
		public FormulaireDemandeAffaireResponsableTemplate FormulaireDemandeAffaireResponsable { get; set; } = default!;
		public FormulaireDemandeAffaireUtilisateurTemplate FormulaireDemandeAffaireUtilisateur { get; set; } = default!;
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

    public class FormulaireAdhesionResponsableOffreTemplate : MailInfosTemplate
    {

    }

    public class FormulaireAdhesionResponsableCollectiviteTemplate : MailInfosTemplate
    {

    }

	public class FormulaireDemandeAffaireResponsableTemplate : MailInfosTemplate
	{

	}

	public class FormulaireDemandeAffaireUtilisateurTemplate : MailInfosTemplate
	{

	}
}

