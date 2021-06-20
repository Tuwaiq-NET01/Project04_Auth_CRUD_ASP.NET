using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    public partial class CNA
    {
        public CNA()
        {
            Cves = new HashSet<CVE>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [InverseProperty(nameof(CVE.CNANavigation))]
        [JsonIgnore]
        public virtual ICollection<CVE> Cves { get; set; }
    }
}
