using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    [Table("ReferenceTagJunction")]
    public partial class ReferenceTagJunction
    {
        [Key]
        public int ReferenceId { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey(nameof(ReferenceId))]
        [InverseProperty("ReferenceTagJunctions")]
        public virtual Reference Reference { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("ReferenceTagJunctions")]
        public virtual Tag Tag { get; set; }
    }
}
