using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Question : Entity
    {
        [Required]
        public string Title { get; set; }
        public int Type { get; set; }
        public int SortOrder { get; set; }
    }
}