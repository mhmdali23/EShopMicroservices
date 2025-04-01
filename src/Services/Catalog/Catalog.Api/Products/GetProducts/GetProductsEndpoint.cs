namespace Catalog.Api.Products.GetProducts
{
    public record GetProductsRequest(int PageNumber = 1,int PageSize = 10);
    public record GetProductsResponse(IEnumerable<Product> Products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest req, ISender _sender) =>
            {

                var query = req.Adapt<GetProductsQuery>();

                var result = await _sender.Send(query);

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
                .WithName("Get Products")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
