﻿using System.Threading.Tasks;

namespace WastelessAPI.Mediator
{
    public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
