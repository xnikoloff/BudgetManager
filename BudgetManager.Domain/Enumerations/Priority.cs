using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetManager.Domain.Enumerations
{
    public enum Priority
    {
        [Display(Name = "Not Important")]
        NotImportant = 1,
        Normal = 2,
        Urgent = 3
    }
}
