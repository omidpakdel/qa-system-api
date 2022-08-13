using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Core.Entities;
using Core.Repositories.Base;

namespace Core.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
    }
}