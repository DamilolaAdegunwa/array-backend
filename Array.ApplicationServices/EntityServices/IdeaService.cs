using Array.Repository.DatabaseAccessLayer;
using Array.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace Array.ApplicationServices.EntityServices
{
    public class IdeaService : IIdeaService
    {
        #region fields and properties
        private readonly IIdeaRepository _ideaRepository;
        private readonly ILogger<IdeaService> _logger;
        #endregion
        #region constructor(s)
        public IdeaService(IIdeaRepository ideaRepository, ILogger<IdeaService> logger)
        {
            _ideaRepository = ideaRepository;
            _logger = logger;
        }
        #endregion
        #region methods
        public Task<int> Count(Func<Idea, bool> predicate)
        {
            return _ideaRepository.Count(predicate);
        }

        public Task Create(Idea model)
        {
            return _ideaRepository.Create(model);
        }

        public Task Delete(Idea model)
        {
            return _ideaRepository.Delete(model);
        }

        public Task<IEnumerable<Idea>> Get(Func<Idea, bool> predicate)
        {
            return _ideaRepository.Get(predicate);
        }

        public Task<IEnumerable<Idea>> Get(long[] Ids)
        {
            return _ideaRepository.Get(Ids);
        }

        public Task<IEnumerable<Idea>> Get()
        {
            return _ideaRepository.Get();
        }

        public Task<Idea> Get(long Id)
        {
            return _ideaRepository.Get(Id);
        }

        public Task Update(Idea model)
        {
            return _ideaRepository.Update(model);
        }
        #endregion
    }
}
