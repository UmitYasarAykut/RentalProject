using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, RentacarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId select new CarDetailDto 
                             { 
                                    CarId = c.CarId, 
                                    BrandName = b.BrandName,
                                    ModelName=c.ModelName, 
                                    Description=c.Description, 
                                    ColorName=co.ColorName
                             };

                return result.ToList();
            }
        }
    }
}
