
namespace Basket.Api.Basket.DeleteBasket
{
    public record DeleteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName,ISender _sender) =>
            {
                var result = await _sender.Send(new DeleteBasketCommand(userName));
                var response = result.Adapt<DeleteBasketResponse>();

                return Results.Ok(response);
            })
            .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithName("DeleteBasket")
            .WithSummary("Deletes a shopping cart")
            .WithDescription("Deletes a shopping cart for a user");
        }
    }
   
}
