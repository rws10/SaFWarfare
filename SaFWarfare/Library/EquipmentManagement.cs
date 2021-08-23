using Microsoft.Data.SqlClient;
using SaFWarfare.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SaFWarfare.Library
{
    public class EquipmentManagement
    {
        /// <summary>
        /// Common objects used throughout the class
        /// </summary>
        SqlConnection objConnection;
        SqlCommand objCommand;
        Models.Equipment workObject;

        public string ConnectionString
        {
            set
            {
                objConnection.ConnectionString = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EquipmentManagement()
        {
            objConnection = new SqlConnection();
            objCommand = new SqlCommand("", objConnection);
            workObject = new Models.Equipment();
        }

        ~EquipmentManagement()
        {
            if (objCommand != null)
            {
                try
                {
                    objCommand.Dispose();
                    objConnection.Dispose();
                }
                catch
                {
                    //Nothing to dispose of
                }
            }
            workObject = null;
        }

        internal List<Equipment> GetAllEquipment()
        {
            List<Models.Equipment> objItems = new List<Equipment>();
            objCommand.Parameters.Clear();
            objCommand.CommandText = "usp_ListWorkRequestById";
            objCommand.CommandType = CommandType.StoredProcedure;
            //try
            //{
                fixConnectionState();
                SqlDataReader dr = objCommand.ExecuteReader();
                while (dr.Read())
                {
                    Models.Equipment item = new Equipment();
                    item.equID = dr.GetInt32(dr.GetOrdinal("equID"));
                    item.equAttack = dr.GetInt32(dr.GetOrdinal("equAttack"));
                    item.equDefense = dr.GetInt32(dr.GetOrdinal("equDefense"));
                    item.equMorale = dr.GetInt32(dr.GetOrdinal("equMorale"));
                    item.equName = dr.IsDBNull(dr.GetOrdinal("equName")) ? "" : dr.GetString(dr.GetOrdinal("equName"));
                    item.equPower = dr.GetInt32(dr.GetOrdinal("equPower"));
                    item.equToughness = dr.GetInt32(dr.GetOrdinal("equToughness"));

                    objItems.Add(item);


                }
                dr.Close();
            //}

            //catch (Exception ex)
            //{
            //    // Capture one of the possible problem objects and send it, the userName of the individual
            //    // using the site when the exception occured, and  the exception to the error log with a message
            //    string obj = new JavaScriptSerializer().Serialize(objItems);
            //    Models.ExceptionLogging.SendExcepToDB(ex, userName, obj);
            //}
            //finally
            //{
            //    // Close the connection
            //    objConnection.Close();
            //}

            return objItems;
        }

        private void fixConnectionState()
        {
            switch (objConnection.State)
            {
                case ConnectionState.Broken:
                    objConnection.Close();
                    objConnection.Open();
                    break;
                case ConnectionState.Closed:
                    objConnection.Open();
                    break;
            }
            return;
        }
    }
}
