using System;
using System.Diagnostics;

namespace Microsoft.Extensions.Diagnostics.Timing
{
    public struct ValueStopwatch
    {
        private static readonly double TimestampToTicks = TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency;

        private bool _enabled;
        private long _endTimestamp;
        private long _startTimestamp;

        public bool Enabled => _enabled;
        public TimeSpan Elapsed => ComputeElapsedTime();

        private ValueStopwatch(long startTimestamp)
        {
            _enabled = true;
            _endTimestamp = 0;
            _startTimestamp = 0;
        }

        public void Stop()
        {
            _endTimestamp = Stopwatch.GetTimestamp();
            _enabled = false;
        }

        public static ValueStopwatch StartNew() => new ValueStopwatch(Stopwatch.GetTimestamp());

        private TimeSpan ComputeElapsedTime()
        {
            var end = _endTimestamp == 0 ? Stopwatch.GetTimestamp() : _endTimestamp;
            var timestampDelta = end - _startTimestamp;
            var ticks = (long)(TimestampToTicks * timestampDelta);
            return new TimeSpan(ticks);
        }
    }
}
