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

using System.IO;
using System.Threading.Tasks;
using Patterns.Decorator;
using Xunit;
using Xunit.Sdk;
using static System.Text.Encoding;

namespace Patterns.Tests
{
    public class Decorator
    {
        [Fact]
        public void BaseTest()
        {
            IValueHolder<int> i = new ValueHolder<int>(0);
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

        [Fact]
        public void NestingTest()
        {
            IValueHolder<int> i = new ValueHolder<int>(0);
            i = new SynchronizedDecorator<int>(i);
            i = new SynchronizedDecorator<int>(i);
            using MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, UTF8);
            sw.AutoFlush = true;
            StreamWriter sw2 = new StreamWriter(ms, UTF8);
            sw2.AutoFlush = true;
            i = new LogDecorator<int>(i, sw);
            i = new LogDecorator<int>(i, sw);

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

            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            Assert.Equal("Access: (0, 0)", sr.ReadLine());
            Assert.Equal("Access: (0, 0)", sr.ReadLine());
            Assert.Equal("Access: (0, 0)", sr.ReadLine());
            Assert.Equal("Access: (0, 0)", sr.ReadLine());
            Assert.Equal("Get: 0", sr.ReadLine());
            Assert.Equal("Get: 0", sr.ReadLine());
            Assert.Equal("Set: 1", sr.ReadLine());
            Assert.Equal("Set: 1", sr.ReadLine());
            Assert.Equal("Access: (1, 1)", sr.ReadLine());
            Assert.Equal("Access: (1, 1)", sr.ReadLine());
            Assert.Equal("Access: (1, 1)", sr.ReadLine());
            Assert.Equal("Access: (1, 1)", sr.ReadLine());
            Assert.Equal("Set: 2", sr.ReadLine());
            Assert.Equal("Set: 2", sr.ReadLine());
            Assert.Equal("Access: (1, 2)", sr.ReadLine());
            Assert.Equal("Access: (1, 2)", sr.ReadLine());
            Assert.Equal("Access: (1, 2)", sr.ReadLine());
            Assert.Equal("Access: (1, 2)", sr.ReadLine());
            Assert.Equal("Get: 2", sr.ReadLine());
            Assert.Equal("Get: 2", sr.ReadLine());
            Assert.Equal("Set: 3", sr.ReadLine());
            Assert.Equal("Set: 3", sr.ReadLine());
            Assert.Equal("Access: (2, 3)", sr.ReadLine());
            Assert.Equal("Access: (2, 3)", sr.ReadLine());
            Assert.Equal("Access: (2, 3)", sr.ReadLine());
            Assert.Equal("Access: (2, 3)", sr.ReadLine());
            Assert.Equal("Get: 3", sr.ReadLine());
            Assert.Equal("Get: 3", sr.ReadLine());
            Assert.Equal("Access: (3, 3)", sr.ReadLine());
            Assert.Equal("Access: (3, 3)", sr.ReadLine());
            Assert.Equal("Access: (3, 3)", sr.ReadLine());
            Assert.Equal("Access: (3, 3)", sr.ReadLine());
            Assert.True(sr.EndOfStream);
        }

        [Fact]
        public void WithThreadSafeTest()
        {
            uint count = 5000;
            ushort countThread = 2;
            IValueHolder<int> i = new ValueHolder<int>(0);
            i = new SynchronizedDecorator<int>(i);
            Parallel.For(0, countThread, _ =>
            {
                uint j = 0;
                do
                {
                    i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                    i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                    i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                    i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                } while (++j < count);
            });
            Assert.Equal(((ulong)count * 256 * countThread, (ulong)count * 256 * countThread), i.Access);
        }

        [Fact]
        public void WithoutThreadSafeTest()
        {
            for (byte j = 0; j < 10; j++)
            {
                uint count = 2500u * j;
                ushort countThread = 2;
                IValueHolder<int> i = new ValueHolder<int>(0);
                Parallel.For(0, countThread, _ =>
                {
                    uint j = 0;
                    do
                    {
                        i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                        i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                        i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                        i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V; i.V = i.V;
                    } while (++j < count);
                });
                if(((ulong)count * 256 * countThread, (ulong)count * 256 * countThread) != i.Access)
                    return;
            }
            throw new XunitException("Without thread safe class is safe!");
        }
    }
}
