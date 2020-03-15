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
namespace Patterns.AbstractFactory
{
    public class MeatWolfFactory : AbstractFactory
    {
        Meat meat = new Meat();
        Wolf wolf = new Wolf();
        byte isReadyToBuild = 0;

        public MeatWolfFactory SetMeatAnimal(ICanEat animal)
        {
            meat.Animal = animal;
            isReadyToBuild |= 0b1;
            return this;
        }

        public MeatWolfFactory SetMeatWeight(double weight)
        {
            meat.Weight = weight;
            isReadyToBuild |= 0b10;
            return this;
        }

        public MeatWolfFactory SetWolfName(string currentName)
        {
            wolf.CurrentName = currentName;
            isReadyToBuild |= 0b100;
            return this;
        }

        public override ICanEat BuildCanEat()
        {
            if ((isReadyToBuild & 0b100) == 0b100)
                return wolf;
            else
                throw new Exception();
        }

        public override IFood BuildFood()
        {
            if ((isReadyToBuild & 0b11) == 0b11)
                return meat;
            else
                throw new Exception();
        }
    }
}
