using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Questions.Queries.GetQuestionsWithAnswers
{
    public class GetQuestionsWithAnswersHandler : BaseHandler<GetQuestionsWithAnswersHandler>,IRequestHandler<GetQuestionsWithAnswersQuery, List<QuestionWithAnswerListDto>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public GetQuestionsWithAnswersHandler(IMapper mapper, IQuestionRepository questionRepository, IAnswerRepository answerRepository) : base(mapper)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<List<QuestionWithAnswerListDto>> Handle(GetQuestionsWithAnswersQuery request, CancellationToken cancellationToken)
        {
            var allQuestions = await _questionRepository.GetAllAsync();
            var orderedQuestions = allQuestions.OrderBy(c => c.SortOrder).ToList();
            var mapped = Mapper.Map<List<QuestionWithAnswerListDto>>(orderedQuestions);
            var result = new List<QuestionWithAnswerListDto>();
            foreach (var dto in mapped)
            {
                var answers = await _answerRepository.GetAsync(a => a.QuestionId == dto.Id);
                if (answers.Count < 1) continue;
                dto.Answers = answers.Select(a => new AnswerDto()
                {
                    Id = a.Id,
                    Text = a.Text,
                }).ToList();
                result.Add(dto);
            }
            return result;
        }

    }
}