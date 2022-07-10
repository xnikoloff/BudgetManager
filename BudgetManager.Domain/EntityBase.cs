using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetManager.Domain
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
    }
}
