using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Base;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using Core.Services.Email;
using MediatR;

namespace Application.Qa.Commands.Create
{
    public class QaCreateHandler : BaseHandler<QaCreateHandler>, IRequestHandler<QaCreateCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IEmailService _emailService;

        public QaCreateHandler(IMapper mapper, IUserRepository userRepository,
            IUserAnswerRepository userAnswerRepository, IQuestionRepository questionRepository,
            IAnswerRepository answerRepository, IEmailService emailService) : base(mapper)
        {
            _userRepository = userRepository;
            _userAnswerRepository = userAnswerRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(QaCreateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByPhoneNumber(NormalizedPhoneNumber(phoneNumber: request.PhoneNumber));
            if (user == null)
            {
                user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = NormalizedPhoneNumber(phoneNumber: request.PhoneNumber),
                    Age = request.Age,
                };
                await _userRepository.AddAsync(user);
            }

            var dictionary = new Dictionary<string, string>();

            var time = DateTime.Now;

            foreach (var key in request.Answers.Keys)
            {
                var question = await _questionRepository.GetByIdAsync(Guid.Parse(key));

                var userAnswer = new UserAnswer {UserId = user.Id, QuestionId = Guid.Parse(key), CreatedAt = time};
                try
                {
                    var answer = await _answerRepository.GetById(Guid.Parse(request.Answers[key]));
                    userAnswer.AnswerId = answer.Id;
                    dictionary.Add(question.Title, answer.Text);
                }
                catch
                {
                    userAnswer.Value = request.Answers[key];
                    dictionary.Add(question.Title, userAnswer.Value);
                }

                await _userAnswerRepository.AddAsync(userAnswer);
            }

            await _emailService.SendEmail(user, dictionary);

            return Unit.Value;
        }

        private string NormalizedPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+989"))
            {
                return phoneNumber;
            }
            else if (phoneNumber.StartsWith("0"))
            {
                return phoneNumber.Remove(0).Insert(0, "+98");
            }
            else
            {
                throw new BadRequestException("Bad Phone Number");
            }
        }
    }
}