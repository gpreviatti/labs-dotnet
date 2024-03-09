# BenchMarks beetween HttpClienct x Refit rest api libraries

## Results of the benchmarks

BenchmarkDotNet v0.13.12, Windows 11
11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64

| Method                         | Mean     | Error    | StdDev   | Median   | Allocated |
|------------------------------- |---------:|---------:|---------:|---------:|----------:|
| 'Send request with HttpClient' | 961.5 us | 23.67 us | 65.59 us | 944.2 us |   3.68 KB |
| 'Send request with refit'      | 968.3 us | 19.70 us | 55.90 us | 946.9 us |   5.93 KB |

## Hints

Outliers
HttpClientxRefitBenchmarks.'Send request with HttpClient': Default -> 11 outliers were removed (1.18 ms..1.47 ms)

HttpClientxRefitBenchmarks.'Send request with refit': Default      -> 7 outliers were removed (1.15 ms..1.26 ms)

## Legends

Mean      : Arithmetic mean of all measurements

Error     : Half of 99.9% confidence interval

StdDev    : Standard deviation of all measurements

Median    : Value separating the higher half of all measurements (50th percentile)

Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)

1 us      : 1 Microsecond (0.000001 sec)