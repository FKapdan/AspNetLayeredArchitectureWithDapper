using Business.Mapping;
using Core.Abstracts;
using Core.Entities.Abstracts;
using Core.Entities.Results;
using Entities;
using Entities.Repository;

namespace Business
{
    public class UsersService : LayerAbstractBase<Users>
    {
        private readonly LayerAbstractBase<UsersDto> _repository;
        public UsersService(LayerAbstractBase<UsersDto> Repository)
        {
            _repository = Repository;
        }
        public override IResultBase Add(Users Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Data);
            return _repository.Add(DBRequestModel);
        }
        public override IResultBase AddMultiple(IEnumerable<Users> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<UsersDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public override IResultBase Delete(int Id)
        {
            return _repository.Delete(Id);
        }

        public override IDataResultBase<IEnumerable<Users>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<Users>>>(DbResult);
            return BusinessModel;
        }
        public override IDataResultBase<Users> Get(Users Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Entity);
            var DbResult = _repository.Get(DBRequestModel);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Users>>(DbResult);

            return BusinessModel;
        }
        public override IDataResultBase<Users> Get(int Id)
        {
            var DbResult = _repository.Get(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Users>>(DbResult);

            return BusinessModel;
        }

        public override IResultBase Update(Users Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Entity);
            return _repository.Update(DBRequestModel);
        }
    }
}
