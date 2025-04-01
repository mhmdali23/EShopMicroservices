namespace Catalog.Api.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id,string Name,string Description,List<string> Category,string ImageFile,decimal Price)
        :ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);


    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(2,50).WithMessage("Name should be between 2 and 50 characters");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price should be greater than 0");

        }
    }
    public class UpdateProductCommandHandler(IDocumentSession _session) 
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException(command.Id);
            }
            product.Name = command.Name;
            product.Description = command.Description;
            product.Category = command.Category;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            _session.Update(product);

            await _session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(true);
        }
    }
   
}
