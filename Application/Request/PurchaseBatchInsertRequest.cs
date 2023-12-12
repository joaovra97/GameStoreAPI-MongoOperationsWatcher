namespace Application.Request
{
	public class PurchaseBatchInsertRequest
	{
		public int TotalItems { get; set; }
		public int MaxParallel { get; set; }
		public int GamesRange { get; set; }
		public int UsersRange { get; set; }
	}
}
