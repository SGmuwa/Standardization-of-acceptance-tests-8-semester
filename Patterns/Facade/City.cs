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
using System.Collections.ObjectModel;

namespace Patterns.Facade
{
    public class City
    {
        private City(double position)
            => Position = position;

        public double Position { get; }

        public static readonly City Moscow = new City(20);
        public static readonly City NewYork = new City(10000);
        public static readonly City Moon = new City(100000000);
        public static readonly City Unknown = new City(double.NaN);
        public static readonly ReadOnlyCollection<City> All = new ReadOnlyCollection<City>(new City[] { Moscow, NewYork, Moon });

        public static City SearchNear(double pos)
        {
            City win = City.Unknown;
            double cache = double.NaN;
            foreach (City c in City.All)
            {
                double newDistance = GetDistance(pos, c.Position);
                if (cache > newDistance || double.IsNaN(cache))
                {
                    cache = newDistance;
                    win = c;
                }
            }
            return win;
        }

        public static double GetDistance(double p1, double p2)
            => Math.Abs(p1 - p2);

        public override bool Equals(object obj)
            => obj is City oth
                && Object.ReferenceEquals(SearchNear(Position), oth);

        public override int GetHashCode() => HashCode.Combine(Position);

        public override string ToString() => $"City at {Position}";
    }
}