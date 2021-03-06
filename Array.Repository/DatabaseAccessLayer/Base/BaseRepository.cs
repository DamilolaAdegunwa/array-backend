﻿using Array.Repository.DatabaseContextLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Array.Repository.DatabaseAccessLayer.Base
{
    public class BaseRepository : IBaseRepository
    {
        #region fields
        private readonly ArrayDbContext _db;

        #endregion
        public BaseRepository()
        {
            _db = new ArrayDbContext();
        }
        #region methods
        public Task Create<T>(T model) where T : class
        {
            try
            {
                _db.Add(model);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<IEnumerable<T>> Get<T>(Func<T, bool> predicate) where T : class
        {
            try
            {
                var resp = _db.Find<IEnumerable<T>>(predicate);//This can just as well be casted to type T for a test
                return Task.FromResult(resp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<IEnumerable<T>> Get<T>(long[] Ids) where T:class
        {
            try
            {
                List<T> result = new List<T>();
                foreach (long Id in Ids)
                {
                    result.Add(_db.Find<T>(Id));
                }
                return Task.FromResult((IEnumerable<T>)result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<IEnumerable<T>> Get<T>() where T : class
        {
            try
            {
                var resp = _db.Find<IEnumerable<T>>();//This can just as well be casted to type T for a test
                return Task.FromResult(resp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<T> Get<T>(long Id) where T : class
        {
            try
            {
                var resp = _db.Find<T>(Id);
                return Task.FromResult(resp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task Update<T>(T model) where T : class
        {
            try
            {
                return _ = Task.FromResult(_db.Update(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task Delete<T>(T model) where T : class
        {
            try
            {
                return _ = Task.FromResult(_db.Remove(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> Count<T>(Func<T, bool> predicate) where T: class
        {
            try
            {
                var count = (await Get<T>(predicate)).ToList<T>().Count;
                var resp = await Task.FromResult(count);
                //Task => return Task.CompletedTask
                //Task<T> => Task.FromResult(t)
                //async Task =>  (awaitable)
                //async Task<T> => (awaitable) t
                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}