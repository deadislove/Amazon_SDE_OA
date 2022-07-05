using Amazon_SDE_Phone_Interview.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_Phone_Interview.SOLID
{
    internal class ISP : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Interface Segregation Principle");
            ICar _car = new Car(); ;
            IAirplane _airplane = new Airplane();
            IMultiFunctionalVehicle multiFunctionalVehicle = new MultiFuncationCar(_car, _airplane);
            multiFunctionalVehicle.Drive();
            multiFunctionalVehicle.Fly();
        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~ISP()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        internal interface ICar
        {
            void Drive();
        }

        internal interface IAirplane
        {
            void Fly();
        }

        internal interface IMultiFunctionalVehicle : ICar, IAirplane
        { }

        public class Car : ICar
        {
            public void Drive()
            {
                //actions to drive a car
                Console.WriteLine("Driving a car");
            }
        }


        public class Airplane : IAirplane
        {
            public void Fly()
            {
                //actions to fly a plane
                Console.WriteLine("Flying a plane");
            }
        }

        internal class MultiFuncationCar : IMultiFunctionalVehicle
        {
            private readonly ICar _car;
            private readonly IAirplane _airplane;

            public MultiFuncationCar(ICar car, IAirplane airplane)
            {
                _car = car;
                _airplane = airplane;
            }

            public void Drive()
            {
                //actions to start driving car
                Console.WriteLine("Drive a multifunctional car");
                _car.Drive();
            }

            public void Fly()
            {
                //actions to start flying
                Console.WriteLine("Fly a multifunctional car");
                _airplane.Fly();
            }
        }
    }
}
