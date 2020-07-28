using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesAndMarketingForms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                FileUpload1.PostedFile
                    .SaveAs(Server.MapPath("~/Data/") + fileName);




                FileInfo existingFile = new FileInfo(Server.MapPath("~/Data/") + fileName);
                ExcelPackage.LicenseContext = LicenseContext.Commercial;

                using (ExcelPackage package = new ExcelPackage(existingFile))
                {

                    try
                    {
                        //get the first worksheet in the workbook
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

                        int rowCount = worksheet.Dimension.End.Row;     //get row count

                        int planId = -1;

                        if (Int32.TryParse(worksheet.Cells["B1"].Text, out int j))
                            planId = j;

                        //get the plan name
                        var mergedId = worksheet.MergedCells[0];
                        string planName = worksheet.Cells[mergedId].First().Value.ToString();

                        //Get data from the XLSX sheet
                        //var dt = XlsDataExtractor.GetDataTableFromExcel(worksheet,1,2,10,13,4 , rowCount);

                        var datCols = new List<Tuple<int, int>>();

                        datCols.Add(new Tuple<int, int>(10, 13));
                        datCols.Add(new Tuple<int, int>(15, 15));
                        datCols.Add(new Tuple<int, int>(21, 22));
                        datCols.Add(new Tuple<int, int>(25, 25));


                        var dt = XlsDataExtractor.GetDataTableFromExcel(worksheet, 1, 2, datCols, 4, rowCount);

                        //Update DB plan with the data
                        var dbUpdate = UpdateDBJDPlan(planId,planName ,dt);

                        Label1.Text = String.Format("Plan {0} was updated suuccessfully. {1} rows updated", planId, dbUpdate.Item1);

                    }

                    catch (Exception ex)
                    {
                        Label1.Text = ex.Message;
                    }
                }
            }
        }


        private Tuple<int,  string> UpdateDBJDPlan(int planId, string planName,  DataTable dt)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("[JD].[UpdatePlanData_SP]", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@PlanId", planId));
                        cmd.Parameters.Add(new SqlParameter("@PlanName", planName));
                        cmd.Parameters.Add(new SqlParameter("@JD_Data", dt));
                        cmd.Parameters.Add(new SqlParameter("@User", System.Web.HttpContext.Current.User.Identity.Name));
                        
                     

                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        var affected = cmd.ExecuteNonQuery();

                      

                        return new Tuple<int,string> (affected, "Completed Successfully");

                    }


                }
            }
            catch (Exception e)
            {
                return new Tuple<int,  string>(-1, e.Message);

            }



        }

    }
}
