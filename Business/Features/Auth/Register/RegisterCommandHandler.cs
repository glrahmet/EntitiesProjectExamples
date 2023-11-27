using EntitiesProject.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Features.Auth.Register
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
            var checkUserNameExits = await _userManager.FindByNameAsync(request.UserName);
            if (checkUserNameExits is  null)
            {

            }
            else
                throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmıştır.");

            var checkUserEmailExits = await _userManager.FindByEmailAsync(request.Email);
            if (checkUserNameExits is  null)
            {

            }
            else
                throw new ArgumentException("Bu Email Adresi daha önce kullanılmıştır.");

            AppUser appUser = new AppUser()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.UserName
            };

            await _userManager.CreateAsync(appUser, request.Password);
            return Unit.Value;
        }
    }
}
