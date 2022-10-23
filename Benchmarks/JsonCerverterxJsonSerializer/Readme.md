# BenchMarks serializing and deserializing objects with System.Text.Json and Newtonsoft.Json

## Results Deserialization


|                  Method | People | Accounts |       Mean |     Error |    StdDev |     Median |       Gen0 |      Gen1 |      Gen2 | Allocated |
|------------------------ |------- |--------- |-----------:|----------:|----------:|-----------:|-----------:|----------:|----------:|----------:|
|   JsonSeriealizer Async |      1 |       10 |   2.315 ms | 0.0420 ms | 0.0328 ms |   2.307 ms |   386.7188 |  167.9688 |         - |   2.34 MB |
|         JsonSeriealizer |      1 |       10 |   2.349 ms | 0.0453 ms | 0.0719 ms |   2.327 ms |   386.7188 |  164.0625 |         - |   2.33 MB |
|JsonConvert (NewtonSoft) |      1 |       10 |   2.767 ms | 0.1265 ms | 0.3630 ms |   2.648 ms |   390.6250 |  175.7813 |         - |   2.34 MB |
|         JsonSeriealizer |     10 |      100 |  20.220 ms | 0.3653 ms | 0.5795 ms |  20.031 ms |  2906.2500 |  750.0000 |  125.0000 |  17.24 MB |
|   JsonSeriealizer Async |     10 |      100 |  20.404 ms | 0.3832 ms | 0.7565 ms |  20.281 ms |  3031.2500 |  875.0000 |  187.5000 |  17.99 MB |
|JsonConvert (NewtonSoft) |     10 |      100 |  23.313 ms | 0.4634 ms | 0.4551 ms |  23.395 ms |  3156.2500 |  875.0000 |  218.7500 |   18.5 MB |
|   JsonSeriealizer Async |    100 |      200 | 205.109 ms | 4.0220 ms | 5.7683 ms | 203.751 ms | 31000.0000 | 7000.0000 | 2500.0000 | 188.33 MB |
|         JsonSeriealizer |    100 |      200 | 210.885 ms | 4.0777 ms | 5.7164 ms | 210.406 ms | 28000.0000 | 2333.3333 |  333.3333 | 175.21 MB |
|JsonConvert (NewtonSoft) |    100 |      200 | 233.588 ms | 4.1199 ms | 3.6522 ms | 234.059 ms | 31500.0000 | 6000.0000 | 1500.0000 | 199.87 MB |


## Results Serialization


|                   Method | People | Accounts |       Mean |     Error |    StdDev |       Gen0 |      Gen1 |      Gen2 | Allocated |
|------------------------- |------- |--------- |----------- |----------:|----------:|----------:|-----------:|----------:|----------:|
| JsonConvert (NewtonSoft) |      1 |       10 |   2.436 ms | 0.0469 ms | 0.0502 ms |   386.7188 |  167.9688 |         - |   2.33 MB |
|     JsonSeriealizerAsync |      1 |       10 |   2.464 ms | 0.0491 ms | 0.0459 ms |   386.7188 |  160.1563 |         - |   2.32 MB |
|          JsonSeriealizer |      1 |       10 |   2.497 ms | 0.0475 ms | 0.0467 ms |   386.7188 |  164.0625 |         - |   2.32 MB |
|          JsonSeriealizer |     10 |      100 |  18.933 ms | 0.3575 ms | 0.3825 ms |  2843.7500 |  750.0000 |   93.7500 |  16.91 MB |
|     JsonSeriealizerAsync |     10 |      100 |  19.262 ms | 0.3795 ms | 0.3898 ms |  2875.0000 |  687.5000 |   93.7500 |  17.04 MB |
| JsonConvert (NewtonSoft) |     10 |      100 |  19.555 ms | 0.3841 ms | 0.6311 ms |  2906.2500 |  687.5000 |   62.5000 |  17.46 MB |
|     JsonSeriealizerAsync |    100 |      200 | 185.302 ms | 3.6286 ms | 3.2167 ms | 28000.0000 | 3666.6667 | 1000.0000 |  169.8 MB |
|          JsonSeriealizer |    100 |      200 | 191.681 ms | 3.7839 ms | 6.5271 ms | 27333.3333 | 2333.3333 |  333.3333 | 168.57 MB |
| JsonConvert (NewtonSoft) |    100 |      200 | 204.180 ms | 2.7548 ms | 2.5768 ms | 29500.0000 | 4500.0000 | 1000.0000 | 179.41 MB |


If you want to test the results or change the data just clone and enjoy.

