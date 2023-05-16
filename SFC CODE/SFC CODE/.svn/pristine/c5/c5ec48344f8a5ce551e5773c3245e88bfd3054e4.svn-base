using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
namespace SysBasicClass
{
    public class Export
    {
        public static bool OutToExcelFromDataGridView(string title, DataGridView dgv, bool isShowExcel)
        {
            int titleColumnSpan = 0;//标题的跨列数
            string fileName = "";//保存的excel文件名
            int columnIndex = 1;//列索引
            if (dgv.Rows.Count == 0)
                return false;
            /*保存对话框*/
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            sfd.FileName = title + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fileName = sfd.FileName;
                /*建立Excel对象*/
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                if (excel == null)
                {
                    MessageBox.Show("无法创建Excel对象,可能您的计算机未安装Excel!");
                    return false;
                }
                try
                {
                    excel.Application.Workbooks.Add(true);
                    excel.Visible = isShowExcel;
                    /*分析标题的跨列数*/
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible == true)
                            titleColumnSpan++;
                    }
                    /*合并标题单元格*/
                    //excel.ActiveSheet
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                    //worksheet.get_Range("A1", "C10").Merge();            
                    worksheet.get_Range(worksheet.Cells[1, 1] as Range, worksheet.Cells[1, titleColumnSpan] as Range).Merge();
                    /*生成标题*/
                    excel.Cells[1, 1] = title;
                    (excel.Cells[1, 1] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//标题居中
                    //生成字段名称
                    columnIndex = 1;
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (dgv.Columns[i].Visible == true)
                        {
                            excel.Cells[2, columnIndex] = dgv.Columns[i].HeaderText;
                            (excel.Cells[2, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignCenter;//字段居中
                            columnIndex++;
                        }
                    }
                    //填充数据              
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        columnIndex = 1;
                        for (int j = 0; j < dgv.ColumnCount; j++)
                        {
                            if (dgv.Columns[j].Visible == true)
                            {
                                if (dgv[j, i].ValueType == typeof(string))
                                {
                                    excel.Cells[i + 3, columnIndex] = "'" + dgv[j, i].Value.ToString();
                                }
                                else
                                {
                                    excel.Cells[i + 3, columnIndex] = dgv[j, i].Value.ToString();
                                }
                                (excel.Cells[i + 3, columnIndex] as Range).HorizontalAlignment = XlHAlign.xlHAlignLeft;//字段居中
                                columnIndex++;
                            }
                        }
                    }
                    worksheet.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                catch { }
                finally
                {
                    excel.Quit();
                    excel = null;
                    GC.Collect();
                }
                //KillProcess("Excel");
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 自定义导出位置，带等待进度条的导出EXCEL方法--by hs ke
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="dt">传入DataTable</param>
        public static void ExportExcel(string fileName, System.Data.DataTable dt)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消  
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel,无法使用导出功能");
                return;
            }
            SysBasicClass.WaitFormService.CreateWaitForm("导出数据等待中...");
            try
            {
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
                Microsoft.Office.Interop.Excel.Range range;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[dt.Rows.Count + 1, dt.Columns.Count]);
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.NumberFormat = "@";//防止部分数据类型或者以0开头的数字字符串会被EXCEL自动格式化掉，所有单元格先格式化为文本
                //写入标题  
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;//.HeaderText;
                    if (dt.Columns[i].DataType.ToString() == "System.DateTime")
                    {
                        range = worksheet.get_Range(worksheet.Cells[2, i + 1], worksheet.Cells[dt.Rows.Count + 1, i + 1]);
                        range.NumberFormat = "yyyy-MM-dd hh:mm:ss";//所有日期类型重新格式化
                    }
                }
                //写入数值  
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();

                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应              
                worksheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, dt.Columns.Count]);

                range.Font.ColorIndex = 1;//字体颜色 .ColorIndex = 11 1黑 2白 3红色 4 绿，5蓝 13紫 33深蓝;
                range.Interior.ColorIndex = 33;//背景颜色
                //range.NumberFormat = "yyyy-MM-dd hh:mm:ss";
                //range.Font.Size = 12;
                range.Font.Bold = true;
                range.RowHeight = 20;

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }
                }
                xlApp.Quit();
                GC.Collect();//强行销毁 
            }
            catch
            {
            }
            finally
            {
                SysBasicClass.WaitFormService.CloseWaitForm();
            }

            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ExportExcelFromDataGridView(string fileName, DataGridView dgv)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消  
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel,无法使用导出功能");
                return;
            }
            SysBasicClass.WaitFormService.CreateWaitForm("导出数据等待中...");
            try
            {
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
                Microsoft.Office.Interop.Excel.Range range;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[dgv.Rows.Count + 1, dgv.Columns.Count]);
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.NumberFormat = "@";//防止部分数据类型或者以0开头的数字字符串会被EXCEL自动格式化掉，所有单元格先格式化为文本
                //写入标题  
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgv.Columns[i].Name;//.HeaderText;
                    if (dgv.Columns[i].ValueType.ToString() == "System.DateTime")
                    {
                        range = worksheet.get_Range(worksheet.Cells[2, i + 1], worksheet.Cells[dgv.Rows.Count + 1, i + 1]);
                        range.NumberFormat = "yyyy-MM-dd hh:mm:ss";//所有日期类型重新格式化
                    }
                }
                //写入数值  
                for (int r = 0; r < dgv.Rows.Count; r++)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dgv.Rows[r].Cells[i].Value.ToString();

                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应              
                worksheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, dgv.Columns.Count]);

                range.Font.ColorIndex = 1;//字体颜色 .ColorIndex = 11 1黑 2白 3红色 4 绿，5蓝 13紫 33深蓝;
                range.Interior.ColorIndex = 33;//背景颜色
                //range.NumberFormat = "yyyy-MM-dd hh:mm:ss";
                //range.Font.Size = 12;
                range.Font.Bold = true;
                range.RowHeight = 20;

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }
                }
                xlApp.Quit();
                GC.Collect();//强行销毁 
            }
            catch
            {
            }
            finally
            {
                SysBasicClass.WaitFormService.CloseWaitForm();
            }

            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ExportExcelFromDataGridView(string fileName, System.Data.DataTable dt)
        {
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消  
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel,无法使用导出功能");
                return;
            }
            SysBasicClass.WaitFormService.CreateWaitForm("导出数据等待中...");
            try
            {
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  
                Microsoft.Office.Interop.Excel.Range range;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[dt.Rows.Count + 1, dt.Columns.Count]);
                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                range.NumberFormat = "@";//防止部分数据类型或者以0开头的数字字符串会被EXCEL自动格式化掉，所有单元格先格式化为文本
                //写入标题  
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].Caption;
                    if (dt.Columns[i].DataType.ToString() == "System.DateTime")
                    {
                        range = worksheet.get_Range(worksheet.Cells[2, i + 1], worksheet.Cells[dt.Rows.Count + 1, i + 1]);
                        range.NumberFormat = "yyyy-MM-dd hh:mm:ss";//所有日期类型重新格式化
                    }
                }
                //写入数值  
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();

                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应              
                worksheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, dt.Columns.Count]);

                range.Font.ColorIndex = 1;//字体颜色 .ColorIndex = 11 1黑 2白 3红色 4 绿，5蓝 13紫 33深蓝;
                range.Interior.ColorIndex = 33;//背景颜色
                //range.NumberFormat = "yyyy-MM-dd hh:mm:ss";
                //range.Font.Size = 12;
                range.Font.Bold = true;
                range.RowHeight = 20;

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }
                }
                xlApp.Quit();
                GC.Collect();//强行销毁 
            }
            catch
            {
            }
            finally
            {
                SysBasicClass.WaitFormService.CloseWaitForm();
            }

            MessageBox.Show("文件： " + fileName + ".xls 保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static void KillProcess(string processName)//杀死与Excel相关的进程
        {
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();//得到所有打开的进程
            try
            {
                foreach (System.Diagnostics.Process thisproc in System.Diagnostics.Process.GetProcessesByName(processName))
                {
                    if (!thisproc.CloseMainWindow())
                    {
                        thisproc.Kill();
                    }
                }
            }
            catch (Exception Exc)
            {
                throw new Exception("", Exc);
            }
        }
    }
}
