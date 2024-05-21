using Business.Mapping;
using Core.Abstracts;
using Core.Entities.Abstracts;
using Core.Entities.Results;
using Entities;
using Entities.Repository;

namespace Business
{
    public class DatabaseTableModelService : LayerAbstractBase<DatabaseTableModel>
    {
        private readonly LayerAbstractBase<DatabaseTableModelDto> _repository;
        public DatabaseTableModelService(LayerAbstractBase<DatabaseTableModelDto> Repository)
        {
            _repository = Repository;
        }
        public override IResultBase Add(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return _repository.Add(DBRequestModel);
        }
        public override async Task<IResultBase> AddAsync(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return await _repository.AddAsync(DBRequestModel);
        }
        public override IResultBase AddMultiple(IEnumerable<DatabaseTableModel> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<DatabaseTableModelDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public override async Task<IResultBase> AddMultipleAsync(IEnumerable<DatabaseTableModel> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<DatabaseTableModelDto>>(Datas);
            return await _repository.AddMultipleAsync(DBRequestModel);
        }
        public override IResultBase Delete(int Id)
        {
            return _repository.Delete(Id);
        }
        public override async Task<IResultBase> DeleteAsync(int Id)
        {
            return await _repository.DeleteAsync(Id);
        }
        public override IDataResultBase<IEnumerable<DatabaseTableModel>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<DatabaseTableModel>>>(DbResult);
            return BusinessModel;
        }
        public override async Task<IDataResultBase<IEnumerable<DatabaseTableModel>>> GetListAsync()
        {
            var DbResult = await _repository.GetListAsync();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<DatabaseTableModel>>>(DbResult);
            return BusinessModel;
        }
        public override IDataResultBase<DatabaseTableModel> Get(int Id)
        {
            var DbResult = _repository.Get(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<DatabaseTableModel>>(DbResult);

            return BusinessModel;
        }
        public override async Task<IDataResultBase<DatabaseTableModel>> GetAsync(int Id)
        {
            var DbResult = await _repository.GetAsync(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<DatabaseTableModel>>(DbResult);

            return BusinessModel;
        }
        public override IResultBase Update(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return _repository.Update(DBRequestModel);
        }
        public override async Task<IResultBase> UpdateAsync(DatabaseTableModel Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<DatabaseTableModelDto>(Data);
            return await _repository.UpdateAsync(DBRequestModel);
        }
    }
}
