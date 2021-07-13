using System;
using System.ComponentModel.DataAnnotations;

namespace ThongTinYTe.Models
{
    public class KhaiBaoDiChuyen : KhaiBaoToanDan
    {
        #region Thông tin di chuyển
        [Required]
        public string phuong_tien{ get; set;}
        [Required]
        public string noi_di { get; set; }
        [Required]
        public string noi_den { get; set; }
        public string so_phuong_tien { get; set; }

        public string so_ghe { get; set;}
        [Required]
        public DateTime ngay_khoi_hanh { get; set;}
        #endregion

    }
}