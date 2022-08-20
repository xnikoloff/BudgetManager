using BudgetManager.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Domain
{
    public class Expense : EntityBase
    {
        public Reason Reason { get; set; }

        public ExpenseType ExpenseType { get; set; }
        
        [Display(Name = "Is Wish Item?")]
        public bool IsWishItem { get; set; }
        
        [ForeignKey(nameof(ApplicationUserId))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(ExpenseGroup))]
        public int? ExpenseGroupId { get; set; }

        public ExpenseGroup ExpenseGroup { get; set; }
    }
}
