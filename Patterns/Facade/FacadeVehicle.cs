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

namespace Patterns.Facade
{
    public class FacadeVehicle : IEasyVehicle, IDisposable
    {
        public FacadeVehicle()
            => vehicle.Power = true;

        private Vehicle vehicle = new Vehicle();

        public City Position
        {
            get => City.SearchNear(vehicle.Position);
            set
            {
                double addPos = value.Position - vehicle.Position;
                if (addPos == 0.0)
                    return;
                vehicle.AddPosition(addPos);
            }
        }

        #region IDisposable Support
        /// <summary>
        /// To detect redundant calls.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Turns off the vehicle. Does not free resources.
        /// Perhaps necessary for business logic.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> for real turn off vehicle. Otherwise — <c>false</c>.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    if (vehicle.Power)
                        vehicle.Power = false;
                disposedValue = true;
            }
        }

        /// <summary>
        /// Turns off the vehicle. Does not free resources.
        /// Perhaps necessary for business logic.
        /// </summary>
        public void Dispose()
            => Dispose(true);

        #endregion
    }
}
