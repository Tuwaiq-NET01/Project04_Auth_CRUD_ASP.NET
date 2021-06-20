using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Web.Models
{
    public partial class CPE
    {
        public CPE()
        {
            CveCpeJunctions = new HashSet<CveCpeJunction>();
        }

        [Key]
        [MaxLength(16)]
        public byte[] id { get; set; }
        public byte part { get; set; }
        [StringLength(128)]
        public string vendor { get; set; }
        [StringLength(128)]
        public string product { get; set; }
        [StringLength(128)]
        public string version { get; set; }
        [StringLength(128)]
        public string update { get; set; }
        [StringLength(128)]
        public string edition { get; set; }
        [StringLength(128)]
        public string language { get; set; }
        [StringLength(128)]
        public string sw_edition { get; set; }
        [StringLength(128)]
        public string target_sw { get; set; }
        [StringLength(128)]
        public string target_hw { get; set; }
        [Required]
        public string vector { get; set; }

        [InverseProperty(nameof(CveCpeJunction.CPE))]
        [JsonIgnore]
        public virtual ICollection<CveCpeJunction> CveCpeJunctions { get; set; }
    }
}
