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
    public class GasVehicleFactory : AbstractFactory
    {
        public GasVehicleFactory() { }

        Vehicle vehicle = new Vehicle();
        Gas gas = new Gas();
        byte isReadyToBuild = 0;

        public GasVehicleFactory SetGasBrand(string brand)
        {
            gas.Brand = brand;
            isReadyToBuild |= 0b1;
            return this;
        }

        public GasVehicleFactory SetGasWeight(double weight)
        {
            gas.Weight = weight;
            isReadyToBuild |= 0b10;
            return this;
        }

        public GasVehicleFactory SetVehicleBrand(string brand)
        {
            vehicle.Brand = brand;
            isReadyToBuild |= 0b100;
            return this;
        }

        public GasVehicleFactory SetVehicleModel(string model)
        {
            vehicle.Model = model;
            isReadyToBuild |= 0b1000;
            return this;
        }

        public GasVehicleFactory SetVehicleConsumption(double consumption)
        {
            vehicle.Consumption = consumption;
            isReadyToBuild |= 0b10000;
            return this;
        }

        public override ICanEat BuildCanEat()
        {
            if ((isReadyToBuild & 0b11100) == 0b11100)
                return new Vehicle(vehicle.Brand, vehicle.Model, vehicle.Consumption);
            else
                throw new Exception();
        }

        public override IFood BuildFood()
        {
            if ((isReadyToBuild & 0b1) == 0b1)
                return new Gas(gas.Brand) { Weight = gas.Weight };
            else
                throw new Exception();
        }
    }
}
