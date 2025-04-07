namespace Basket.Api.Basket.GetBasket
{
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("basket/{userName}", async (string userName,ISender _sender, CancellationToken ct) =>
            {
                var basket = await _sender.Send(new GetBasketQuery(userName), ct);

                var response = basket.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            })
             .Produces<GetBasketResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithName("Get Basket")
             .WithDescription("Get the basket for a user")
             .WithSummary("Get Basket");

        }
    }
}
