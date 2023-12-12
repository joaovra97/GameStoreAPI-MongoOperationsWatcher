namespace Application.Request
{
	public class GameBatchInsertRequest
	{
		public int TotalItems { get; set; }
		public int MaxParallel { get; set; }
	}
}
