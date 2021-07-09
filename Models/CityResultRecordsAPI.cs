namespace ThongTinYTe.Models
{
    public class CityResultRecordsAPI
    {
        public int _id { get; set; }
        public string HASC { get; set; }
        public string ISO { get; set; }
        public string FIPS { get; set; }
        public int Administration_Code { get; set; }
        public string Province { get; set; }
        public int Infected { get; set; }
        public int Active { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
    }
}