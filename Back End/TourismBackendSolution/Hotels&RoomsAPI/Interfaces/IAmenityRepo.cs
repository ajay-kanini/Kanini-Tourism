﻿namespace Hotels_RoomsAPI.Interfaces
{
    public interface IAmenityRepo<T, K>
    {
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K id);
        public Task<T> Get(K id);
        public Task<ICollection<T>> GetAll();   
    }
}
