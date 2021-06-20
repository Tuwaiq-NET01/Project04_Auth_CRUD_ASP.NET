using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    [Table("CveCweJunction")]
    public partial class CveCweJunction
    {
        [Key]
        public int Id { get; set; }
        public short CVEYear { get; set; }
        [Required]
        [StringLength(7)]
        public string CVEId { get; set; }
        public short CWEId { get; set; }

        [ForeignKey("CVEYear,CVEId")]
        [InverseProperty(nameof(Models.CVE.CveCweJunctions))]
        public virtual CVE CVE { get; set; }
        [ForeignKey(nameof(CWEId))]
        [InverseProperty("CveCweJunctions")]
        public virtual CWE CWE { get; set; }
    }
}
