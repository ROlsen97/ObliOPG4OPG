using _3SemObliOPG;
using System.Security.Cryptography.X509Certificates;

namespace ObliOPG4OPG.Repos
{
    public class CarRepo
    {
        private int _nextId;
        private List<Car> cars;
        public CarRepo()
        {
            _nextId = 1;
            cars = new List<Car>()
            {
                new Car(){Id = _nextId++, Model="RigtigBil", Licenseplate="AA1234", Price=10000},
                new Car(){Id = _nextId++, Model="RigtigBilV2", Licenseplate="AB1234", Price=20000},
                new Car(){Id = _nextId++, Model="RigtigBilV3", Licenseplate="AC1234", Price=30000},
                new Car(){Id = _nextId++, Model="RigtigBilV4", Licenseplate="AD1234", Price=40000},
            };
        }
        public List<Car> GetAll()
        {
            return new List<Car>(cars);
        }
        public Car GetById(int id)
        {
            Car carById = cars.Find(x => x.Id == id);
            return carById;
        }
        public Car Add(Car car)
        {
            car.Id = ++_nextId;
            cars.Add(car);
            return car;
        }
        public Car Update(int id, Car UpdateCar)
        {
            Car FoundCar = GetById(id);
            if (FoundCar == null)
            {
                return null;
            }
            FoundCar.Id = UpdateCar.Id;
            FoundCar.Model = UpdateCar.Model;
            FoundCar.Licenseplate = UpdateCar.Licenseplate;
            FoundCar.Price = UpdateCar.Price;
            return FoundCar;
        }
        public Car Delete(int id, Car DeleteCar)
        {
            Car FoundCar = GetById(id);
            if (FoundCar != null)
            {
                cars.Remove(FoundCar);
            }
            FoundCar.Id = DeleteCar.Id;
            FoundCar.Model = DeleteCar.Model;
            FoundCar.Licenseplate = DeleteCar.Licenseplate;
            FoundCar.Price = DeleteCar.Price;
            return FoundCar;
        }
    }
}

