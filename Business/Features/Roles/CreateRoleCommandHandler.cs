using Business.Features.Roles;
using EntitiesProject.Models;
using EntitiesProject.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
{
    private readonly IRoleRepository _roleManager;
    private readonly IUnitOfWork _unitOfWork;
    public CreateRoleCommandHandler(IRoleRepository roleManager, IUnitOfWork unitOfWork)
    {
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var checkRoleIsExits = await _roleManager.AnyAsync(p => p.Name == request.Name);
        if (checkRoleIsExits)
        {
            throw new ArgumentException("Bu Rol Daha Öncesinde Oluşturulmuş");
        }
        AppRole appRole = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await _roleManager.AddAsync(appRole);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
