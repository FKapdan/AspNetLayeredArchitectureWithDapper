using Business.Mapping;
using Core.Entities.Abstracts;
using Core.Entities.Results;
using Entities;
using Entities.Repository;
using Repository;
using Repository.Interfaces;

namespace Business
{
    public class DatabaseTableModelService : BusinessServiceBase<DatabaseTableModel>
    {
        private readonly RepositoryBase<DatabaseTableModelDto> _repository;
        public DatabaseTableModelService(RepositoryBase<DatabaseTableModelDto> Repository)
        {
            _repository = Repository;
        }
        public override IResultBase Add(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return _repository.Add(DBRequestModel);
        }
        public override IResultBase AddMultiple(IEnumerable<DatabaseTableModel> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<DatabaseTableModelDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public override IResultBase Delete(int Id)
        {
            return _repository.Delete(Id);
        }

        public override IDataResultBase<IEnumerable<DatabaseTableModel>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<DatabaseTableModel>>>(DbResult);
            return BusinessModel;
        }

        public override IDataResultBase<DatabaseTableModel> Get(int Id)
        {
            var DbResult = _repository.Get(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<DatabaseTableModel>>(DbResult);

            return BusinessModel;
        }

        public override IResultBase Update(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return _repository.Update(DBRequestModel);
        }
    }
}
