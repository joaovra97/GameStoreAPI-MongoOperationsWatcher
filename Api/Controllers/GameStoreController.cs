using Application.Request;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using System.Diagnostics;
using Application;

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
		
		[HttpPost("{provider}/game-batch-insert")]
		public IActionResult GameBatchInsert([FromRoute] Provider provider, [FromBody] GameBatchInsertRequest request)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try 
			{
				_gameStorageService.SetProvider(provider);
				_gameStorageService.GameBatchInsert(request);
				stopwatch.Stop();
				return Ok(stopwatch);
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new { stopwatch, errorMessage = ex.Message });
			}
		}

		[HttpPost("{provider}/user-batch-insert")]
		public IActionResult UserBatchInsert([FromRoute] Provider provider, [FromBody] UserBatchInsertRequest request)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				_gameStorageService.SetProvider(provider);
				_gameStorageService.UserBatchInsert(request);
				stopwatch.Stop();
				return Ok(stopwatch);
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new { stopwatch, errorMessage = ex.Message });				
			}
		}

		[HttpPost("{provider}/purchase-batch-insert")]
		public IActionResult PurchaseBatchInsert([FromRoute] Provider provider, [FromBody] PurchaseBatchInsertRequest request)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				_gameStorageService.SetProvider(provider);
				_gameStorageService.PurchaseBatchInsert(request);
				stopwatch.Stop();
				return Ok(stopwatch);
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new { stopwatch, errorMessage = ex.Message });
			}
		}


		[HttpPost("{provider}/game-price-batch-update")]
		public IActionResult GamePriceBatchUpdate([FromRoute] Provider provider, [FromBody] GamePriceBatchUpdateRequest request)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				_gameStorageService.SetProvider(provider);
				_gameStorageService.GamePriceBatchUpdate(request);
				stopwatch.Stop();
				return Ok(stopwatch);
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new { stopwatch, errorMessage = ex.Message });
			}
		}

		[HttpPost("{provider}/games-by-user")]
		public IActionResult GamesByUsers([FromRoute] Provider provider, [FromBody] GamesByUserRequest request)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				_gameStorageService.SetProvider(provider);
				var response = _gameStorageService.GamesByUsers(request);
				stopwatch.Stop();
				return Ok(new { stopwatch, response });
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new { stopwatch, errorMessage = ex.Message });
			}
		}
	}
}
