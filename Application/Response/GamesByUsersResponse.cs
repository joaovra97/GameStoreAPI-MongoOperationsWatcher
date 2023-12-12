namespace Application.Response
{
	public class GamesByUsersResponse
	{
		public string UserName { get; set; }
		public List<string> GamesPurchased { get; set; }
		public int TotalPurchases { get; set; }
		public float TotalPrice { get; set; }
	}
}
