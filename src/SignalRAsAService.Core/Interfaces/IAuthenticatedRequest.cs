using MediatR;
using System;

namespace SignalRAsAService.Core.Interfaces
{
    public interface IAuthenticatedRequest
    {
        Guid CurrentUserId { get; set; }
    }
}
