using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Qa.Commands.Create
{
    public class QaCreateCommand : IRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Dictionary<string,string> Answers { get; set; }
    }
}