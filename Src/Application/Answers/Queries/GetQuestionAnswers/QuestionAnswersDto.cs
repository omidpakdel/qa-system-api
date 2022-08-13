using System;
using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Answers.Queries.GetQuestionAnswers
{
    public class QuestionAnswersDto : IMapFrom<Answer>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid QuestionId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Answer, QuestionAnswersDto>().ReverseMap();
        }
    }
}