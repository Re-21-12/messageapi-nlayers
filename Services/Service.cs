﻿using HelloApi.Repositories;
using HelloApi.Services;
namespace HelloApi.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _repository.PostAsync(entity);
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _repository.PutAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException($"Entidad con Id {id} no encontrado.");
            await _repository.DeleteAsync(id);
            return entity;
        }

    }
}