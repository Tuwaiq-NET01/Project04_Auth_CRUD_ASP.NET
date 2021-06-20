using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    public partial class Reference
    {
        public Reference()
        {
            ReferenceTagJunctions = new HashSet<ReferenceTagJunction>();
        }

        [Key]
        public int Id { get; set; }
        public short CVEYear { get; set; }
        [Required]
        [StringLength(7)]
        public string CVEId { get; set; }
        [Required]
        public string URL { get; set; }

        [ForeignKey("CVEYear,CVEId")]
        [InverseProperty(nameof(Models.CVE.References))]
        public virtual CVE CVE { get; set; }
        [InverseProperty(nameof(ReferenceTagJunction.Reference))]
        public virtual ICollection<ReferenceTagJunction> ReferenceTagJunctions { get; set; }
    }
}
