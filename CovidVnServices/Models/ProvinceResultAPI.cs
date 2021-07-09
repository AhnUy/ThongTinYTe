using System.Collections.Generic;

namespace ThongTinYTe.CovidVnServices.Models
{
    public class ProvinceResultAPI
    {
        public bool include_total { get; set; }
        public int total { get; set; }
        public string resource_id { get; set; }
        public List<ProvinceRecord> records { get; set; }
    }
}