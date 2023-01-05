// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Primitives.Benchmark.Benchmarks;

BenchmarkRunner.Run<PrimitivesBenchmark>();
Console.WriteLine("Hello, World!");