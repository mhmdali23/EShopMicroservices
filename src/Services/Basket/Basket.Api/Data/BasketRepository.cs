
namespace Basket.Api.Data
{
    public class BasketRepository(IDocumentSession _session) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await _session.LoadAsync<ShoppingCart>(userName, cancellationToken);

            return basket is null ? throw new BasketNotFoundException(userName) : basket; 
        }

        public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            _session.Store(basket);
            await _session.SaveChangesAsync(cancellationToken);
            return basket;
        }

        public async Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            if(await GetBasketAsync(userName, cancellationToken) is null)
                return false;
            _session.Delete<ShoppingCart>(userName);
            await _session.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
