using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Questions.Commands.UpsertQuestion
{
    public class UpsertQuestionCommand : IRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int SortOrder { get; set; }
    }
}