namespace Domain.Entities
{
	public abstract class Game
	{
		public virtual string Id { get; set; }
		public virtual string Title { get; set; }
		public virtual string Developer { get; set; }
		public virtual Genre Genre { get; set; }
		public virtual float Price { get; set; }
	}

	public enum Genre
	{
		Action = 1,
		Adventure = 2,
		RolePlaying = 3,
		Simulation = 4,
		Strategy = 5,
		Sports = 6,
		Puzzle = 7,
		Idle = 8
	}
}
