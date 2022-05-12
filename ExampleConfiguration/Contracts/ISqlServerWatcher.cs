namespace ExampleConfiguration.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Primitives;

    public interface ISqlServerWatcher : IDisposable
    {
        IChangeToken Refresh();
    }
}

