using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
	public class Game
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Title { get; set; }
		public string Developer { get; set; }
		public Genre Genre { get; set; }
		public decimal Price { get; set; }
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
