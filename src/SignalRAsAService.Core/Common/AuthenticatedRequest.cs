using SignalRAsAService.Core.Interfaces;
using MediatR;
using System;

namespace SignalRAsAService.Core.Common
{
    public class AuthenticatedRequest<TResponse> : IAuthenticatedRequest, IRequest<TResponse>
    {
        public Guid CurrentUserId { get; set; }
    }
}
