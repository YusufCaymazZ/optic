using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using ExcelDataReader;

namespace optic
{
    internal class excellReader
    {
        public DataTable ReadExcelFile(string filePath,bool Checked)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = Checked // İlk satır başlıkları içeriyorsa true yapın.
                        }
                    });
                    return result.Tables[0]; // İlk tabloyu döndürüyoruz.
                }
            }
        }

    }
}
