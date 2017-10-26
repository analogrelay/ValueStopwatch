using System;
using BenchmarkDotNet.Running;

namespace Microsoft.Extensions.Diagnostics.Timing.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
