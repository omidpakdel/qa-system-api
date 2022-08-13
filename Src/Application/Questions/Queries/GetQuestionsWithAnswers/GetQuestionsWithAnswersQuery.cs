using System.Collections.Generic;
using MediatR;

namespace Application.Questions.Queries.GetQuestionsWithAnswers
{
    public class GetQuestionsWithAnswersQuery : IRequest<List<QuestionWithAnswerListDto>>
    {
        
    }
}