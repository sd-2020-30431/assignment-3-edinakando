using System.Threading.Tasks;

namespace WastelessAPI.Mediator
{
    public interface IMediator
    {
        public Task<TResponse> Handle<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;
    }
}