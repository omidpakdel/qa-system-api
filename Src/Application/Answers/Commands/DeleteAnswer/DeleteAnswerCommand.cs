using System;
using MediatR;

namespace Application.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}