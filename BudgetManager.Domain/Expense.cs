using BudgetManager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetManager.Domain
{
    public class Expense : EntityBase
    {
        public Reason Reason { get; set; }
        public ExpenseType ExpenseType { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
