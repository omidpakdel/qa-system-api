using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Infrastructure.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(QaContext context) : base(context)
        {
        }

        public async Task<Answer> GetById(Guid id)
        {
            return await _context.Answers.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}