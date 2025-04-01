
namespace Catalog.Api.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProducCommandtValidator :AbstractValidator<DeleteProductCommand>
    {
        public DeleteProducCommandtValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
    internal class DeleteProducCommandtHandler(IDocumentSession _session)
        : ICommandHandler<DeleteProductCommand,DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _session.LoadAsync<Product>(command.Id,cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException(command.Id);
            }
            _session.Delete(product);
            await _session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
        }
    }
}
