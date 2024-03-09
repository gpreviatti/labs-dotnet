# BenchMarks beetween HttpClienct x Refit rest api libraries

## Results of the benchmarks

BenchmarkDotNet v0.13.12, Windows 11
11th Gen Intel Core i5-11400H 2.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.200
  [Host]     : .NET 8.0.2 (8.0.224.6711), X64
  DefaultJob : .NET 8.0.2 (8.0.224.6711), X64


| Method                         | Mean     | Error    | StdDev   | Median   | Allocated |
|------------------------------- |---------:|---------:|---------:|---------:|----------:|
| 'Send request with refit'      | 911.8 us | 18.21 us | 44.68 us | 892.1 us |   6.03 KB |
| 'Send request with HttpClient' | 926.2 us | 20.12 us | 57.40 us | 904.0 us |    3.6 KB |