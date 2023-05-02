using BenchmarkDotNet.Running;
using ResultMonadBenchmark;
using ResultType;
using ResultType.Result;


Result<bool> result = ResultError.Create("Error message");


//BenchmarkRunner.Run<ResultBenchmark>();