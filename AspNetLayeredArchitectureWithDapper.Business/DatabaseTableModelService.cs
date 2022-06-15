using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Business.Mapping;
using AspNetLayeredArchitectureWithDapper.Entities;
using AspNetLayeredArchitectureWithDapper.Entities.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities.Repository;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using System.Collections.Generic;

namespace AspNetLayeredArchitectureWithDapper.Business
{
    public class DatabaseTableModelService : IBusinessServiceBase<DatabaseTableModel>
    {
        private readonly IRepository<DatabaseTableModelDto> _repository;
        public DatabaseTableModelService(IRepository<DatabaseTableModelDto> Repository)
        {
            _repository = Repository;
        }
        public IResultBase Add(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return _repository.Add(DBRequestModel);
        }
        public IResultBase AddMultiple(IEnumerable<DatabaseTableModel> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<DatabaseTableModelDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public IResultBase Delete(int Id)
        {
            return _repository.Delete(Id);
        }

        public IDataResultBase<IEnumerable<DatabaseTableModel>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<IDataResultBase<IEnumerable<DatabaseTableModel>>>(DbResult);
            return BusinessModel;
        }

        public IDataResultBase<DatabaseTableModel> Get(int Id)
        {
            var DbResult = _repository.Get(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<IDataResultBase<DatabaseTableModel>>(DbResult);

            return BusinessModel;
        }

        public IResultBase Update(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return _repository.Update(DBRequestModel);
        }
    }
}
