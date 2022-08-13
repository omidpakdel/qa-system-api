using System;
using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Questions.Queries.GetQuestions
{
    public class QuestionListDto : IMapFrom<Question>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionListDto>().ReverseMap();
        }
    }
}