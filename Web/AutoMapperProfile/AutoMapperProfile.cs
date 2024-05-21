using Core.Entities.Results;
using Entities.Business;
using Web.ViewModels;
using AutoMapper;

namespace Web.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Assets, AssetsViewModel>().ReverseMap();
            CreateMap<DataResultBase<IEnumerable<Assets>>, PageViewModel<IEnumerable<AssetsViewModel>>>()
                .ForMember(dest => dest.PageData, opt => opt.MapFrom(src => src.Data));
        }
    }
}
