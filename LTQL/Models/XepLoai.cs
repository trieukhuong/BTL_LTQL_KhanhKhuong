using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTQL.Models
{
    [Table("XepLoais")]
    public class XepLoai
    {
        //ID(id:int)
        //Mã đoàn viên(madv:string)
        //Năm học(namhoc:int)
        //Nhận xét(nhanxet:string)
        //Xếp loại(xeploai:string)
        [Key]
        [DisplayName("Hoạt động ID")]
        public int Id { get; set; }
        [Required, DisplayName("Năm học")]
        public int Năm_hoc { get; set; }
        [Required, DisplayName("Nhận xét")]
        public string Nhan_xet { get; set; }
        [Required, DisplayName("Xếp loại")]
        public string Xep_loai { get; set; }
        [Required, DisplayName("Mã đoàn viên")]
        public int DoanVien_Id { get; set; }
        [ForeignKey("DoanVien_Id")]
        public DoanVien DoanVien { get; set; }

    }
}