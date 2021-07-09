using System.Collections.Generic;

namespace ThongTinYTe.Models
{
    public class CityResultAPI
    {
        public bool include_total { get; set; }
        public string resource_id { get; set; }
        public List<dynamic> fields { get; set; }
        public string records_format { get; set; }
        public List<CityResultRecordsAPI> records { get; set; }
        public dynamic _links { get; set; }
        public int total { get; set; }
    }
}