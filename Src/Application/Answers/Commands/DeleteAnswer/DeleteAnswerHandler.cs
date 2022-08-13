using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using Application.Questions.Commands.DeleteQuestion;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Answers.Commands.DeleteAnswer
{
    public class DeleteAnswerHandler : BaseHandler<DeleteAnswerHandler>, IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IAnswerRepository _answerRepository;
        public DeleteAnswerHandler(IMapper mapper, IAnswerRepository answerRepository) : base(mapper)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            await _answerRepository.DeleteByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}