namespace Catalog.Api.Products.GetProductById
{
    //public record GetProductByIdRequest([property: FromRoute(Name = "id")] Guid Id);
    public record GetProductByIdResponse(Product Product) { }
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (ISender _sender,Guid Id) =>
            {

                var result = await _sender.Send(new GetProductByIdQuery(Id));

                var response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
   
}
