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
    public abstract class AbstractFactory
    {
        private static int i = 0;
        public readonly int CountCreate = i;

        public AbstractFactory() => i++;
        public abstract ICanEat BuildCanEat();
        public abstract IFood BuildFood();
    }

    public interface IFood
    {
        string Name { get; }
        double Weight { get; set; }
    }

    public interface ICanEat
    {
        void Eat(IFood food);
        string Name { get; }
    }

    public class Meat : IFood
    {
        public ICanEat Animal { get; }
        public double Weight { get; set; }
        public string Name { get => Animal.Name + " meat"; }

        public Meat(ICanEat animal, int weight)
        {
            Animal = animal;
            Weight = weight;
        }

        internal Meat() { }
    }

    public class Wolf : ICanEat
    {
        internal Wolf() {}
        public Wolf(string currentName) => this.currentName = currentName;
        private string currentName;
        public string Name => $"{nameof(Wolf)} {currentName}";
        public void Eat(IFood food)
        {
            if (food is Meat)
                food.Weight = 0;
        }
    }

    public class Sheep : ICanEat
    {
        public Sheep(string name = null)
            => Name = $"{nameof(Sheep)}{(name == null ? "" : $" {name}")}";

        public string Name { get; }

        public void Eat(IFood food) => throw new NotImplementedException();
    }

    public class Gas : IFood
    {
        private string brand;

        internal Gas() { }

        public Gas(string brand) => Brand = brand;
        public string Name { get; private set; }
        public double Weight { get; set; }
        public string Brand
        {
            get => brand; internal set
            {
                brand = value;
                Name = $"{nameof(Gas)} «{Brand}»";
            }
        }
    }

    public class Vehicle : ICanEat
    {
        private string brand;
        private object model;

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

        public object Model
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
            if ((isReadyToBuild & 0b11) == 0b11)
                return vehicle;
            else
                throw new Exception();
        }

        public override IFood BuildFood()
        {
            if ((isReadyToBuild & 0b11100) == 0b11100)
                return gas;
            else
                throw new Exception();
        }
    }

    public class MeatWolfFactory : AbstractFactory
    {
        Meat meat = new Meat();
        Wolf wolf = new Wolf();
        public override ICanEat BuildCanEat()
        {
            throw new NotImplementedException();
        }

        public override IFood BuildFood()
        {
            throw new NotImplementedException();
        }
    }
}