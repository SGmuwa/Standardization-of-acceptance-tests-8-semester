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

namespace Patterns.Builder
{
    public partial class Flower
    {
        public class Builder
        {
            private Flower current = new Flower();

            private (bool isColor, bool isLength) setted = (false, false);

            public Builder SetColor(ConsoleColor color)
            {
                current.Color = color;
                setted.isColor = true;
                return this;
            }

            public Builder SetLength(float length)
            {
                current.Length = length;
                setted.isLength = true;
                return this;
            }

            public Flower Build()
            {
                if (setted.isColor && setted.isLength)
                    return new Flower(current.Color, current.Length);
                else
                    throw new Exception(setted.ToString());
            }
        }
    }
}
