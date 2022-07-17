using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetManager.Domain
{
    public class CheckItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsChecked { get; set; }

        [ForeignKey(nameof(CheckList))]
        public int? CheckListId { get; set; }

        public Checklist CheckList { get; set; }
    }
}
