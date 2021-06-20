using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    public partial class CWE
    {
        public CWE()
        {
            CveCweJunctions = new HashSet<CveCweJunction>();
        }

        [Key]
        public short Id { get; set; }
        [Required]
        [StringLength(127)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Abstraction { get; set; }
        [Required]
        [StringLength(10)]
        public string Status { get; set; }
        [Required]
        public string Description { get; set; }

        [InverseProperty(nameof(CveCweJunction.CWE))]
        [JsonIgnore]
        public virtual ICollection<CveCweJunction> CveCweJunctions { get; set; }
    }
}
