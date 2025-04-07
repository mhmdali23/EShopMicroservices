
namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest req,ISender _sender) =>
            {
                var command = req.Adapt<StoreBasketCommand>();
                var result = await _sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();

                return Results.Created($"/basket/{response.UserName}", response);
            })
            .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName("StoreBasket")
            .WithSummary("Stores a shopping cart")
            .WithDescription("Stores a shopping cart for a user");
        }
    }
}
