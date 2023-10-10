using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentacarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentacarContext context = new RentacarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join r in context.Rentals on c.CarId equals r.CarId
                             select new RentalDetailDto 
                             {
                                 CarId = c.CarId,
                                 RentalId = r.RentalId,
                                 BrandId = b.BrandId,

                                 BrandName = b.BrandName,
                                 ModelName = c.ModelName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 ColorName = co.ColorName
                             };

                return result.ToList();
            }
        }
    }
}
