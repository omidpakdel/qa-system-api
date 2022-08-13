using System;
using MediatR;

namespace Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}