using CsvHelper;
using PECANO.API.Domain.Models;
using System.Formats.Asn1;
using System.Globalization;

namespace PECANO.API.Shared.CSV
{
    public class CsvReaderService
    {
        public List<Trabajador> ReadCsvFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Trabajador>();
                return new List<Trabajador>(records);
            }
        }
    }
}
