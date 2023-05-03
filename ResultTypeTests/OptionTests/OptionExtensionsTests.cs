using NUnit.Framework;
using ResultType.Option;

namespace ResultTypeTests.OptionTests;

[TestFixture]
public class OptionExtensionsTests
{
    [Test]
    public void ToOption_OnNullClass_WillBeNoneOption()
    {
        // Arrange
        string? input = null;

        var expected = "isNone!";
        string actual;

        // Act
        actual = input.ToOption().Collapse("isNone!");

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToOption_OnNullStruct_WillBeNoneOption()
    {
        // Arrange
        int? input = null;

        var expected = -9999;
        int actual;

        // Act
        actual = input.ToOption().Collapse(-9999);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToOption_OnNotNull_WillBeOption()
    {
        // Arrange
        var classInput = "Hello World!";
        
        int? structInput = 69;

        var expectedClass = "Hello World!";
        var expectedStruct = 69;

        string actualClass;
        int actualStruct;

        // Act
        actualClass = classInput.ToOption().Collapse("isNone!");
        actualStruct = structInput.ToOption().Collapse(-1);

        // Assert
        Assert.That(actualClass, Is.EqualTo(expectedClass));
        Assert.That(actualStruct, Is.EqualTo(expectedStruct));
    }

    [Test]
    public void Transform()
    {
        // Arrange
        var firstInput = Option.Some(5);
        var secondInput = Option.Some(10);

        var expected = 15;
        int actual;

        // Act
        actual = firstInput.Transform(secondInput, (x, y) => x + y).Collapse(-1);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}