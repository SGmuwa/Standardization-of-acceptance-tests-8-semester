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
    public class Vehicle : ICanEat
    {
        private string brand;
        private string model;

        internal Vehicle() { }

        public Vehicle(string brand, string model, double consumption)
            => (Brand, Model, Consumption) = (brand, model, consumption);

        public double Consumption { get; internal set; }

        public string Name { get; private set; }

        public string Brand
        {
            get => brand; internal set
            {
                brand = value;
                Name = $"{nameof(Vehicle)} «{Model}», {Brand}ⓒ";
            }
        }

        public string Model
        {
            get => model; internal set
            {
                model = value;
                Name = $"{nameof(Vehicle)} «{Model}», {Brand}ⓒ";
            }
        }

        public void Eat(IFood food)
        {
            if (food is Gas && food.Weight > Consumption)
                food.Weight -= Consumption;
        }
    }
}
