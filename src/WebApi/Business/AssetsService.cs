﻿using Business.Mapping;
using Core.Abstracts;
using Core.Entities.Abstracts;
using Core.Entities.Results;
using Entities.Business;
using Entities.Repository;

namespace Business
{
    public class AssetsService : LayerAbstractBase<Assets>
    {
        private readonly LayerAbstractBase<AssetsDto> _repository;
        public AssetsService(LayerAbstractBase<AssetsDto> Repository)
        {
            _repository = Repository;
        }
        public override IResultBase Add(Assets Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Data);
            return _repository.Add(DBRequestModel);
        }
        public override async Task<IResultBase> AddAsync(Assets Data)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Data);
            return await _repository.AddAsync(DBRequestModel);
        }
        public override IResultBase AddMultiple(IEnumerable<Assets> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<AssetsDto>>(Datas);
            return _repository.AddMultiple(DBRequestModel);
        }
        public override async Task<IResultBase> AddMultipleAsync(IEnumerable<Assets> Datas)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<IEnumerable<AssetsDto>>(Datas);
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
        public override IDataResultBase<IEnumerable<Assets>> GetList()
        {
            var DbResult = _repository.GetList();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<Assets>>>(DbResult);
            return BusinessModel;
        }
        public override async Task<IDataResultBase<IEnumerable<Assets>>> GetListAsync()
        {
            var DbResult = await _repository.GetListAsync();
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<IEnumerable<Assets>>>(DbResult);
            return BusinessModel;
        }
        public override IDataResultBase<Assets> Get(Assets Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Entity);

            var DbResult = _repository.Get(DBRequestModel);
            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Assets>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Varlık bilgisi bulunamadı.";
            }
            return BusinessModel;
        }
        public override async Task<IDataResultBase<Assets>> GetAsync(Assets Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Entity);
            var DbResult = await _repository.GetAsync(DBRequestModel);

            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Assets>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Varlık bilgisi bulunamadı.";
            }
            return BusinessModel;
        }
        public override IDataResultBase<Assets> Get(int Id)
        {
            var DbResult = _repository.Get(Id);

            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Assets>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Varlık bilgisi bulunamadı.";
            }
            return BusinessModel;
        }
        public override async Task<IDataResultBase<Assets>> GetAsync(int Id)
        {
            var DbResult = await _repository.GetAsync(Id);

            var BusinessModel = BusinessMapper.Mapper.Map<DataResultBase<Assets>>(DbResult);
            if (BusinessModel.Success && BusinessModel.Data == null)
            {
                BusinessModel.Success = false;
                BusinessModel.Message = $"Varlık bilgisi bulunamadı.";
            }

            return BusinessModel;
        }
        public override IResultBase Update(Assets Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Entity);
            return _repository.Update(DBRequestModel);
        }
        public override async Task<IResultBase> UpdateAsync(Assets Entity)
        {
            var DBRequestModel = BusinessMapper.Mapper.Map<AssetsDto>(Entity);
            return await _repository.UpdateAsync(DBRequestModel);
        }
    }
}
