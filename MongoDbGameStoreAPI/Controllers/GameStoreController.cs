using Application.Services;
using Infra;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
	[ApiController]	
	public class GameStoreController : ControllerBase
	{
		private readonly IGameStorageService _gameStorageService;

		public GameStoreController(IGameStorageService gameStorageService)
		{
			_gameStorageService = gameStorageService;
		}

		[SwaggerOperation(Summary = "descrição", Tags = new[] { "tag" })]
		[SwaggerResponse(200, "sucesso", typeof(string))]
		[HttpPost("execute/{provider}")]
		public IActionResult Execute([FromRoute] Provider provider)
		{			
			_gameStorageService.SetProvider(provider);
			return Ok();
		}
	}
}
