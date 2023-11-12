using OfficeOpenXml;
using Quality2.Entities;

namespace Quality2.ExcelServices
{
    public class Report
    {
        public static byte[] GetReport(OrderQuality order, StandartQualityFilm standartFilm, Film film, StandartQualityTitle standartTitle) 
        {
            //var logger = new ILogger<Report>();
            //добавить ячейку ТУ, нормы, вес квадратного метра

            using var stream = new MemoryStream();
            var path = Path.Combine(Environment.CurrentDirectory, "wwwroot\\template.xlsx");
            Console.WriteLine(path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var report = new ExcelPackage(path);
            var sheet = report.Workbook.Worksheets["passport"];
            sheet.Cells["C2"].Value = order.Customer;
            sheet.Cells["E20"].Value = order.ProductionDate.ToString();
            sheet.Cells["E14"].Value = sheet.Cells["G8"].Value = order.OrderNumber;
            sheet.Cells["F22"].Value = $"НОРМА по {standartTitle.Title}";
            sheet.Cells["E34"].Value = standartTitle.Title;
            if (film != null)
            {
                sheet.Cells["H14"].Value = film.Color;
                sheet.Cells["H11"].Value = film.Mark;
                sheet.Cells["I23"].Value = ((double)order.MaxThickness - order.MinThickness) / 2 / film.Thickness;
                sheet.Cells["C11"].Value = order.Width.ToString() + "x" + ((double)film.Thickness / 1000).ToString() + " мм";
                sheet.Cells["I32"].Value = film.Density * film.Thickness;
            }

            sheet.Cells["I26"].Value = order.TensileStrengthMD;
            sheet.Cells["I27"].Value = order.TensileStrengthTD;
            sheet.Cells["I28"].Value = order.ElongationAtBreakMD;
            sheet.Cells["I29"].Value = order.ElongationAtBreakTD;
            sheet.Cells["I30"].Value = order.CoefficientOfFrictionS;
            sheet.Cells["I31"].Value = order.CoefficientOfFrictionD;
            if (standartFilm != null)
            {
                sheet.Cells["F23"].Value = standartFilm.ThicknessVariation != 0 ? standartFilm.ThicknessVariation : "-";
                sheet.Cells["F26"].Value = standartFilm.TensileStrengthMD != 0 ? standartFilm.TensileStrengthMD: "-";
                sheet.Cells["F27"].Value = standartFilm.TensileStrengthTD != 0 ? standartFilm.TensileStrengthTD : "-";
                sheet.Cells["F28"].Value = standartFilm.ElongationAtBreakMD != 0 ? standartFilm.ElongationAtBreakMD : "-";
                sheet.Cells["F29"].Value = standartFilm.ElongationAtBreakTD != 0 ? standartFilm.ElongationAtBreakTD : "-";
                sheet.Cells["F30"].Value = standartFilm.CoefficientOfFrictionS != 0 ? standartFilm.CoefficientOfFrictionS : "-";
                sheet.Cells["F31"].Value = standartFilm.CoefficientOfFrictionD != 0 ? standartFilm.CoefficientOfFrictionD : "-";
            }
                //sheet.Cells["B36"].Value = "ООО Нова Ролл Пак №"+ order.ProductionDate.ToString();
            report.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
