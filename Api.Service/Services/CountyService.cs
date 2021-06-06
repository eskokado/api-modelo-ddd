using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.County;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class CountyService : ICountyService
    {
        private readonly ICountyRepository _repository;

        private readonly IMapper _mapper;

        public CountyService(ICountyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CountyDto>> FindCompleteByName(string name)
        {
            var listEntity = await _repository.FindCompleteByName(name);
            return _mapper.Map<IEnumerable<CountyDto>>(listEntity);
        }

        public async Task<CountyDto> FindCompleteByIBGE(int codeIBGE)
        {
            var entity = await _repository.FindCompleteByIBGE(codeIBGE);
            return _mapper.Map<CountyDto>(entity);
        }

        public async Task<CountyDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CountyDto>(entity);
        }

        public async Task<IEnumerable<CountyDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<CountyDto>>(listEntity);
        }

        public async Task<CountyDtoCreateResult> Post(CountyDtoCreate county)
        {
            var model = _mapper.Map<CountyModel>(county);
            var entity = _mapper.Map<CountyEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<CountyDtoCreateResult>(result);
        }

        public async Task<CountyDtoUpdateResult> Put(CountyDtoUpdate county)
        {
            var model = _mapper.Map<CountyModel>(county);
            var entity = _mapper.Map<CountyEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<CountyDtoUpdateResult>(result);
        }
    }
}
