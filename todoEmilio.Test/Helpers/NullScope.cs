using System;
using System.Collections.Generic;
using System.Text;

namespace todoEmilio.Test.Helpers
{
    class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        public void Dispose(){}

        private NullScope() { }
    }
}
