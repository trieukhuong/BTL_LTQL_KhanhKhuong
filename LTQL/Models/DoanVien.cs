using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL.Models
{
    [Table("DoanViens")]
    public class DoanVien
    {
        [Key]
        [DisplayName("Doàn Viên ID")]
        public int Id { get; set; }
        [Required, DisplayName("Mã đoàn viên")]
        public string Ma_dv { get; set; }
        [Required, DisplayName("Tên đoàn viên")]
        public string Ten_dv { get; set; }
        [Required, DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay_sinh { get; set; }
        [Required, DisplayName("Quê quán")]
        public string Que_quan { get; set; }
        [Required, DisplayName("Dân tộc")]
        public string Dan_toc { get; set; }
        [Required, DisplayName("Ngày vào đoàn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay_vao_doan { get; set; }
        public int ChiDoan_Id { get; set; }
        [ForeignKey("ChiDoan_Id")]
        public ChiDoan ChiDoan { get; set; }
        public ICollection<XepLoai> XepLoais { get; set; }
    }
}