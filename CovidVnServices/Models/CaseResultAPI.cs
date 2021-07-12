using System.Collections.Generic;

namespace ThongTinYTe.CovidVnServices.Models
{
    public class CaseResultAPI
    {
        public bool include_total { get; set; }
        public string resource_id { get; set; }
        public List<CaseRecord> records { get; set; }
        public int total { get; set; }
    }
}