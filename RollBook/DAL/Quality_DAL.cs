using RollBook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RollBook.DAL
{
    public class Quality_DAL : Controller
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        // GET: Quality_DAL
        public ActionResult Index()
        {
            return View();
        }

        public List<QualityMaster> GetQuality()
        {
            List<QualityMaster> QualityList = new List<QualityMaster>();
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[QualityMaster_SelectAll]";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtQuality = new DataTable();

                connection.Open();
                id = command.ExecuteNonQuery();
                sqlDA.Fill(dtQuality);
                connection.Close();

                foreach (DataRow dr in dtQuality.Rows)
                {
                    QualityList.Add(new QualityMaster
                    {
                        QualityID = Convert.ToInt32(dr["QualityID"]),
                        QualityName = dr["QualityName"].ToString(),
                    });
                }
                return QualityList;
            }
        }

        public bool SaveData(QualityMaster Quality)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "QualityMaster_Insert_Update";
                command.Parameters.AddWithValue("@QualityName", Quality.QualityName);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}