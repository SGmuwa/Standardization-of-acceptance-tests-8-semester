using System;
using Xunit;

namespace Patterns.Tests
{
    public class Decorator
    {
        [Fact]
        public void Expected()
        {
            Decorator<int> i = new Decorator<int>(0);
            Assert.Equal(0uL, i.Access.Get);
            Assert.Equal(0uL, i.Access.Set);
            i.V++;
            Assert.Equal(1uL, i.Access.Get);
            Assert.Equal(1uL, i.Access.Set);
            i.V = 2;
            Assert.Equal(1uL, i.Access.Get);
            Assert.Equal(2uL, i.Access.Set);
        }
    }
}
