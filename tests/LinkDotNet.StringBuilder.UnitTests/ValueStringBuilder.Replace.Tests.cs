namespace LinkDotNet.StringBuilder.UnitTests;

public class ValueStringBuilderReplaceTests
{
    [Fact]
    public void ShouldReplaceAllCharacters()
    {
        var builder = new ValueStringBuilder();
        builder.Append("CCCC");

        builder.Replace('C', 'B');

        builder.ToString().Should().Be("BBBB");
    }

    [Fact]
    public void ShouldReplaceAllCharactersInGivenSpan()
    {
        var builder = new ValueStringBuilder();
        builder.Append("CCCC");

        builder.Replace('C', 'B', 1, 2);

        builder.ToString().Should().Be("CBBC");
    }

    [Fact]
    public void ShouldReplaceAllText()
    {
        var builder = new ValueStringBuilder();
        builder.Append("Hello World. How are you doing. Hello world examples are always fun.");

        builder.Replace("Hello", "Hallöchen");

        builder.ToString().Should().Be("Hallöchen World. How are you doing. Hallöchen world examples are always fun.");
    }

    [Fact]
    public void ShouldNotAlterIfNotFound()
    {
        var builder = new ValueStringBuilder();
        builder.Append("Hello");

        builder.Replace("Test", "Not");

        builder.ToString().Should().Be("Hello");
    }

    [Fact]
    public void ShouldReplaceInSpan()
    {
        var builder = new ValueStringBuilder();
        builder.Append("Hello World. How are you doing. Hello world examples are always fun.");

        builder.Replace("Hello", "Hallöchen", 0, 10);

        builder.ToString().Should().Be("Hallöchen World. How are you doing. Hello world examples are always fun.");
    }
}