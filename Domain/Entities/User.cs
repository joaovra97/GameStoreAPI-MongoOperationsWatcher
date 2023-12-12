namespace Domain.Entities
{
	public abstract class User
	{
		public virtual string Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Address { get; set; }
	}
}
