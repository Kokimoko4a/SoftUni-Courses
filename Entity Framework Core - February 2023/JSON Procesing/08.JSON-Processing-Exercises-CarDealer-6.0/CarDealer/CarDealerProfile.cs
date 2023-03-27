using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //supplier
            this.CreateMap<SuplierDto, Supplier>();

            // part
            this.CreateMap<PartDto, Part>();

            //car
            this.CreateMap<CarDto, Car>();

            //customer
            this.CreateMap<CustomerDto, Customer>();

            //sales
            this.CreateMap<SalesDto, Sale>();
        }
    }
}
