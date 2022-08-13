using System;
using System.Collections.Generic;
using MediatR;

namespace Application.Answers.Queries.GetQuestionAnswers
{
    public class GetQuestionAnswersQuery : IRequest<List<QuestionAnswersDto>>
    {
        public Guid QuestionId { get; set; }
    }
}