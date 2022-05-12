namespace ExampleConfiguration.Watchers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using ExampleConfiguration.Contracts;

    using Microsoft.Extensions.Primitives;

    public class Watcher : ISqlServerWatcher
    {
        private IChangeToken _changeToken;
        private CancellationTokenSource _cancellationTokenSource;

        public Watcher()
        {

        }

        private void Change(object state)
        {
            _cancellationTokenSource?.Cancel();
        }

        public IChangeToken Refresh()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _changeToken = new CancellationChangeToken(_cancellationTokenSource.Token);

            return _changeToken;
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }
    }
}
