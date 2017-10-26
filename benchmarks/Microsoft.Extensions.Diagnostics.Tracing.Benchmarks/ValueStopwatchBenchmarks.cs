using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace Microsoft.Extensions.Diagnostics.Tracing.Benchmarks
{
    public class ValueStopwatchBenchmarks
    {
        public const int InnerLoopIterations = 1000;
        private TimeSpan _current;
        private object _box;

        [Benchmark(Baseline = true, OperationsPerInvoke = InnerLoopIterations)]
        public void UsingExistingStopwatch()
        {
            for(var i = 0; i < InnerLoopIterations; i += 1)
            {
                var sw = Stopwatch.StartNew();
                sw.Stop();

                // Force the property to be invoked
                _current = sw.Elapsed;
            }
        }

        [Benchmark(OperationsPerInvoke = InnerLoopIterations)]
        public void UsingValueStopwatch()
        {
            for(var i = 0; i < InnerLoopIterations; i += 1)
            {
                var sw = ValueStopwatch.StartNew();
                sw.Stop();

                // Force the property to be invoked
                _current = sw.Elapsed;
            }
        }

        [Benchmark(OperationsPerInvoke = InnerLoopIterations)]
        public void UsingValueStopwatchWithBoxing()
        {
            for(var i = 0; i < InnerLoopIterations; i += 1)
            {
                var sw = ValueStopwatch.StartNew();
                sw.Stop();

                // Put it in the box
                _box = sw;

                // Take it back out
                sw = (ValueStopwatch)_box;

                // Force the property to be invoked
                _current = sw.Elapsed;
            }
        }
    }
}
