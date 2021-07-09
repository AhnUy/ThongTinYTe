using System.Collections.Concurrent;
using System.Collections.Generic;
using ThongTinYTe.CovidVnServices.Models;

namespace ThongTinYTe.CovidVnServices
{
    public class CovidVnService : ICovidVnService
    {
        private readonly ConcurrentBag<ProvinceRecord> _records = null;

        public CovidVnService() {
            _records = new ConcurrentBag<ProvinceRecord>();
        }

        public IEnumerable<ProvinceRecord> GetRecords()
        {
            return _records;
        }

        public void ReplaceRecords(IEnumerable<ProvinceRecord> records)
        {
            this._records.Clear();
            foreach (var record in records) {
                this._records.Add(record);
            }
        }
    }
}