using AspNetLayeredArchitectureWithDapper.Business.Mapping;
using AspNetLayeredArchitectureWithDapper.Core.Abstracts;
using AspNetLayeredArchitectureWithDapper.Core.Results;
using AspNetLayeredArchitectureWithDapper.Entities.Business;
using AspNetLayeredArchitectureWithDapper.Entities.Repository;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Business
{
    public class AssetsService : BusinessServiceBase<Assets>
    {
        private readonly IRepository<AssetsDto> _repository;
        public AssetsService(IRepository<AssetsDto> Repository)
        {
            _repository = Repository;
        }
        public override IResultBase Add(Assets Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Data);
            return _repository.Add(DBRequestModel);
        }
        public override IResultBase AddMultiple(IEnumerable<Assets> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<AssetsDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public override IResultBase Delete(int Id)
        {
            return _repository.Delete(Id);
        }

        public override IDataResultBase<IEnumerable<Assets>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<Assets>>>(DbResult);
            return BusinessModel;
        }
        public override IDataResultBase<Assets> Get(Assets Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Entity);
            var DbResult = _repository.Get(DBRequestModel);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Assets>>(DbResult);

            return BusinessModel;
        }
        public override IDataResultBase<Assets> Get(int Id)
        {
            var DbResult = _repository.Get(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Assets>>(DbResult);

            return BusinessModel;
        }

        public override IResultBase Update(Assets Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Entity);
            return _repository.Update(DBRequestModel);
        }
    }
}
