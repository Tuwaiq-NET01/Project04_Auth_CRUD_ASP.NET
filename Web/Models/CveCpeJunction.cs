using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    [Table("CveCpeJunction")]
    public partial class CveCpeJunction
    {
        [Key]
        [MaxLength(16)]
        public byte[] CPEId { get; set; }
        [Key]
        [StringLength(7)]
        public string CVEId { get; set; }
        [Key]
        public short CVEYear { get; set; }

        [ForeignKey(nameof(CPEId))]
        [InverseProperty("CveCpeJunctions")]
        public virtual CPE CPE { get; set; }
        [ForeignKey("CVEYear,CVEId")]
        [InverseProperty(nameof(Models.CVE.CveCpeJunctions))]
        public virtual CVE CVE { get; set; }
    }
}
