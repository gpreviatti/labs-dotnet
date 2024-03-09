# BenchMarks beetween HttpClienct x Refit rest api libraries

## Results of the benchmarks

| Method                         | Mean     | Error    | StdDev   | Allocated |
|------------------------------- |---------:|---------:|---------:|----------:|
| 'Send request with refit'      | 928.3 us | 18.17 us | 28.28 us |   5.91 KB |
| 'Send request with HttpClient' | 972.8 us | 18.94 us | 29.49 us |    3.6 KB |