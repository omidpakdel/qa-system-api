using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Questions.Queries.GetQuestions
{
    public class GetQuestionsHandler : BaseHandler<GetQuestionsHandler>,IRequestHandler<GetQuestionsQuery, List<QuestionListDto>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionsHandler(IMapper mapper, IQuestionRepository questionRepository) : base(mapper)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<QuestionListDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var allQuestions = await _questionRepository.GetAllAsync();
            var orderedQuestions = allQuestions.OrderBy(c => c.SortOrder).ToList();
            return Mapper.Map<List<QuestionListDto>>(orderedQuestions);
        }

    }
}