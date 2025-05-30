﻿
namespace Catalog.Api.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler(IDocumentSession _session) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _session.LoadAsync<Product>(query.Id, cancellationToken);

            if(product == null)
            {
                throw new ProductNotFoundException(query.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}
