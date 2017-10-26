# ValueStopwatch

A sketch of a ValueStopwatch type.

## Benchmark Results:

|                        Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------------------ |---------:|----------:|----------:|-------:|---------:|
|        UsingExistingStopwatch | 51.68 ns | 1.0132 ns | 1.5472 ns |   1.00 |     0.00 |
|           UsingValueStopwatch | 46.75 ns | 0.0281 ns | 0.0219 ns |   0.91 |     0.03 |
| UsingValueStopwatchWithBoxing | 52.74 ns | 1.0270 ns | 1.1827 ns |   1.02 |     0.04 |

|                          Method |       Mean |     Error |    StdDev |     Median | Scaled | ScaledSD |
|-------------------------------- |-----------:|----------:|----------:|-----------:|-------:|---------:|
|                   NoEventSource |  0.2787 ns | 0.0056 ns | 0.0104 ns |  0.2704 ns |   1.00 |     0.00 |
|              EventSourceEnabled | 75.2956 ns | 2.0029 ns | 1.8736 ns | 74.5741 ns | 270.55 |    11.74 |
| EventSourceEnabledButNotAtLevel |  4.0312 ns | 0.1161 ns | 0.1243 ns |  3.9739 ns |  14.48 |     0.68 |
|             EventSourceDisabled |  1.8220 ns | 0.0026 ns | 0.0023 ns |  1.8223 ns |   6.55 |     0.24 |