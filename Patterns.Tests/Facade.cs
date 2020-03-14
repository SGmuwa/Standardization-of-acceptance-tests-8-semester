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
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

namespace Patterns.Tests
{
    public class Facade
    {
        [Fact]
        public void Expected()
        {
            Assert.Empty(new BasicList<int>());
            BasicList<int> list = new BasicList<int>() { 1, 2, 3 };
            Assert.Equal(3, list.Count);
            list.RemoveAt(2);
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0]);
            Assert.Equal(2, list[1]);
            Assert.Throws<ArgumentOutOfRangeException>(() => { var a = list[2]; });
            Assert.Throws<ArgumentOutOfRangeException>(() => { var a = list[-1]; });
            list.Insert(0, 0);
            ListsEqual(new int[] { 0, 1, 2 }, list);
            dynamic l = list;
            // Try get not public or not definition methods
            Assert.Throws<RuntimeBinderException>(() => l.SomeMethod123QWERTY());
            Assert.Throws<RuntimeBinderException>(() => { var _ = l.IsReadOnly; });
            Assert.Throws<RuntimeBinderException>(() => { l.Clear(); });
            Assert.Throws<RuntimeBinderException>(() => { var _ = l.Contains(0); });
            Assert.Throws<RuntimeBinderException>(() => { l.CopyTo(new int[3], 0); });
            Assert.Throws<RuntimeBinderException>(() => { var _ = l.GetEnumerator(); });
            Assert.Throws<RuntimeBinderException>(() => { var _ = l.IndexOf(0); });
            Assert.Throws<RuntimeBinderException>(() => { var _ = l.Remove(0); });
            IList<int> li = list;
            Assert.Throws<RuntimeBinderException>(() => l.SomeMethod123QWERTY());
            Assert.False(li.IsReadOnly);
            Assert.True(li.Contains(0));
            int[] arr = new int[3];
            li.CopyTo(arr, 0);
            Assert.Equal(arr.Length, li.Count);
            Assert.Equal(arr, li);
            li.GetEnumerator(); // not trow expect
            Assert.Equal(0, li.IndexOf(0));
            Assert.True(li.Remove(0));
            li.Clear();
            Assert.Empty(li);
            Assert.Empty(list);
        }

        private static void ListsEqual<T>(IList<T> expect, IList<T> actual)
        {
            Assert.Equal(expect.Count, actual.Count);
            for(int i = 0; i < expect.Count; i++)
                Assert.Equal(expect[i], actual[i]);
        }
    }
}
