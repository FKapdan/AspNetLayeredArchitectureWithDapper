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
        public override async Task<IResultBase> AddAsync(Users Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Data);
            return await _repository.AddAsync(DBRequestModel);
        }
        public override IResultBase AddMultiple(IEnumerable<Users> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<UsersDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public override async Task<IResultBase> AddMultipleAsync(IEnumerable<Users> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<UsersDto>>(Datas);
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
        public override IDataResultBase<IEnumerable<Users>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<Users>>>(DbResult);
            return BusinessModel;
        }
        public override async Task<IDataResultBase<IEnumerable<Users>>> GetListAsync()
        {
            var DbResult = await _repository.GetListAsync();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<Users>>>(DbResult);
            return BusinessModel;
        }
        public override IDataResultBase<Users> Get(Users Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Entity);
            var DbResult = _repository.Get(DBRequestModel);

            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Users>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Kullanıcı bilgisi bulunamadı.";
            }
            return BusinessModel;
        }
        public override async Task<IDataResultBase<Users>> GetAsync(Users Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Entity);
            var DbResult = await _repository.GetAsync(DBRequestModel);

            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Users>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Kullanıcı bilgisi bulunamadı.";
            }
            return BusinessModel;
        }
        public override IDataResultBase<Users> Get(int Id)
        {
            var DbResult = _repository.Get(Id);

            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Users>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Kullanıcı bilgisi bulunamadı.";
            }
            return BusinessModel;
        }
        public override async Task<IDataResultBase<Users>> GetAsync(int Id)
        {
            var DbResult = await _repository.GetAsync(Id);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Users>>(DbResult);

            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Kullanıcı bilgisi bulunamadı.";
            }

            return BusinessModel;
        }
        public override IResultBase Update(Users Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Entity);
            return _repository.Update(DBRequestModel);
        }
        public override async Task<IResultBase> UpdateAsync(Users Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<UsersDto>(Entity);
            return await _repository.UpdateAsync(DBRequestModel);
        }
    }
}
