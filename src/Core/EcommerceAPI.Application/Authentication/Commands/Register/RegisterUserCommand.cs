using EcommerceAPI.Application.Common.Models;
using MediatR;

namespace EcommerceAPI.Application.Authentication.Commands.Register;

public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName
) : IRequest<AuthResult>;
