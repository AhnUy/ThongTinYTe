using System.Collections.Generic;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.Models
{
    public class KhaiBaoToanDan
    {
        #region Thông tin cá nhân
        // Khai hộ
        public bool khai_ho { get; set; }
        // Họ tên
        public string ho_ten { get; set; }
        // Chứng minh nhân dân || Căn cước công dân
        public string cmnd_cccd { get; set; }
        // Năm sinh
        public int nam_sinh { get; set; }
        // Giới tính || select list
        public string gioi_tinh { get; set; }
        // Quốc tịch || select list
        public string quoc_tich { get; set; }
        #endregion

        #region Địa chỉ
        // Tỉnh thành || select list
        public string tinh_thanh { get; set; }
        // Địa chỉ
        public string dia_chi { get; set; }
        // Điện thoại
        public string dien_thoai { get; set; }
        // Email
        public string email { get; set; }
        #endregion

        #region Kiểm tra di chuyển, liên lạc
        // Trong vòng 14 ngày qua, Anh/Chị có đến tỉnh/thành phố, quốc gia/vùng lãnh thổ nào (Có thể đi qua nhiều nơi) || had_travel
        public bool had_travel { get; set; }
        // Trong vòng 14 ngày qua, Anh/Chị có thấy xuất hiện ít nhất 1 trong các dấu hiệu: sốt, ho, khó thở, viêm phổi, đau họng, mệt mỏi không? || have_symptom
        public bool had_symptom { get; set; }
        // Trong vòng 14 ngày qua, Anh/Chị có tiếp xúc với người bệnh hoặc nghi ngờ, mắc bệnh COVID-19
        public bool had_contact_infected_suspected { get; set; }
        #endregion
    }
}