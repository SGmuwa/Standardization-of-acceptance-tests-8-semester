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

namespace Patterns.Decorator
{
    public class LogDecorator<T> : IValueHolder<T>
    {
        public LogDecorator(IValueHolder<T> vh, TextWriter output)
        {
            this.vh = vh;
            this.output = output;
        }

        private readonly IValueHolder<T> vh;

        private readonly TextWriter output;

        public T V
        {
            get
            {
                T value = this.vh.V;
                output.WriteLine("Get: " + value);
                return value;
            }

            set
            {
                output.WriteLine("Set: " + value);
                this.vh.V = value;
            }
        }

        public (ulong Get, ulong Set) Access
        {
            get
            {
                var a = this.vh.Access;
                output.WriteLine("Access: " + a);
                return a;
            }
        }
    }
}
