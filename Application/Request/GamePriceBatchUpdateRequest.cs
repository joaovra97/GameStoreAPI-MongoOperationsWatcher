namespace Application.Request
{
	public class GamePriceBatchUpdateRequest
	{
		public int TotalItems { get; set; }
		public int MaxParallel { get; set; }
	}
}
