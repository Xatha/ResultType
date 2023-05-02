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
        
        Option<string> expected = Option<string>.None();
        Option<string> actual;

        // Act
        actual = input.ToOption();

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
    
}