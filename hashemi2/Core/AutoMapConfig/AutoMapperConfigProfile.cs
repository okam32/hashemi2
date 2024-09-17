using AutoMapper;
using hashemi2.Core.Dtos;
using hashemi2.Core.Entities;

namespace hashemi2.Core.AutoMapConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<StockDto, Stock>();
            CreateMap<Stock, StockDto>();
            CreateMap<GoodDto, Good>().ReverseMap();
            CreateMap<Good,GoodDto>().ReverseMap();
            CreateMap<ShiftDto, Shift>();
            CreateMap<UserShiftDto, UserShift>();
        }

    }
}
