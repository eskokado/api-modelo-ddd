using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Uf;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class UfService : IUfService
    {
        private readonly IUfRepository _repository;

        private readonly IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UfDto>> FindByName(string name)
        {
            var listEntity = await _repository.FindByName(name);
            return _mapper.Map<IEnumerable<UfDto>>(listEntity);
        }

        public async Task<UfDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UfDto>(entity);
        }

        public async Task<IEnumerable<UfDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UfDto>>(listEntity);
        }

        public async Task<UfDtoCreateResult> Post(UfDtoCreate uf)
        {
            var model = _mapper.Map<UfModel>(uf);
            var entity = _mapper.Map<UfEntity>(model);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UfDtoCreateResult>(result);
        }

        public async Task<UfDtoUpdateResult> Put(UfDtoUpdate uf)
        {
            var model = _mapper.Map<UfModel>(uf);
            var entity = _mapper.Map<UfEntity>(model);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UfDtoUpdateResult>(result);
        }

    }
}
