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

namespace Patterns.AbstractFactory
{
    public class Meat : IFood
    {
        private ICanEat animal;

        public ICanEat Animal
        {
            get => animal; internal set
            {
                animal = value;
                Name = Animal.Name + " meat";
            }
        }
        public double Weight { get; set; }
        public string Name { get; private set; }

        public Meat(ICanEat animal, double weight)
        {
            Animal = animal;
            Weight = weight;
        }

        internal Meat() { }
    }
}
