using SignalRAsAService.Core.Identity;
using SignalRAsAService.Core.Interfaces;
using SignalRAsAService.Core.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRAsAService.API.Features.Users
{
    public class AuthenticateCommand
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Username).NotEqual(default(string));
                RuleFor(request => request.Password).NotEqual(default(string));
            }            
        }

        public class Request : IRequest<Response>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Response
        {
            public string AccessToken { get; set; }
            public Guid UserId { get; set; }
            public IEnumerable<string> Roles { get; set; }
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IPasswordHasher _passwordHasher;
            private readonly ISecurityTokenFactory _securityTokenFactory;

            public Handler(
                ISecurityTokenFactory securityTokenFactory, 
                IPasswordHasher passwordHasher)
            {
                _securityTokenFactory = securityTokenFactory;
                _passwordHasher = passwordHasher;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {                                
                return await Task.FromResult(new Response()
                {

                });
            }            
        }
    }
}
