using BenchmarkDotNet.Attributes;
using ResultType;

namespace ResultMonadBenchmark;

[MemoryDiagnoser(true)]
public class ResultBenchmark
{
    [Benchmark]
    public void Result_Err_ValueType()
    {
        Result<double> wrapped = Result.Err<double>("Error");
    }
    
    [Benchmark]
    public void Result_Ok_ValueType()
    {
        Result<double> wrapped = Result.Ok(2.0);
    }
    
    [Benchmark]
    public void Result_Err_ReferenceType()
    {
        Result<DummyReferenceType> wrapped = Result.Err<DummyReferenceType>("Error");
    }
    
    [Benchmark]
    public void Result_Ok_ReferenceType()
    {
        Result<DummyReferenceType> wrapped = Result.Ok(new DummyReferenceType());
    }

    [Benchmark]
    public void Result_Err_TryUnwrap()
    {
        int logic;
        Result<double> wrapped = Result.Err<double>("Error");
        if (wrapped.TryUnwrap(out var err, out var val))
        {
            throw new Exception("Should not be able to unwrap");
        }
        else
        {
            logic = err.Message.Length;
        }
    }
    
    [Benchmark]
    public void Result_Ok_TryUnwrap()
    {
        int logic;
        Result<double> wrapped = Result.Ok(2.0);
        if (wrapped.TryUnwrap(out var err, out var val))
        {
            logic = (int)val;
        }
    }
}