using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Services.SubModules.LogicLayers.Workers.Entities
{
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

        protected BaseWorker(IServiceProvider serviceProvider, ILogger<T> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{Name} is starting.");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{Name} is stopping.");

            return base.StopAsync(cancellationToken);
        }

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

        protected abstract Task<bool> IsExecuteAsync(IServiceScope serviceScope, CancellationToken cancellationToken);

        protected abstract Task RunAsync(IServiceScope serviceScope, CancellationToken cancellationToken);

        protected virtual Task AfterAsync(IServiceScope serviceScope, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
