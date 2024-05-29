using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetLast5CarsWithBrandQueryResult> Handle()
        {
            var values = _carRepository.GetLast5CarWithBrand();
            return values.Select(x => new GetLast5CarsWithBrandQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Transmission = x.Transmission,
                Seat = x.Seat,
                BrandName = x.Brand.Name
            }).ToList();
        }
    }
}
