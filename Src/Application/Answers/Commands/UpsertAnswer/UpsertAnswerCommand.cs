using System;
using MediatR;

namespace Application.Answers.Commands.UpsertAnswer
{
    public class UpsertAnswerCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
    }
}