using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class UserAnswer : Entity
    {
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        [Required]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid? AnswerId { get; set; }
        public Answer Answer { get; set; }
        
        [MaxLength(500)]
        public string Value { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}