using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Domain
{
    public class ExpenseGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
