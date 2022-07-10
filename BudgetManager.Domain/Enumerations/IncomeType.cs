using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetManager.Domain.Enumerations
{
    public enum IncomeType
    {
        Salary = 1,
        Crypto = 2,
        [Display(Name = "Side Bussiness")]
        SideBusiness = 3,
        Grandma = 4,
        Person = 5
    }
}
