using AspNetLayeredArchitectureWithDapper.Entities.Business;
using AspNetLayeredArchitectureWithDapper.Entities.Results;
using AspNetLayeredArchitectureWithDapper.Web.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Web.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Assets, AssetsViewModel>();
            CreateMap<DataResultBase<IEnumerable<Assets>>, PageViewModel<IEnumerable<AssetsViewModel>>>()
                .ForMember(dest => dest.PageData, opt => opt.MapFrom(src => src.Data));
        }
    }
}
