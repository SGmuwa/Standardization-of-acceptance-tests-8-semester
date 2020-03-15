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

using Xunit;

namespace Patterns.AbstractFactory.Tests
{
    public class AbstractFactory
    {
        [Fact]
        public void Expected()
        {
            Patterns.AbstractFactory.AbstractFactory meatWolfFactory = new MeatWolfFactory()
                .SetMeatAnimal(new Sheep("John"))
                .SetMeatWeight(1.5)
                .SetWolfName("Jim");
            Assert.Equal(0, meatWolfFactory.UniqId);
            ICanEat wolf = meatWolfFactory.BuildCanEat();
            Assert.Equal("Wolf Jim", wolf.Name);
            IFood sheepMeat = meatWolfFactory.BuildFood();
            Assert.Equal("Wolf Jim", wolf.Name);
            Assert.Equal(1.5, sheepMeat.Weight);
            Assert.Equal("Sheep John meat", sheepMeat.Name);
            wolf.Eat(sheepMeat);
            Assert.Equal(0, sheepMeat.Weight);

            Patterns.AbstractFactory.AbstractFactory gasVehicleFactory = new GasVehicleFactory()
                .SetGasBrand("Bas")
                .SetGasWeight(1000)
                .SetVehicleBrand("GrrMotor")
                .SetVehicleConsumption(20)
                .SetVehicleModel("o0O");
            Assert.Equal(1, gasVehicleFactory.UniqId);
            ICanEat vehicle = gasVehicleFactory.BuildCanEat();
            Assert.Equal("Vehicle «o0O», GrrMotorⓒ", vehicle.Name);
            IFood gas = gasVehicleFactory.BuildFood();
            Assert.Equal("Vehicle «o0O», GrrMotorⓒ", vehicle.Name);
            Assert.Equal("Gas «Bas»", gas.Name);
            Assert.Equal(1000.0, gas.Weight);
            vehicle.Eat(gas);
            Assert.Equal(980.0, gas.Weight);

            NotEqualLink();
        }

        private void NotEqualLink()
        {
            Patterns.AbstractFactory.AbstractFactory meatWolfFactory = new MeatWolfFactory()
                .SetMeatAnimal(new Sheep(null))
                .SetMeatWeight(0)
                .SetWolfName(null);
            Assert.False(meatWolfFactory.BuildFood() == meatWolfFactory.BuildFood());
            Assert.False(meatWolfFactory.BuildCanEat() == meatWolfFactory.BuildCanEat());

            Patterns.AbstractFactory.AbstractFactory gasVehicleFactory = new GasVehicleFactory()
                .SetGasBrand(null)
                .SetGasWeight(0)
                .SetVehicleBrand(null)
                .SetVehicleConsumption(0.0)
                .SetVehicleModel(null);
            Assert.False(gasVehicleFactory.BuildCanEat() == gasVehicleFactory.BuildCanEat());
            Assert.False(gasVehicleFactory.BuildFood() == gasVehicleFactory.BuildFood());
        }
    }
}
