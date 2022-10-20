using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
        public void InsertingTruckAddsNewTruckToDatabase()
        {
            var truck = new Truck();
            truck.Id = _truckRepository.FetchAll().Last().Id + 1;
            truck.AnoFabricacao = "2022";
            truck.AnoModelo = "2022";
            truck.Modelo = "FH";

            var insertedTruck = _truckRepository.Insert(truck);

            Assert.True(_truckRepository.GetById(insertedTruck.Id) != null);
        }

        [Fact]
        public void DeletingTruckRemovesTruckFromDatabase()
        {
            var truckToBeDeleted = _truckRepository.FetchAll().First();
            _truckRepository.Delete(truckToBeDeleted);

            Assert.True(_truckRepository.GetById(truckToBeDeleted.Id) == null);
        }

        [Fact]
        public void UpdatingTruckAltersTruckOnDatabase()
        {
            var truckToBeUpdated = _truckRepository.FetchAll().First();
            truckToBeUpdated.Modelo = "FM";
            truckToBeUpdated = _truckRepository.Update(truckToBeUpdated);

            var updatedTruck = _truckRepository.GetById(truckToBeUpdated.Id);

            Assert.Equal(JsonConvert.SerializeObject(updatedTruck), JsonConvert.SerializeObject(truckToBeUpdated));
        }

        [Fact]
        public void InsertingInvalidTruckModelShouldThrowException()
        {
            var truck = new Truck();
            truck.Id = _truckRepository.FetchAll().Last().Id + 1;
            truck.AnoFabricacao = "2022";
            truck.AnoModelo = "2022";
            truck.Modelo = "auishdi";

            var ex = Assert.Throws<Exception>(() => _truckRepository.Insert(truck));

            Assert.Equal("Modelo Inválido.", ex.Message);
        }

        [Fact]
        public void UpdatingInvalidTruckModelShouldThrowException()
        {
            var truckToBeUpdated = _truckRepository.FetchAll().First();
            truckToBeUpdated.Modelo = "asdhuihi";

            var ex = Assert.Throws<Exception>(() => _truckRepository.Update(truckToBeUpdated));

            Assert.Equal("Modelo Inválido.", ex.Message);
        }

        [Fact]
        public void InsertingInvalidTruckModelDateShouldThrowException()
        {
            var truck = new Truck();
            truck.Id = _truckRepository.FetchAll().Last().Id + 1;
            truck.AnoFabricacao = "2022";
            truck.AnoModelo = "2015";
            truck.Modelo = "FH";

            var ex = Assert.Throws<Exception>(() => _truckRepository.Insert(truck));

            Assert.Equal("O ano modelo deve ser o atual ou o ano subsequente.", ex.Message);
        }

        [Fact]
        public void UpdatingInvalidTruckModelDateShouldThrowException()
        {
            var truckToBeUpdated = _truckRepository.FetchAll().First();
            truckToBeUpdated.AnoModelo = "2015";

            var ex = Assert.Throws<Exception>(() => _truckRepository.Update(truckToBeUpdated));

            Assert.Equal("O ano modelo deve ser o atual ou o ano subsequente.", ex.Message);
        }

        [Fact]
        public void InsertingInvalidTruckFabricationDateShouldThrowException()
        {
            var truck = new Truck();
            truck.Id = _truckRepository.FetchAll().Last().Id + 1;
            truck.AnoFabricacao = "2014";
            truck.AnoModelo = "2022";
            truck.Modelo = "FH";

            var ex = Assert.Throws<Exception>(() => _truckRepository.Insert(truck));

            Assert.Equal("O ano de fabricação deve ser o atual.", ex.Message);
        }

        [Fact]
        public void UpdatingInvalidTruckFabricationDateShouldThrowException()
        {
            var truckToBeUpdated = _truckRepository.FetchAll().First();
            truckToBeUpdated.AnoFabricacao = "2014";

            var ex = Assert.Throws<Exception>(() => _truckRepository.Update(truckToBeUpdated));

            Assert.Equal("O ano de fabricação deve ser o atual.", ex.Message);
        }
    }
}