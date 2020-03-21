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
Пример: фильтр компонентов. Захотелось добавить функционал к существующему фильтру. Который принимает фильтр и добавляет ещё одну фильтрацию. overide, вызов basic. Придумать свою.
namespace Patterns
{
    public class Decorator<T>
    {
        public Decorator(T v)
        {
            this.v = v;
        }

        private T v;

        private (ulong Get, ulong Set) access = (0, 0);

        public T V
        {
            get
            {
                access.Get = checked(access.Get + 1);
                return v;
            }

            set
            {
                access.Set = checked(access.Set + 1);
                v = value;
            }
        }

        public (ulong Get, ulong Set) Access => access;
    }
}
