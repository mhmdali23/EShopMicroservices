﻿using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[Strat] Handle Request = {Request} - Response = {Response} - RequestData = {RequestData}",
                typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();

            var timeTaken = timer.Elapsed;

            if (timeTaken.Seconds > 3)
            {
                logger.LogWarning("[Perfomance] Handle Request ={Request}- TimeTaken = {TimeTaken}",
                    typeof(TRequest).Name, timeTaken.Seconds);
            }

            logger.LogInformation("[End] Handle Request = {Request} With Response = {Response} - TimeTaken = {TimeTaken} ",
            typeof(TRequest).Name, typeof(TResponse).Name, timeTaken.Seconds);

            return response;

        }
    }
}
