using Array.Repository.DatabaseAccessLayer.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Array.Repository.Entities;
using System.Linq;
namespace Array.Repository.DatabaseAccessLayer
{
    public class IdeaRepository : IIdeaRepository
    {
        #region fields
        private readonly IBaseRepository _baseRepository;
        private readonly ILogger<IdeaRepository> _logger;
        #endregion
        #region constructor
        public IdeaRepository(IBaseRepository baseRepository, ILogger<IdeaRepository> logger)
        {
            _baseRepository = baseRepository;
            _logger = logger;
        }
        #endregion

        #region methods
        public async Task<int> Count(Func<Idea, bool> predicate)
        {
            return (await Get(predicate)).ToList().Count;
        }
        public Task Create(Idea model)
        {
            return _baseRepository.Create(model);
        }

        public Task Delete(Idea model)
        {
            return _baseRepository.Delete<Idea>(model);
        }

        public Task<IEnumerable<Idea>> Get(Func<Idea, bool> predicate)
        {
            return _baseRepository.Get<Idea>(predicate);
        }

        public Task<IEnumerable<Idea>> Get(long[] Ids)
        {
            return _baseRepository.Get<Idea>(Ids);
        }

        public Task<IEnumerable<Idea>> Get() 
        {
            return _baseRepository.Get<Idea>();
        }

        public Task<Idea> Get(long Id)
        {
            return _baseRepository.Get<Idea>(Id);
        }

        public Task Update(Idea model) 
        {
            return _baseRepository.Update(model);
        }
        #endregion
    }
}
