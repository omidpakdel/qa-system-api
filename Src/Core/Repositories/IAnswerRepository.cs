using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<Answer> GetById(Guid id);
    }
}