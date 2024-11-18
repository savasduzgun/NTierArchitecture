using MediatR;

namespace NTierArchitecture.Business.Features.Products.CreateProduct
{
    public sealed record CreateProductCommand(
         string Name) : IRequest;
}
