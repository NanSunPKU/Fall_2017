using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_winform.Repository
{
    class TypeRepository
    {
        public void Create()
        {

        }
        public void Update()
        {

        }
        public void Delete(int Id)
        {
            string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string cmdText = "DELETE FROM [IMS].[dbo].[Type] WHERE Id = @Id ;";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@Id", Id);

            cmd.ExecuteNonQuery();

            conn.Close();



        }
        //public void Select()
        //{

        //}
    }
}

