using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
	public class Purchase
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }		
		public string UserId { get; set; }
		public string UserName { get; set; }
		public List<PurchaseGame> Games { get; set; }
		public DateTime PurchaseDate { get; set; }
		public decimal TotalPrice { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
	}

	public class PurchaseGame
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public decimal PriceAtPurchase { get; set; }
	}

	public enum PaymentMethod
	{
		Cash = 1,
		Debit = 2,
		Credit = 3
	}
}
