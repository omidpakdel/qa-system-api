using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Entities;
using Core.Repositories;
using MediatR;

namespace Application.Answers.Commands.UpsertAnswer
{
    public class UpsertAnswerHandler : BaseHandler<UpsertAnswerHandler>, IRequestHandler<UpsertAnswerCommand>
    {
        private readonly IAnswerRepository _answerRepository;
        public UpsertAnswerHandler(IMapper mapper, IAnswerRepository answerRepository) : base(mapper)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(UpsertAnswerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _answerRepository.GetByIdAsync(request.Id);
                entity.Text = request.Text;
                entity.QuestionId = request.QuestionId;

                await _answerRepository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                Console.Write(e.Message[..]);
                var entity = new Answer()
                {
                    Text = request.Text,
                    QuestionId = request.QuestionId,
                };
                await _answerRepository.AddAsync(entity);
            }
            return Unit.Value;                
        }
    }
}