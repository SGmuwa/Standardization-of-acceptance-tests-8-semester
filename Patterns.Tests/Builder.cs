using System;
using Xunit;

namespace Patterns.Tests
{
    public class Builder
    {
        [Fact]
        public void Expected()
        {
            Flower f = new Flower.Builder()
                .SetColor(ConsoleColor.Red)
                .SetLength(12.4f)
                .Build();
            Assert.Equal(ConsoleColor.Red, f.Color);
            Assert.Equal(12.4f, f.Length);
        }

        [Fact]
        public void Throw()
            => Assert.Throws<Exception>(() =>
            {
                Flower f = new Flower.Builder()
                    .SetColor(ConsoleColor.Red)
                    .Build();
            });
    }
}
