using System.Diagnostics.Tracing;
using BenchmarkDotNet.Attributes;

namespace Microsoft.Extensions.Diagnostics.Tracing.Benchmarks
{
    public class EventSourceBenchmarks
    {
        public const int InnerLoopCount = 1000;

        private DummyListener _listener = new DummyListener();

        [GlobalSetup(Target = nameof(EventSourceEnabled))]
        public void Setup()
        {
            _listener.EnableEvents(BenchmarkTestEventSource.Log, EventLevel.Verbose);
        }

        [GlobalSetup(Target = nameof(EventSourceEnabledButNotAtLevel))]
        public void SetupNotAtLevel()
        {
            _listener = new DummyListener();
            _listener.EnableEvents(BenchmarkTestEventSource.Log, EventLevel.Informational);
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _listener.DisableEvents(BenchmarkTestEventSource.Log);
        }

        [Benchmark(Baseline = true, OperationsPerInvoke = InnerLoopCount)]
        public void NoEventSource()
        {
            for (var i = 0; i < InnerLoopCount; i += 1)
            {
                // Do nothing!
            }
        }

        [Benchmark(OperationsPerInvoke = InnerLoopCount)]
        public void EventSourceEnabled()
        {
            for (var i = 0; i < InnerLoopCount; i += 1)
            {
                BenchmarkTestEventSource.Log.Event();
                // Do nothing!
            }
        }

        [Benchmark(OperationsPerInvoke = InnerLoopCount)]
        public void EventSourceEnabledButNotAtLevel()
        {
            for (var i = 0; i < InnerLoopCount; i += 1)
            {
                BenchmarkTestEventSource.Log.Event();
                // Do nothing!
            }
        }

        [Benchmark(OperationsPerInvoke = InnerLoopCount)]
        public void EventSourceDisabled()
        {
            for (var i = 0; i < InnerLoopCount; i += 1)
            {
                BenchmarkTestEventSource.Log.Event();
                // Do nothing!
            }
        }

        public class DummyListener : EventListener
        {
            public DummyListener()
            {
            }
        }
    }

    public class BenchmarkTestEventSource : EventSource
    {
        public static readonly BenchmarkTestEventSource Log = new BenchmarkTestEventSource();

        private BenchmarkTestEventSource() { }

        [Event(eventId: 1, Level = EventLevel.Verbose)]
        public void Event()
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                WriteEvent(1);
            }
        }
    }
}
