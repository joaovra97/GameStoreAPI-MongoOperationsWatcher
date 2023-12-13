using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IAutoFakerFacadeService
    {
        public Game GenerateGame();
        public User GenerateUser();
        public Purchase GeneratePurchase(User user, List<Game> games);
        public Game UpdateGamePrice(Game game);
    }
}
