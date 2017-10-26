# ValueStopwatch

A sketch of a ValueStopwatch type.

## Benchmark Results:

                        Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |
------------------------------ |---------:|----------:|----------:|-------:|---------:|
        UsingExistingStopwatch | 51.68 ns | 1.0132 ns | 1.5472 ns |   1.00 |     0.00 |
           UsingValueStopwatch | 46.75 ns | 0.0281 ns | 0.0219 ns |   0.91 |     0.03 |
 UsingValueStopwatchWithBoxing | 52.74 ns | 1.0270 ns | 1.1827 ns |   1.02 |     0.04 |