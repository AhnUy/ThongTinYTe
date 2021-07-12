namespace ThongTinYTe.CovidVnServices.Models
{
    public class CaseRecord
    {
        public int _id { get; set; }
        public int ID { get; set; }
        public string Patient { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Nationality { get; set; }
    }
}