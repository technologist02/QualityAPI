﻿using OfficeOpenXml;
using Quality2.Entities;

namespace Quality2.ExcelServices
{
    public class Report
    {
        public static byte[] GetReport(OrderQuality order, Film film) 
        {
            //добавить ячейку ТУ, нормы, вес квадратного метра
            using var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var report = new ExcelPackage("C:\\Data\\Программирование\\Projects\\Quality\\Quality2\\wwwroot/template.xlsx");
            var sheet = report.Workbook.Worksheets["passport"];
            sheet.Cells["C2"].Value = order.Customer;
            sheet.Cells["E20"].Value = order.ProductionDate.ToString();
            sheet.Cells["E14"].Value = sheet.Cells["G8"].Value = order.OrderNumber;
            sheet.Cells["H14"].Value = film.Color;
            sheet.Cells["C11"].Value = order.Width.ToString()+"x"+((double)film.Thickness/1000).ToString()+" мм";
            sheet.Cells["H11"].Value = film.Mark;
            sheet.Cells["I23"].Value = ((double)order.MaxThickness-order.MinThickness)/2/film.Thickness;
            sheet.Cells["I26"].Value = order.TensileStrengthMD;
            sheet.Cells["I27"].Value = order.TensileStrengthTD;
            sheet.Cells["I28"].Value = order.ElongationAtBreakMD;
            sheet.Cells["I29"].Value = order.ElongationAtBreakTD;
            sheet.Cells["I30"].Value = order.CoefficientOfFrictionS;
            sheet.Cells["I31"].Value = order.CoefficientOfFrictionD;
            //sheet.Cells["B36"].Value = "ООО Нова Ролл Пак №"+ order.ProductionDate.ToString();
            report.SaveAs(stream);
            return stream.ToArray(); 
        }
    }
}
