using Core.Entities.Results;
using Entities;
using Entities.Business;
using Entities.Repository;
using AutoMapper;

namespace Business.Mapping
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<DatabaseTableModel, DatabaseTableModelDto>().ReverseMap();

            CreateMap<UsersDto, Users>().ReverseMap();
            CreateMap<DataResultBase<UsersDto>, DataResultBase<Users>>();
            CreateMap<DataResultBase<IEnumerable<UsersDto>>, DataResultBase<IEnumerable<Users>>>();

            CreateMap<AssetsDto, Assets>().ReverseMap();
            CreateMap<DataResultBase<AssetsDto>, DataResultBase<Assets>>();
            CreateMap<DataResultBase<IEnumerable<AssetsDto>>, DataResultBase<IEnumerable<Assets>>>();

            CreateMap<IEnumerable<DatabaseTableModel>, IEnumerable<DatabaseTableModelDto>>().ReverseMap();

        }
    }
    public static class BusinessMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<BusinessProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
