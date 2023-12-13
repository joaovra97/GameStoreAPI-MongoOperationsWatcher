using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Application.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using Application.Response;

namespace Api.Controllers
{
	//[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class GameStoreController : ControllerBase
	{
		private readonly IGameStorageService _gameStorageService;

		public GameStoreController(IGameStorageService gameStorageService)
		{
			_gameStorageService = gameStorageService;
		}

		/// <summary>
		/// Insert a batch of games.
		/// </summary>
		/// <param name="totalItems">Total number of items to be inserted.</param>
		/// <param name="maxParallel">Maximum number of concurrent threads.</param>
		/// <returns></returns>
		[HttpPost("game-batch-insert")]
		[SwaggerResponse(200, "Success", typeof(DefaultResponse))]
		[SwaggerResponse(400, "Bad request", typeof(ErrorResponse))]
		[SwaggerResponse(500, "Internal server error", typeof(ErrorResponse))]
		public async Task<IActionResult> GameBatchInsertAsync([FromQuery] int totalItems = 100, [FromQuery] int maxParallel = 5)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				ValidateParams(totalItems, maxParallel);

				await _gameStorageService.GameBatchInsertAsync(totalItems, maxParallel);
				stopwatch.Stop();
				return Ok(new DefaultResponse(stopwatch));
			}
			catch (ArgumentException ex)
			{
				stopwatch.Stop();
				return BadRequest(new ErrorResponse(stopwatch, ex.Message));
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(stopwatch, ex.Message));
			}
		}

		/// <summary>
		/// Insert a batch of users.
		/// </summary>
		/// <param name="totalItems">Total number of items to be inserted.</param>
		/// <param name="maxParallel">Maximum number of concurrent threads.</param>
		/// <returns></returns>
		[HttpPost("user-batch-insert")]
		[SwaggerResponse(200, "Success", typeof(DefaultResponse))]
		[SwaggerResponse(400, "Bad request", typeof(ErrorResponse))]
		[SwaggerResponse(500, "Internal server error", typeof(ErrorResponse))]
		public async Task<IActionResult> UserBatchInsertAsync([FromQuery] int totalItems = 100, [FromQuery] int maxParallel = 5)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				ValidateParams(totalItems, maxParallel);

				await _gameStorageService.UserBatchInsertAsync(totalItems, maxParallel);
				stopwatch.Stop();
				return Ok(new DefaultResponse(stopwatch));
			}
			catch (ArgumentException ex)
			{
				stopwatch.Stop();
				return BadRequest(new ErrorResponse(stopwatch, ex.Message));
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(stopwatch, ex.Message));
			}
		}

		/// <summary>
		/// Insert a batch of purchases.
		/// </summary>
		/// <param name="totalItems">Total number of items to be inserted.</param>
		/// <param name="maxParallel">Maximum number of concurrent threads.</param>
		/// <param name="gamesRange">Last games to be randomly selected to create purchases.</param>
		/// <param name="usersRange">Last users to be randomly selected to create purchases.</param>
		/// <returns></returns>
		[HttpPost("purchase-batch-insert")]
		[SwaggerResponse(200, "Success", typeof(DefaultResponse))]
		[SwaggerResponse(400, "Bad request", typeof(ErrorResponse))]
		[SwaggerResponse(500, "Internal server error", typeof(ErrorResponse))]
		public async Task<IActionResult> PurchaseBatchInsertAsync([FromQuery] int totalItems = 100, [FromQuery] int maxParallel = 5, [FromQuery] int gamesRange = 100, [FromQuery] int usersRange = 100)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				ValidateParams(totalItems, maxParallel, gamesRange, usersRange);

				await _gameStorageService.PurchaseBatchInsertAsync(totalItems, maxParallel, gamesRange, usersRange);
				stopwatch.Stop();
				return Ok(new DefaultResponse(stopwatch));
			}
			catch (ArgumentException ex)
			{
				stopwatch.Stop();
				return BadRequest(new ErrorResponse(stopwatch, ex.Message));
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(stopwatch, ex.Message));
			}
		}

		/// <summary>
		/// Updates the price of a batch of games.
		/// </summary>
		/// <param name="totalItems">Total number of items to be inserted.</param>
		/// <param name="maxParallel">Maximum number of concurrent threads.</param>
		/// <returns></returns>
		[HttpPost("game-price-batch-update")]
		[SwaggerResponse(200, "Success", typeof(DefaultResponse))]
		[SwaggerResponse(400, "Bad request", typeof(ErrorResponse))]
		[SwaggerResponse(500, "Internal server error", typeof(ErrorResponse))]
		public async Task<IActionResult> GamePriceBatchUpdateAsync([FromQuery] int totalItems = 100, [FromQuery] int maxParallel = 5)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				ValidateParams(totalItems, maxParallel);

				await _gameStorageService.GamePriceBatchUpdateAsync(totalItems, maxParallel);
				stopwatch.Stop();
				return Ok(new DefaultResponse(stopwatch));
			}
			catch (ArgumentException ex)
			{
				stopwatch.Stop();
				return BadRequest(new ErrorResponse(stopwatch, ex.Message));
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(stopwatch, ex.Message));
			}
		}

		/// <summary>
		/// Get a list of users and their purchased games.
		/// </summary>
		/// <param name="usersRange">Last users to be randomly selected to create purchases.</param>
		/// <param name="maxParallel">Maximum number of concurrent threads.</param>
		/// <returns></returns>
		[HttpPost("games-by-user")]
		[SwaggerResponse(200, "Success", typeof(GamesByUsersResponse))]
		[SwaggerResponse(400, "Bad request", typeof(ErrorResponse))]
		[SwaggerResponse(500, "Internal server error", typeof(ErrorResponse))]
		public async Task<IActionResult> GamesByUsersAsync([FromQuery] int usersRange = 100, [FromQuery] int maxParallel = 5)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();

			try
			{
				ValidateParams(usersRange, maxParallel);

				var response = await _gameStorageService.GamesByUsersAsync(usersRange, maxParallel);
				stopwatch.Stop();
				return Ok(new GamesByUsersResponse(stopwatch, response));
			}
			catch (ArgumentException ex)
			{
				stopwatch.Stop();
				return BadRequest(new ErrorResponse(stopwatch, ex.Message));
			}
			catch (Exception ex)
			{
				stopwatch.Stop();
				return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse(stopwatch, ex.Message));
			}
		}

		private static void ValidateParams(params int[] parameters)
		{
			foreach (var param in parameters)
				if (param == 0) throw new ArgumentException("0 is not allowed");
		}
	}
}
