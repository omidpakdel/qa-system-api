using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using MediatR;

namespace Application.Questions.Commands.UpsertQuestion
{
    public class UpsertQuestionHandler : BaseHandler<UpsertQuestionHandler>, IRequestHandler<UpsertQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;
        
        public UpsertQuestionHandler(IMapper mapper, IQuestionRepository questionRepository) : base(mapper)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(UpsertQuestionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _questionRepository.GetByIdAsync(request.Id);
                entity.Title = request.Title;
                entity.Type = request.Type;
                entity.SortOrder = request.SortOrder;

                await _questionRepository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                Console.Write(e.Message[..]);
                var entity = new Question()
                {
                    Title = request.Title,
                    Type = request.Type,
                    SortOrder = request.SortOrder,
                };
                await _questionRepository.AddAsync(entity);
            }
            return Unit.Value;                
        }
    }
}