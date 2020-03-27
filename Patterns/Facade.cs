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

using System.Collections;
using System.Collections.Generic;
#warning реализовать фасат, а не сокрыть просто
namespace Patterns
{
    public class BasicList<T> : IList<T>
    {
        public BasicList(IList<T> target = null)
        {
            this.target = target;
            if(this.target == null)
                this.target = new List<T>();
        }

        private IList<T> target;

        public T this[int index] { get => target[index]; set => target[index] = value; }

        public int Count => target.Count;

        public void Add(T item) => target.Add(item);

        public void Insert(int index, T item) => target.Insert(index, item);

        public void RemoveAt(int index) => target.RemoveAt(index);

        #region Hide (not public)

        bool ICollection<T>.IsReadOnly => target.IsReadOnly;

        void ICollection<T>.Clear() => target.Clear();

        bool ICollection<T>.Contains(T item) => target.Contains(item);

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
            => target.CopyTo(array, arrayIndex);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => target.GetEnumerator();

        int IList<T>.IndexOf(T item) => target.IndexOf(item);

        bool ICollection<T>.Remove(T item) => target.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => target.GetEnumerator();

        #endregion
    }
}
