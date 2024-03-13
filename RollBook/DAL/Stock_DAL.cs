using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RollBook.DAL
{
    public class Stock_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public List<StockMaster> GetStock()
        {
            List<StockMaster> StockList = new List<StockMaster>();
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "StockDetails";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtStock = new DataTable();

                connection.Open();
                id = command.ExecuteNonQuery();
                sqlDA.Fill(dtStock);
                connection.Close();

                foreach (DataRow dr in dtStock.Rows)
                {
                    StockList.Add(new StockMaster
                    {
                        Size = dr["Size"].ToString(),
                        DNR = dr["DNR"].ToString(),
                        QualityName = dr["QualityName"].ToString(),
                        Quantity = Convert.ToInt32(dr["Quantity"]),
                        LoomNo = Convert.ToInt32(dr["LoomNo"]),

                    });
                }
                return StockList;
            }
        }
    }
}