using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Auth.Register
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //UserName daha önce kullanılmış mı 
            var checkUserNameExist = await _userManager.FindByNameAsync(request.UserName);
            if (checkUserNameExist is not null) 
            {
                throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
            }

            var checkEmailExist = await _userManager.FindByEmailAsync(request.Email);
            if (checkEmailExist is not null)
            {
                throw new ArgumentException("Bu mail adresi daha önce kullanılmış!");
            }

            //eğer kullanılmamışlarsa
            AppUser appUser = new()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Name = request.Name,
                LastName = request.Lastname,
                UserName = request.UserName,
            };

            await _userManager.CreateAsync(appUser, request.Password);
            
            return Unit.Value;
        }
    }
}
