using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace SalesAndMarketingForms
{
    public static class XlsDataExtractor
    {
        public static DataTable GetDataTableFromExcel(ExcelWorksheet worksheet
                                                    , int dimStartCol
                                                    , int dimEndCol
                                                    , List<Tuple <int,int>> dataCols
                                                    , int dataStartRow
                                                    , int dataEndRow)
        {
            var tbl = new DataTable("JDValues");



            //add columns for both headers and data

            for (int col = 0; col <= (dimEndCol - dimStartCol) ; col++)
            {
                tbl.Columns.Add();

            }

            foreach (var dc in dataCols)
            {
                for (int col = 0; col <= (dc.Item2 - dc.Item1) ; col++)
                {
                    tbl.Columns.Add();

                }
            }
            

            for (int rowNum = dataStartRow; rowNum <= dataEndRow; rowNum++)
            {

                DataRow row = tbl.Rows.Add();
                //Header columns
                var wsDimRow = worksheet.Cells[rowNum, dimStartCol, rowNum, dimEndCol];
                

                //loop headers cells
                int cellId = dimStartCol - 1;
                foreach (var cell in wsDimRow)
                {
                    row[cellId] = cell.Text;
                    cellId++;
                }

                cellId = dimEndCol;

                //Data Columns
                foreach (var dc in dataCols)
                {
                    
                    var wsRow = worksheet.Cells[rowNum, dc.Item1, rowNum, dc.Item2];



                    //loop data cells
                    
                    foreach (var cell in wsRow)
                    {
                        row[cellId] = cell.Text;
                        cellId++;
                    }
                }



            }

            return tbl;
        }


        public static DataTable GetDataTableFromExcel(ExcelWorksheet worksheet
                                                  , int dimStartCol
                                                  , int dimEndCol
                                                  , int dataStartCol
                                                  , int dataEndCol
                                                  , int dataStartRow
                                                  , int dataEndRow)
        {
            var tbl = new DataTable("JDValues");

            //add columns for both headers and data
            for (int col = 0; col <= (dataEndCol - dataStartCol) + (dimEndCol - dimStartCol) + 1; col++)
            {
                tbl.Columns.Add();

            }

            for (int rowNum = dataStartRow; rowNum <= dataEndRow; rowNum++)
            {


                //Header columns
                var wsDimRow = worksheet.Cells[rowNum, dimStartCol, rowNum, dimEndCol];

                //DataColumns
                var wsRow = worksheet.Cells[rowNum, dataStartCol, rowNum, dataEndCol];

                DataRow row = tbl.Rows.Add();

                //loop headers cells
                int cellId = dimStartCol - 1;
                foreach (var cell in wsDimRow)
                {
                    row[cellId] = cell.Text;
                    cellId++;
                }

                //loop data cells
                cellId = dimEndCol;
                foreach (var cell in wsRow)
                {
                    row[cellId] = cell.Text;
                    cellId++;
                }



            }

            return tbl;
        }
    }

}

