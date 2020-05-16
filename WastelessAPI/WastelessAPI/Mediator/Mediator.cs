﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WastelessAPI.Handlers;
using WastelessAPI.Queries;

namespace WastelessAPI.Mediator
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, Type> _handlerMap;
        private IServiceProvider _serviceProvider;
        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _handlerMap = new Dictionary<Type, Type>{
            { typeof(GetCharitiesQuery), typeof(GetCharitiesHandler)} };
        }

        public Task<TResponse> Handle<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        {
            var handlerType = _handlerMap[typeof(TRequest)];
            var handler = _serviceProvider.GetService(handlerType) as IRequestHandler<TRequest, TResponse>;
          
            return handler.Handle(request);
        }
    }
}