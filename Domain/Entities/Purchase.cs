namespace Domain.Entities
{
	public abstract class Purchase
	{
		public virtual string Id { get; set; }
		public virtual string UserId { get; set; }
		public virtual string UserName { get; set; }
		public virtual List<PurchaseGame> Games { get; set; }
		public virtual DateTime PurchaseDate { get; set; }
		public virtual float TotalPrice { get; set; }
		public virtual PaymentMethod PaymentMethod { get; set; }
	}

	public abstract class PurchaseGame
	{
		public virtual string Id { get; set; }
		public virtual string Title { get; set; }
		public virtual float PriceAtPurchase { get; set; }
	}

	public enum PaymentMethod
	{
		Cash = 1,
		Debit = 2,
		Credit = 3
	}
}
