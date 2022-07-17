using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Domain
{
    public class Checklist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public ICollection<CheckItem> CheckItems { get; set; }
    }
}
