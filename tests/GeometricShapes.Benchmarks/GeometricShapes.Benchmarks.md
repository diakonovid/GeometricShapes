``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Big Sur 11.5.2 (20G95) [Darwin 20.6.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.202
  [Host]     : .NET 5.0.5 (5.0.521.16609), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.5 (5.0.521.16609), X64 RyuJIT


```

__Lazy shape area calculation performance__

|                    Method |       Mean |    Error |    StdDev |     Median |    Gen 0 | Allocated |
|-------------------------- |-----------:|---------:|----------:|-----------:|---------:|----------:|
|      CreateCircleWithLazy |   622.5 μs |  7.85 μs |   6.96 μs |   624.2 μs | 267.5781 |  1,641 KB |
|   CreateCircleWithoutLazy |   142.1 μs |  1.46 μs |   1.30 μs |   142.3 μs |  38.0859 |    234 KB |
|    CreateTriangleWithLazy | 1,494.4 μs | 45.36 μs | 127.21 μs | 1,435.2 μs | 546.8750 |  3,359 KB |
| CreateTriangleWithoutLazy | 1,570.3 μs | 22.03 μs |  19.53 μs | 1,566.7 μs | 419.9219 |  2,578 KB |
