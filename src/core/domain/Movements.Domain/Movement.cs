using System;
using System.ComponentModel.DataAnnotations;

namespace Movements.Domain
{
    public class Movement
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdCategory { get; set; }

        public Guid IdGroup { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
