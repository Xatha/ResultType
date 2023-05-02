using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using ResultType.Option;

namespace ResultTypeTests.OptionTests;

[TestFixture]
[SuppressMessage("ReSharper", "JoinDeclarationAndInitializer")]
public class OptionTests
{
    [Test]
    public void Map_WhenValueIsNotNull_ReturnsCorrectValue()
    {
        // Arrange
        Option<string> option;
        int result;

        // Act
        option = Option<string>.Some("Hello World!");
        result = option.Map(x => x.Length).Collapse(-1);
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World!".Length));
    }
    
    [Test]
    public void Map_WhenValueIsNull_ReturnsDefaultValue()
    {
        // Arrange
        Option<string> option;
        int result;

        // Act
        option = Option<string>.None();
        result = option.Map(x => x.Length).Collapse(-1);
        
        
        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
    
    [Test]
    public void Map_WithOption_WhenValueIsNotNull_ReturnsCorrectValue()
    {
        // Arrange
        Option<string> option;
        Option<int> length;
        int result;
        
        Option<int> Add(int x, Option<int> y) => y.Map(z => x + z);
        
        // Act
        option = Option<string>.Some("Hello World!");
        length = Option<int>.Some(5);
        result = option.Map(x => Add(x.Length, length)).Collapse(-1);
        
        // Assert
        Assert.That(result, Is.EqualTo("Hello World!".Length + 5));
    }
    
    [Test]
    public void Map_WithOption_WhenValueIsNull_ReturnsDefaultValue()
    {
        // Arrange
        Option<string> option;
        Option<int> length;
        int result;
        
        Option<int> Add(int x, Option<int> y) => y.Map(z => x + z);
        
        // Act
        option = Option<string>.None();
        length = Option<int>.Some(5);
        result = option.Map(x => Add(x.Length, length)).Collapse(-1);
        
        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}