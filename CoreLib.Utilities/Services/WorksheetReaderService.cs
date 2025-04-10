using CoreLib.Utilities.Interfaces.DtoModels.Services;
using CoreLib.Utilities.Interfaces.Services;
using System.Runtime.Versioning;
using Excel = Microsoft.Office.Interop.Excel;

namespace CoreLib.Utilities.Services
{
    public sealed class WorksheetReaderService : IWorksheetReaderService
    {
        [SupportedOSPlatform("windows")]
        public List<WorksheetDto> LoadFromExcel(string filePath)
        {
            // ❗ Данный метод:
            // - Работает только на Windows
            // - Требует установленный Microsoft Excel (полная версия, не web/online)
            // - Использует COM-библиотеку Microsoft.Office.Interop.Excel
            // - Не поддерживается на Linux/macOS и в средах без установленного Excel

            if (!OperatingSystem.IsWindows())
                throw new PlatformNotSupportedException("Этот метод поддерживается только в Windows");

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Не удается найти указанный файл", filePath);

            var list = new List<WorksheetDto>();

            var excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
            Excel._Worksheet worksheet = (Excel._Worksheet)workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;

            var rowCount = range.Rows.Count;

            for (var row = 2; row <= rowCount; row++)
            {
                var item = new WorksheetDto
                {
                    Column1 = (range.Cells[row, 1] as Excel.Range)?.Text.ToString(),
                    Column2 = (range.Cells[row, 2] as Excel.Range)?.Text.ToString(),
                    Column3 = (range.Cells[row, 3] as Excel.Range)?.Text.ToString(),
                    Column4 = (range.Cells[row, 4] as Excel.Range)?.Text.ToString(),
                    Column5 = (range.Cells[row, 5] as Excel.Range)?.Text.ToString()
                };

                list.Add(item);
            }

            workbook.Close(false);
            excelApp.Quit();

            return list;
        }
    }
}
