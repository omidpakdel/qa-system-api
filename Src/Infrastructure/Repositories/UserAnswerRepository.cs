using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories.Base;
using Persistence;
using Persistence.Data;

namespace Infrastructure.Repositories
{
    public class UserAnswerRepository : Repository<UserAnswer>, IUserAnswerRepository
    {
        public UserAnswerRepository(QaContext context) : base(context)
        {
        }
    }
}