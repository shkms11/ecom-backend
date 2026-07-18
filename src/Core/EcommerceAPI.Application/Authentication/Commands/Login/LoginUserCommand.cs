using EcommerceAPI.Application.Common.Models;
using MediatR;

namespace EcommerceAPI.Application.Authentication.Commands.Login;

public sealed record LoginUserCommand(string Email, string Password) : IRequest<AuthResult>;
