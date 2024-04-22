﻿namespace Attribinter.Patterns.ArgumentRecorderFactoryCases;

using Moq;

using System;

using Xunit;

public sealed class Create
{
    private IArgumentRecorder<TParameter, TIn> Target<TParameter, TIn, TOut>(IArgumentRecorder<TParameter, TOut> patternedRecorder, IArgumentPattern<TIn, TOut> pattern) => Fixture.Sut.Create(patternedRecorder, pattern);

    private readonly IFactoryFixture Fixture = FactoryFixtureFactory.Create();

    [Fact]
    public void NullPatternedRecorder_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object>(null!, Mock.Of<IArgumentPattern<object, object>>()));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void NullPattern_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target<object, object, object>(Mock.Of<IArgumentRecorder<object, object>>(), null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void ValidArguments_ReturnsRecorder()
    {
        var result = Target(Mock.Of<IArgumentRecorder<object, object>>(), Mock.Of<IArgumentPattern<object, object>>());

        Assert.NotNull(result);
    }
}
