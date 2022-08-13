using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Answers.Queries.GetQuestionAnswers
{
    public class GetQuestionAnswersHandler : BaseHandler<GetQuestionAnswersHandler>, IRequestHandler<GetQuestionAnswersQuery, List<QuestionAnswersDto>>
    {
        private readonly IAnswerRepository _answerRepository;
        public GetQuestionAnswersHandler(IMapper mapper, IAnswerRepository answerRepository) : base(mapper)
        {
            _answerRepository = answerRepository;
        }

        public async Task<List<QuestionAnswersDto>> Handle(GetQuestionAnswersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _answerRepository.GetAsync(a => a.QuestionId == request.QuestionId);
            return Mapper.Map<List<QuestionAnswersDto>>(entities.ToList());
        }
    }
}