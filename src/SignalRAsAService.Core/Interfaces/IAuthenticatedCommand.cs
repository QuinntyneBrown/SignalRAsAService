using MediatR;

namespace SignalRAsAService.Core.Interfaces
{
    public interface IAuthenticatedCommand<TResponse>: IAuthenticatedRequest, IRequest<TResponse>, ICommand<TResponse>
    {
    }
}
