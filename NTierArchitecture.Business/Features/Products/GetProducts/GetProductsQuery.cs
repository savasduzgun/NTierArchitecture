using MediatR;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Products.GetProducts
{
    public sealed record class GetProductsQuery() : IRequest<List<Product>>;
}
