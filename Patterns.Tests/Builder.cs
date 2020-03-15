/*
    Homework of Standardization of acceptance tests in 8 semester.
    Copyright (C) 2020  Sidorenko Mikhail Pavlovich (motherlode.muwa@gmail.com)

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

        [Fact]
        public void NotEqualLink()
        {
            Flower.Builder b = new Flower.Builder()
                .SetColor(ConsoleColor.Gray)
                .SetLength(165.0f);
            Assert.False(b.Build() == b.Build());
        }
    }
}
