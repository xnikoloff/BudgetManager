using BudgetManager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetManager.Domain
{
    public class Income : EntityBase
    {
        public string Sender { get; set; }
        public IncomeType IncomeType { get; set; }
        public string ApplicationUserId { get; set; }
        
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
