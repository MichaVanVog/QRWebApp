using AutoMapper;
using QR.Db.Models;
using QRWebApp.Models;

namespace QRWebApp.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
