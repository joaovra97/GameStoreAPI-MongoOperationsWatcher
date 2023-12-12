using Application.Request;
using Application.Response;

namespace Application.Services
{
	public interface IGameStorageService
	{
		void GameBatchInsert(GameBatchInsertRequest request);
		void UserBatchInsert(UserBatchInsertRequest request);
		void PurchaseBatchInsert(PurchaseBatchInsertRequest request);
		void GamePriceBatchUpdate(GamePriceBatchUpdateRequest request);
		List<GamesByUsersResponse> GamesByUsers(GamesByUserRequest request);
		void SetProvider(Provider provider);
	}
}
