namespace ResultMonadBenchmark;

public class DummyReferenceType
{
    public string StringData { get; set; }
    public int IntData { get; set; }
    public bool BoolData { get; set; }
    public double DoubleData { get; set; }
    public float FloatData { get; set; }
    public long LongData { get; set; }
    public short ShortData { get; set; }

    public DummyReferenceType()
    {
        StringData = "";
        IntData = 0;
        BoolData = false;
        DoubleData = 0;
        FloatData = 0;
        LongData = 0;
        ShortData = 0;
    }
}