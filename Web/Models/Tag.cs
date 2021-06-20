using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ReferenceTagJunctions = new HashSet<ReferenceTagJunction>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty(nameof(ReferenceTagJunction.Tag))]
        public virtual ICollection<ReferenceTagJunction> ReferenceTagJunctions { get; set; }
    }
}
