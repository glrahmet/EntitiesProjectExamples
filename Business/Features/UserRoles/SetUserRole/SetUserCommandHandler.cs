using EntitiesProject.Models;
using MediatR;

namespace Business.Features.UserRoles.SetUserRole
{
    internal sealed class SetUserCommandHandler : IRequestHandler<SetUserRoleCommand, Unit>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetUserCommandHandler(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            var checkIsRoleSetExits = await _userRoleRepository.AnyAsync(p => p.AppUserId == request.UserId && p.AppRoleId == request.RoleId, cancellationToken);
            if (checkIsRoleSetExits)
            {
                throw new ArgumentException("Kullanıcı zate bu role sahip");
            }

            UserRole userRole = new()
            {
                AppRoleId = request.RoleId,
                AppUserId = request.UserId,
            };
            await _userRoleRepository.AddAsync(userRole, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
