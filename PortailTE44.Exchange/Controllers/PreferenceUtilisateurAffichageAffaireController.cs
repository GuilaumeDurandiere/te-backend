using Microsoft.AspNetCore.Mvc;
using PortailTE44.Business.Services.Interfaces;
using PortailTE44.Common.Dtos.PreferenceUtilisateurAffichageAffaire;

namespace PortailTE44.Exchange.Controllers
{
    [ApiController]
    [Route("api/preferenceUtilisateurAffichageAffaire")]
    public class PreferenceUtilisateurAffichageAffaireController
	{
		IPreferenceUtilisateurAffichageAffaireService _preferenceUtilisateurAffichageAffaireService;

		public PreferenceUtilisateurAffichageAffaireController(IPreferenceUtilisateurAffichageAffaireService preferenceUtilisateurAffichageAffaireService)
		{
			_preferenceUtilisateurAffichageAffaireService = preferenceUtilisateurAffichageAffaireService;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<PreferenceUtilisateurAffichageAffaireResponseDto> Get(int utilisateurId)
		{
			return await _preferenceUtilisateurAffichageAffaireService.Get(utilisateurId);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<PreferenceUtilisateurAffichageAffaireResponseDto> Create([FromBody] PreferenceUtilisateurAffichageAffaireCreatePayloadDto dto)
		{
			return await _preferenceUtilisateurAffichageAffaireService.Create(dto);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<PreferenceUtilisateurAffichageAffaireResponseDto> Update(PreferenceUtilisateurAffichageAffaireUpdatePayloadDto dto)
		{
			return await _preferenceUtilisateurAffichageAffaireService.Update(dto);
		}

		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task Delete(int utilisateurId)
		{
			await _preferenceUtilisateurAffichageAffaireService.Delete(utilisateurId);
		}
	}
}

