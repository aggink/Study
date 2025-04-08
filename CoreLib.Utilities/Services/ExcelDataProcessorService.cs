using CoreLib.Utilities.Extensions;
using CoreLib.Utilities.Interfaces.Services;

namespace CoreLib.Utilities.Services
{
    public class ExcelDataProcessorService : IExcelDataProcessorService
    {
        public void ExportUniqueData(string inputFilePath, string outputFilePath)
        {
            var service = new WorksheetReaderService();
            var worksheet = service.LoadFromExcel(inputFilePath);

            var list = new HashSet<string>();
            foreach (var item in worksheet)
            {
                list.Add(item.Column4.CleanWhitespace());
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var item in list.OrderBy(x => x))
                {
                    writer.WriteLine(item);
                    writer.WriteLine(string.Empty);
                }
            }
        }
    }
}
