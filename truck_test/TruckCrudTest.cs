using Microsoft.Extensions.DependencyInjection;
using truck_register.Models;
using truck_register.Repositories.Concrete;
using truck_register.Repositories.Interfaces;

namespace truck_test
{
    public class TruckCrudTest
    {
        private readonly ITruckRepository _truckRepository;

        public TruckCrudTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ITruckRepository, TruckRepository>();

            var serviceProvider = services.BuildServiceProvider();

            _truckRepository = serviceProvider.GetService<ITruckRepository>();
        }

        [Fact]
        public void CheckIfInsertIsWorking()
        {
            var truck = new Truck();
            truck.Id = _truckRepository.FetchAll().Last().Id + 1;
            truck.AnoFabricacao = "2022";
            truck.AnoModelo = "2022";
            truck.Modelo = "FH";

            var insertedTruck = _truckRepository.Insert(truck);

            Assert.True(_truckRepository.GetById(insertedTruck.Id) != null);
        }
    }
}
