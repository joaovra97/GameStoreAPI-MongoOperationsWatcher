using Domain.Entities;

namespace Application.Services
{
    public interface IAutoFakerFacadeService
    {
        public Game GenerateGame();
        public User GenerateUser();
        public Purchase GeneratePurchase(User user, List<Game> games);
        public Game UpdateGamePrice(Game game);
    }
}
