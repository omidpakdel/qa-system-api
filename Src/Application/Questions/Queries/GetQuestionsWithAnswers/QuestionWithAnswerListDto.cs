using System;
using System.Collections.Generic;
using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Questions.Queries.GetQuestionsWithAnswers
{
    public class QuestionWithAnswerListDto : IMapFrom<Question>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public List<AnswerDto> Answers { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionWithAnswerListDto>().ReverseMap();
        }
    }
}