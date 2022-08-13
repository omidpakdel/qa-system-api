using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Answer : Entity
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}