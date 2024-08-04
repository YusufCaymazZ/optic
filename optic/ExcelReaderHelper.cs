using ExcelDataReader;
using System.Data;
using System.IO;

public class ExcelReaderHelper
{
    public static DataTable ReadExcelFile(string filePath)
    {
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = data => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });

                // İlk tabloyu döndür
                return dataSet.Tables[0];
            }
        }
    }
}
