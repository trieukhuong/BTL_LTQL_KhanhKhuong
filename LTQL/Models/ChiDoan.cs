using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL.Models
{
    [Table("ChiDoans")]
    public class ChiDoan
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Mã chi đoàn")]
        public string Ma_cd { get; set; }
        [Required, DisplayName("Tên chi đoàn")]
        public string Ten_cd { get; set; }
        public ICollection<DoanVien> DoanViens { get; set; }
    }
}