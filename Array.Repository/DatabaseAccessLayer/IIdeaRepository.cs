using Array.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Array.Repository.DatabaseAccessLayer
{
    public interface IIdeaRepository
    {
        Task Create(Idea model);
        Task<IEnumerable<Idea>> Get(Func<Idea, bool> predicate);
        Task<IEnumerable<Idea>> Get(long[] Ids);
        Task<IEnumerable<Idea>> Get();
        Task<Idea> Get(long Id);
        Task Update(Idea model);
        Task Delete(Idea model);
        Task<int> Count(Func<Idea, bool> predicate);
    }
}
