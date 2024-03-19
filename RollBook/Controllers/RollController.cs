using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using RollBook.DAL;
using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollBook.Controllers
{
    public class RollController : Controller
    {

        Roll_DAL _RollDAL = new Roll_DAL();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        // GET: Student
        public ActionResult Index()
        {
            List<QualityMaster> lstRoll = _RollDAL.GetAllQuality();
            ViewBag.lstRoll = lstRoll;

            List<LoomMaster> lstLoom = _RollDAL.GetAllLoom();
            ViewBag.lstLoom = lstLoom;

            List<SizeMaster> lstSize = _RollDAL.GetAllSize();
            ViewBag.lstSize = lstSize;

            List<RollMaster> lstDNR = _RollDAL.GetAllDNR();
            ViewBag.lstDNR = lstDNR;

            return View();
        }

        [HttpPost]
        public JsonResult GetData(int QualityID,string DNR, DateTime FromDate,DateTime ToDate)
        {
            try
            {
                List<RollMaster> lstFilterRoll = _RollDAL.GetAllRoll(QualityID, DNR, FromDate, ToDate);
                HttpContext.Cache["RoollBookReport"] = Newtonsoft.Json.JsonConvert.SerializeObject(lstFilterRoll);

                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(lstFilterRoll), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Save(RollMaster Roll)
        {
            try
            {
                Boolean mres = _RollDAL.RollInsertUpdate(Roll);
                return Json("Successful...!!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Get(int RollID)
        {
            List<RollMaster> RollList = new List<RollMaster>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "RollMaster_SelectByPK";
                    command.Parameters.AddWithValue("@RollID", RollID);
                    SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                    DataTable dtRoll = new DataTable();

                    connection.Open();
                    sqlDA.Fill(dtRoll);
                    connection.Close();

                    foreach (DataRow dr in dtRoll.Rows)
                    {
                        RollList.Add(new RollMaster
                        {
                            RollID = Convert.ToInt32(dr["RollID"]),
                            QualityID = Convert.ToInt32(dr["QualityID"]),
                            LoomID = Convert.ToInt32(dr["LoomID"]),
                            OpMtr = dr["OpMtr"].ToString(),
                            RollNo = dr["RollNo"].ToString(),
                            CbMtr = dr["CbMtr"].ToString(),
                            DNR = dr["DNR"].ToString(),
                            NW = dr["NW"].ToString(),
                            QW = dr["QW"].ToString(),
                            TW = dr["TW"].ToString(),
                            SizeID = Convert.ToInt32(dr["SizeID"])
                        });

                    }
                }

                return Json(Newtonsoft.Json.JsonConvert.SerializeObject(RollList), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(string RollID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeactiveRecords_Insert";

                    command.Parameters.AddWithValue("@RollID", RollID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return Json("Successful Deleted...!!!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Error :" + ex.Message, JsonRequestBehavior.AllowGet);
            }

        }

        public FileResult ExportToExcel()
        {
            try
            {
                object data = HttpContext.Cache["RoollBookReport"];

                List<RollMaster> lst = new List<RollMaster>();

                if (data != null)
                {
                    lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RollMaster>>(data.ToString());
                }
                var excelFile = ExportEmployeeReport(lst);

                string FileName = "RollReport.xls";

                return File(excelFile, "application/vnd.ms-excel", FileName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] ExportEmployeeReport(List<RollMaster> lst)
        {
            if (lst.Count > 0)
            {
                string SheetName = "Employee Report";

                // Declare HSSFWorkbook object for create sheet
                var workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet(SheetName);

                // Set column name this column name use for fetch data from list
                List<string> headers = new List<string>
                {
                    "SrNo.",
                    "Quality",
                    "Loom No",
                    "Roll No",
                    "Size",
                    "D.N.R",
                    "O.P.Mtr",
                    "C.B.Mtr",
                    "Total Mtr",
                    "Q.W",
                    "T.W",
                    "N.W",
                    "AVR",
                };

                HSSFFont BodyFont = (HSSFFont)workbook.CreateFont();
                BodyFont.FontHeightInPoints = 11;
                BodyFont.FontName = "Calibri";

                HSSFCellStyle BodyStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                BodyStyle.SetFont(BodyFont);

                var headerRow = sheet.CreateRow(0);

                //Below loop is create header
                for (int i = 0; i < headers.Count; i++)
                {
                    var cell = headerRow.CreateCell(i);
                    cell.SetCellValue(headers[i]);
                    cell.CellStyle = BodyStyle;
                }

                //Below loop is fill content
                for (int i = 0; i < lst.Count; i++)
                {
                    var rowIndex = i + 1;
                    var row = sheet.CreateRow(rowIndex);

                    var SrNo = row.CreateCell(0);
                    var Quality = row.CreateCell(1);
                    var LoomNo = row.CreateCell(2);
                    var RollNo = row.CreateCell(3);
                    var Size = row.CreateCell(4);
                    var DNR = row.CreateCell(5);
                    var OpMtr = row.CreateCell(6);
                    var CbMtr = row.CreateCell(7);
                    var TotalMtr = row.CreateCell(8);
                    var QW = row.CreateCell(9);
                    var TW = row.CreateCell(10);
                    var NW = row.CreateCell(11);
                    var AVR = row.CreateCell(12);

                    SrNo.SetCellValue(i + 1);
                    Quality.SetCellValue(lst[i].QualityName);
                    LoomNo.SetCellValue(lst[i].LoomNo);
                    RollNo.SetCellValue(lst[i].RollNo);
                    Size.SetCellValue(lst[i].Size);
                    DNR.SetCellValue(lst[i].DNR);
                    OpMtr.SetCellValue(lst[i].OpMtr);
                    CbMtr.SetCellValue(lst[i].CbMtr);
                    TotalMtr.SetCellValue(Convert.ToInt32(lst[i].OpMtr) - Convert.ToInt32(lst[i].CbMtr));
                    QW.SetCellValue(lst[i].QW);
                    TW.SetCellValue(lst[i].TW);
                    NW.SetCellValue(lst[i].NW);
                    AVR.SetCellValue(Convert.ToDouble(lst[i].NW) / (Convert.ToDouble(lst[i].OpMtr) - Convert.ToDouble(lst[i].CbMtr)) * 1000);//NEED TO SAVE

                    SrNo.CellStyle = Quality.CellStyle = LoomNo.CellStyle = RollNo.CellStyle = Size.CellStyle = DNR.CellStyle = OpMtr.CellStyle = CbMtr.CellStyle = TotalMtr.CellStyle = QW.CellStyle = TW.CellStyle = NW.CellStyle = AVR.CellStyle = BodyStyle;

                    sheet.AutoSizeColumn(i);
                }
                double sumNW = 0;
                foreach (var item in lst)
                {
                    if (!string.IsNullOrEmpty(item.NW))
                    {
                        // Try parsing the NW value to an integer
                        if (double.TryParse(item.NW, out double nwValue))
                        {
                            // If parsing is successful, add it to the sum
                            sumNW += nwValue;
                        }
                        else
                        {
                            // Handle cases where NW value is not a valid double
                            // You can choose to skip, log, or handle it differently based on your requirements
                            Console.WriteLine($"Invalid NW value: {item.NW}");
                        }
                    }
                }
                var borderStyle = workbook.CreateCellStyle();

                // Create a new row at index lst.Count + 1
                var sumRow = sheet.CreateRow(lst.Count + 1);

                // Create a cell in column L (index 11) of the new row
                var sumCell = sumRow.CreateCell(11);

                // Set the value of the cell to the calculated sumNW
                sumCell.SetCellValue(sumNW);

                // Optionally, apply any formatting or styling to the cell if needed
                // For example, if you want to apply the same body style as other cells:
                sumCell.CellStyle = BodyStyle;

                // Autosize the column to fit the content
                sheet.AutoSizeColumn(11); // Column L

                borderStyle.CloneStyleFrom(BodyStyle); // Clone the body style to inherit its properties
                borderStyle.BorderTop = BorderStyle.Thin;
                borderStyle.BorderBottom = BorderStyle.Thin;
                borderStyle.BorderLeft = BorderStyle.Thin;
                borderStyle.BorderRight = BorderStyle.Thin;

                // Iterate through each row in the table
                for (int i = 0; i <= lst.Count + 1; i++) // Include the header row and data rows
                {
                    var row = sheet.GetRow(i) ?? sheet.CreateRow(i); // Get the current row or create a new one if it doesn't exist

                    // Iterate through each cell in the current row
                    for (int j = 0; j < headers.Count; j++) // Assuming headers.Count represents the number of columns
                    {
                        var cell = row.GetCell(j) ?? row.CreateCell(j); // Get the current cell or create a new one if it doesn't exist

                        // Apply the border style to the cell
                        cell.CellStyle = borderStyle;
                    }
                }
                int rowToMerge = lst.Count + 1;
                // Define the range of cells to be merged
                CellRangeAddress mergedRegion = new CellRangeAddress(rowToMerge, rowToMerge, 0, 9); // Columns A to K (0 to 10)

                // Add the merged region to the sheet
                sheet.AddMergedRegion(mergedRegion);
                for (int rowIndex = mergedRegion.FirstRow; rowIndex <= mergedRegion.LastRow; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);
                    if (row != null)
                    {
                        for (int columnIndex = mergedRegion.FirstColumn; columnIndex <= mergedRegion.LastColumn; columnIndex++)
                        {
                            var cell = row.GetCell(columnIndex);
                            if (cell == null)
                            {
                                cell = row.CreateCell(columnIndex);
                            }

                            // Apply the border style to the cell
                            cell.CellStyle = borderStyle;
                        }
                    }
                }
                var totalCell = sumRow.CreateCell(10); // Column K (10th index)

                // Set the value of the total cell
                totalCell.SetCellValue($"Total:");

                // Autosize the column to fit the content
                sheet.AutoSizeColumn(10);
                totalCell.CellStyle = borderStyle;
                // Declare one MemoryStream variable for write file in stream
                var stream = new MemoryStream();
                workbook.Write(stream);

                return stream.ToArray();
            }

            return null;
        }
    }
}