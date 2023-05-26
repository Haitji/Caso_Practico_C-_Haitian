﻿using AutoMapper;
using Bootcamp_store_backend.Domain.Persistence;

namespace Bootcamp_store_backend.Application.Services
{
    public class GenericService<E,D>: IGenericService<D>
        where E : class 
        where D : class
    {
        protected readonly IGenericRepository<E> _repository;
        protected readonly IMapper _mapper;

        public GenericService(IGenericRepository<E> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual void Delete(long id)
        {
            _repository.Delete(id);
        }

        public virtual List<D> GetAll()
        {
            var categories = _repository.GetAll();
            var categoriesDto = _mapper.Map<List<D>>(categories);
            return categoriesDto;
        }

        public virtual D Get(long id)
        {
            var category = _repository.GetById(id);
            return _mapper.Map<D>(category);
        }

        public virtual D Insert(D dto)
        {
            E entity = _mapper.Map<E>(dto);
            entity = _repository.Insert(entity);
            return _mapper.Map<D>(entity);
        }

        public virtual D Update(D dto)
        {
            E entity = _mapper.Map<E>(dto);
            entity = _repository.Update(entity);
            return _mapper.Map<D>(entity);
        }
    }
}
