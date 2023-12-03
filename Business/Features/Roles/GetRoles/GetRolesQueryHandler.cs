using EntitiesProject.Models;
using EntitiesProject.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Features.Roles.GetRoles
{
    internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<GetRolesQueryResponse>>
    {
        private readonly IRoleRepository _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public GetRolesQueryHandler(IRoleRepository roleManager, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetRolesQueryResponse>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var response = await _roleManager.GetAll().Select(s => new GetRolesQueryResponse(s.Id, s.Name)).ToListAsync(cancellationToken);
            return response;
        }
    }
}
