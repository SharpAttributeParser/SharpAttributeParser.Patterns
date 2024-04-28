﻿namespace Attribinter.Patterns.ArgumentRecorderFactoryCases;

using Xunit;

public sealed class Constructor
{
    [Fact]
    public void ReturnsFactory()
    {
        var result = Target();

        Assert.NotNull(result);
    }

    private static ArgumentRecorderFactory Target() => new();
}
