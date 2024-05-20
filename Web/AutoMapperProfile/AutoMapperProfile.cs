using AspNetLayeredArchitectureWithDapper.Core.Results;
using AspNetLayeredArchitectureWithDapper.Entities.Business;
using AspNetLayeredArchitectureWithDapper.Web.ViewModels;
using AutoMapper;

namespace AspNetLayeredArchitectureWithDapper.Web.AutoMapperProfile
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
