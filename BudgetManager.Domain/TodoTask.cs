using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetManager.Domain
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Task { get; set; }

        public DateTime Time { get; set; }

        public bool IsCompleted { get; set; }

        [ForeignKey(nameof(Todo))]
        public int? TodoId { get; set; }

        public Todo Todo { get; set; }
    }
}
