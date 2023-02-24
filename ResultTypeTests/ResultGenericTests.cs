using NUnit.Framework;
using ResultType;

namespace ResultTypeTests;

public class ResultGenericTests
{
    [Test]
    public void OkAndErrTest()
    {
        // Arrange
        Result<double> successResult, failureResult1, failureResult2;
        
        // Act
        successResult = Result.Ok(2.0);
        failureResult1 = Result.Err<double>("Result error1");
        failureResult2 = Result.Err<double>(ResultError.Create("Result error2"));
        
        // Assert
        Assert.That(successResult, Is.EqualTo(Result.Ok(2.0)));
        Assert.That(failureResult1, Is.EqualTo(Result.Err<double>("Result error1")));
        Assert.That(failureResult2, Is.EqualTo(Result.Err<double>("Result error2")));
    }
    
    [Test]
    public void ImplicitOperatorTest()
    {
        // Arrange
        Result<double> successResult, failureResult1, failureResult2;

        // Act
        successResult = 2.0;
        failureResult1 = "Result error1";
        failureResult2 = ResultError.Create("Result error2");
        
        // Assert
        Assert.That(successResult, Is.EqualTo(Result.Ok(2.0)));
        Assert.That(failureResult1, Is.EqualTo(Result.Err<double>("Result error1")));
        Assert.That(failureResult2, Is.EqualTo(Result.Err<double>("Result error2")));
    }

    [Test]
    public void UnpackTest()
    {
        // Arrange
        (double, ResultError) successResult, failureResult;
        
        // Act
        successResult = Divide(1, 2).Unpack();
        failureResult = Divide(1, 0).Unpack();
        
        // Assert
        Assert.That(successResult.Item1, Is.EqualTo(0.5));
        Assert.That(failureResult.Item2.Message, Is.EqualTo("Divide by zero"));
    }

    [Test]
    public void TryUnwrapTest()
    {
        // Arrange
        Result<double> successResult, failureResult;

        // Act
        successResult = Divide(1, 2);
        failureResult = Divide(1, 0);
        
        // Assert
        if (successResult.TryUnwrap(out var err, out var val))
        {
            Assert.That(val, Is.EqualTo(0.5));
        }
        else
        {
            Assert.Fail(err.Message);
        }
        
        if (failureResult.TryUnwrap(out err, out val))
        {
            Assert.Fail("Should not be able to divide by zero");
        }
        else
        {
            Assert.That(err.Message, Is.EqualTo("Divide by zero"));
        }
    }

    [Test]
    public void MatchVoidTest()
    {
        // Arrange
        Result<double> successResult, failureResult;

        // Act
        successResult = Divide(1, 2);
        failureResult = Divide(1, 0);
        
        // Assert
        successResult.Match(
            success => Assert.That(success, Is.EqualTo(0.5)),
            failure => Assert.Fail(failure.Message));
        
        failureResult.Match(
            success => Assert.Fail("Should not be able to divide by zero"),
            failure => Assert.That(failure.Message, Is.EqualTo("Divide by zero")));
    }

    [Test]
    public void MatchTResultTest()
    {
        // Arrange
        Result<double> successResult, failureResult;

        // Act
        successResult = Divide(1, 2);
        failureResult = Divide(1, 0);

        // Assert
        Assert.That(successResult.Match(
            success => success,
            failure => 0), Is.EqualTo(Result.Ok(0.5)));

        Assert.That(failureResult.Match(
            success => success,
            failure => failure), Is.EqualTo(Result.Err<double>("Divide by zero")));
    }

    private Result<double> Divide(int a, int b)
    {
        return b == 0 ? ResultError.Create("Divide by zero") : (double)a / b;
    }
}