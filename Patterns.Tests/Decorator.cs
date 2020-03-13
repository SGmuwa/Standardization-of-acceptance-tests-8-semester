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
            i.V++;
            Assert.Equal(2uL, i.Access.Get);
            Assert.Equal(3uL, i.Access.Set);
            Assert.Equal(3, i.V);
            Assert.Equal(3uL, i.Access.Get);
            Assert.Equal(3uL, i.Access.Set);
        }
    }
}
