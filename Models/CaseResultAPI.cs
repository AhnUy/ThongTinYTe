using System.Collections.Generic;

namespace ThongTinYTe.Models
{
    public class CaseResultAPI
    {
        public bool include_total { get; set; }
        public string resource_id { get; set; }
        public List<dynamic> fields { get; set; }
        public string records_format { get; set; }
        public List<CaseResultRecordsAPI> records { get; set; }
    }
}