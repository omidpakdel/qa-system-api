using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionHandler : BaseHandler<DeleteQuestionHandler>, IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;
        public DeleteQuestionHandler(IMapper mapper, IQuestionRepository questionRepository) : base(mapper)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            await _questionRepository.DeleteByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}