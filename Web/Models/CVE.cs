using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    [Index(nameof(CreatedAt), Name = "idx_CreatedAt")]
    public partial class CVE
    {
        public CVE()
        {
            CveCpeJunctions = new HashSet<CveCpeJunction>();
            CveCweJunctions = new HashSet<CveCweJunction>();
            References = new HashSet<Reference>();
        }

        [Key]
        public short Year { get; set; }
        [Key]
        [StringLength(7)]
        public string Id { get; set; }
        public short CNA { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdatedAt { get; set; }
        public byte? CVSSv2Impact { get; set; }
        public byte? CVSSv3Impact { get; set; }

        [ForeignKey(nameof(CNA))]
        [InverseProperty("Cves")]
        public virtual CNA CNANavigation { get; set; }
        [InverseProperty(nameof(CveCpeJunction.CVE))]
        public virtual ICollection<CveCpeJunction> CveCpeJunctions { get; set; }
        [InverseProperty(nameof(CveCweJunction.CVE))]
        public virtual ICollection<CveCweJunction> CveCweJunctions { get; set; }
        [InverseProperty(nameof(Reference.CVE))]
        public virtual ICollection<Reference> References { get; set; }
    }
}
