using System.Diagnostics;

namespace Application.Response
{
	public class GamesByUsersResponse : DefaultResponse
	{
		public List<GamesByUsersItem> Response { get; set; }

        public GamesByUsersResponse(Stopwatch stopwatch, List<GamesByUsersItem> response) : base(stopwatch)
        {
            Response = response;
        }
    }

	public class GamesByUsersItem
	{
		public string UserName { get; set; }
		public List<string> GamesPurchased { get; set; }
		public int TotalPurchases { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
