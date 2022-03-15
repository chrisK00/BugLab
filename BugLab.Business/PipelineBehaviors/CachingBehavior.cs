using BugLab.Business.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.PipelineBehaviors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

        public CachingBehavior(IMemoryCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;
            TResponse response;
            
            if (_cache.TryGetValue(request.Key, out response))
            {
                _logger.LogInformation("Returning cached value for {requestName}", requestName);
                return response;
            }

            response = await next();
            if (response == null) return response;

            _logger.LogInformation("Caching {requestName} response with Cache Key: {Key}", requestName, request.Key);
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

            _cache.Set(request.Key, response, cacheOptions);
            return response;
        }
    }
}
