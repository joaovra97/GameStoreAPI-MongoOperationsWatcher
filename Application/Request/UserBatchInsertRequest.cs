namespace Application.Request
{
	public class UserBatchInsertRequest
	{
		public int TotalItems { get; set; }
		public int MaxParallel { get; set; }
	}
}
