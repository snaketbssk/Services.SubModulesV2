using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.SubModules.LogicLayers.Workers.Entities
{
    /// <summary>
    /// Base class for creating background workers with periodic execution.
    /// </summary>
    /// <typeparam name="T">The type of the worker class.</typeparam>
    public abstract class BaseWorker<T> : BackgroundService
    {
        protected readonly ILogger<T> _logger;
        protected readonly IServiceProvider _serviceProvider;

        protected abstract int SecondsRefresh { get; }
        protected abstract string Name { get; }
        private int _seconds { get; set; }

        private const int SECONDS_PERIOD = 10;
        private const int DELAY = SECONDS_PERIOD * 1000;
        private const int START_DELAY = 50 * 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseWorker{T}"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider for dependency injection.</param>
        /// <param name="logger">The logger instance for logging.</param>
        protected BaseWorker(IServiceProvider serviceProvider, ILogger<T> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <summary>
        /// Starts the background worker asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            // Log that the worker is starting
            _logger.LogInformation($"{Name} is starting.");

            // Call the base method to start the background service
            return base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Stops the background worker asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            // Log that the worker is stopping
            _logger.LogInformation($"{Name} is stopping.");

            // Call the base method to stop the background service
            return base.StopAsync(cancellationToken);
        }


        /// <summary>
        /// Handles exceptions by logging errors.
        /// </summary>
        /// <param name="exception">The exception to be logged.</param>
        protected virtual void Exception(Exception exception)
        {
            _logger.LogError(null, exception);
        }

        private void StartSeconds()
        {
            _seconds = SecondsRefresh;
        }

        private bool IncrementSeconds()
        {
            _seconds += SECONDS_PERIOD;
            if (_seconds >= SecondsRefresh)
            {
                _seconds = 0;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Executes the background worker asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            StartSeconds();
            await Task.Delay(START_DELAY, cancellationToken);

            _logger.LogInformation($"{Name} is running.");

            while (!cancellationToken.IsCancellationRequested)
                await RunAsync(cancellationToken);
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(DELAY, cancellationToken);
            var isIncrementSeconds = IncrementSeconds();

            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var isExecute = false;

                try
                {
                    isExecute = await IsExecuteAsync(serviceScope, cancellationToken);
                }
                catch (Exception exception)
                {
                    Exception(exception);
                }

                try
                {
                    if (isIncrementSeconds || isExecute)
                        await RunAsync(serviceScope, cancellationToken);
                }
                catch (Exception exception)
                {
                    Exception(exception);
                }

                try
                {
                    await AfterAsync(serviceScope, cancellationToken);
                }
                catch (Exception exception)
                {
                    Exception(exception);
                }
            }
        }

        /// <summary>
        /// Checks if the worker should execute.
        /// </summary>
        /// <param name="serviceScope">The service scope for resolving dependencies.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation. True if the worker should execute; otherwise, false.</returns>
        protected abstract Task<bool> IsExecuteAsync(IServiceScope serviceScope, CancellationToken cancellationToken);

        /// <summary>
        /// Executes the main logic of the worker.
        /// </summary>
        /// <param name="serviceScope">The service scope for resolving dependencies.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        protected abstract Task RunAsync(IServiceScope serviceScope, CancellationToken cancellationToken);

        /// <summary>
        /// Executes cleanup logic after each cycle of the worker.
        /// </summary>
        /// <param name="serviceScope">The service scope for resolving dependencies.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual Task AfterAsync(IServiceScope serviceScope, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
