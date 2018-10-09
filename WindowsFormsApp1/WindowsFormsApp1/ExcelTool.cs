using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WindowsFormsApp1.model;

namespace WindowsFormsApp1
{
    public class ExcelTool
    {
        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public static List<TestPoint> ExcelToDataList(string fileName, string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            int startRow = 0;
            List<TestPoint> dataList = new List<TestPoint>();
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = null;
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        var value1 = row.GetCell(0).ToString();
                        if (string.IsNullOrEmpty(value1))
                        {
                            continue;
                        }
                        TestPoint point = new TestPoint();
                        point.Angle = decimal.Parse(value1);
                        point.ActualV = decimal.Parse(row.GetCell(1).ToString());
                        point.IdealV = decimal.Parse(row.GetCell(2).ToString());
                        point.UpperV = decimal.Parse(row.GetCell(3).ToString());
                        point.DownV = decimal.Parse(row.GetCell(4).ToString());
                        dataList.Add(point);
                    }
                }

                return dataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public static void TableToExcel(DataTable dt, string file,Bitmap bitmap)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(); } else { workbook = null; }
            if (workbook == null) { return; }
            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            //添加图片
            using (MemoryStream ms = new MemoryStream())
            {

                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] bytes = ms.ToArray();

                int pictureIdx = workbook.AddPicture(bytes, NPOI.SS.UserModel.PictureType.PNG);  //添加图片

                HSSFPatriarch patriarch = (HSSFPatriarch)sheet.CreateDrawingPatriarch();

                HSSFClientAnchor anchor = new HSSFClientAnchor(0, 0, 0, 240, 6, 1, 6 + 6, 10);

                //图片位置，图片左上角为（col, row）

                HSSFPicture pict = (HSSFPicture)patriarch.CreatePicture(anchor, pictureIdx);

                pict.Resize(); //用图片原始大小来显示

            }
            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
        }
    }
}
