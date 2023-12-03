using Business.Features.UserRoles.SetUserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;

public sealed class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SetRole(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}
