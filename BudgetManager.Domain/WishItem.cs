using BudgetManager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetManager.Domain
{
    public class WishItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsOwned { get; set; }

        public DateTime DateOwned { get; set; }

        public Priority Priority { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
