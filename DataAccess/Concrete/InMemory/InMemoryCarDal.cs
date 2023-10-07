using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{ CarId=1, BrandId=1, ColorId=2, ModelName="Renoult Megane", ModelYear=2021, Description="Düz Vites, Benzinli", DailyPrice = 3500 },
            new Car{ CarId=2, BrandId=2, ColorId=1, ModelName="Renoult Megane", ModelYear=2023, Description="Otomatik Vites, Benzinli", DailyPrice = 4000 },
            new Car{ CarId=3, BrandId=3, ColorId=1, ModelName="Toyota Corolla", ModelYear=2019, Description="Düz Vites, Benzinli", DailyPrice = 3750 },
            new Car{ CarId=4, BrandId=2, ColorId=4, ModelName="Renoult Clio", ModelYear=2022, Description="Düz Vites, Benzinli", DailyPrice = 3000 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c =>c.CarId == car.CarId );

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            // Where komutu içindeki şarta uyanlar ile yeni liste oluşturma
            return _cars.Where(b=>b.BrandId == brandId).ToList();
        }

        public List<Car> GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.ModelName = car.ModelName;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            
        }
    }
}
