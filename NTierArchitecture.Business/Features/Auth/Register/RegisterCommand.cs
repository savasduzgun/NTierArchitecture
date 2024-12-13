using MediatR;

namespace NTierArchitecture.Business.Features.Auth.Register
{
    //request içerisinde kullanıcı kaydı yapmak için gerekli olan verileri ister
    public sealed record RegisterCommand(
        string Name,
        string Lastname,
        string Email,
        string Password): IRequest<Unit>;
}
