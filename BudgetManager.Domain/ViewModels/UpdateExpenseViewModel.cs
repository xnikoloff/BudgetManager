using BudgetManager.Domain.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace BudgetManager.Domain.ViewModels
{
    public class UpdateExpenseViewModel
    {
        public Reason Reason { get; set; }

        [Display(Name = "Expense Type")]
        public ExpenseType ExpenseType { get; set; }

        [Display(Name = "Is Wish Item?")]
        public bool IsWishItem { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; }
    }
}
