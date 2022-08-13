using System.Collections.Generic;
using MediatR;

namespace Application.Questions.Queries.GetQuestions
{
    public class GetQuestionsQuery : IRequest<List<QuestionListDto>>
    {
        
    }
}