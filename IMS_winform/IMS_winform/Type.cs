using IMS_winform.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS_winform
{
    public partial class Type : Form
    {
        public Type()
        {
            InitializeComponent();
        }

        private void Type_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True";

            string sqlCmd = "SELECT * FROM [dbo].[Type] ";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, conn);


            DataSet types = new DataSet();

            sqlDataAdapter.Fill(types, "Type");

            dataGridView1.DataSource = types.Tables[0];

            conn.Close();

        }


        private void newBtn_Click(object sender, EventArgs e)
        {
            var typeNew = new TypeNew();
            var dialogResult = typeNew.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
            {
                MessageBox.Show(@"User clicked cancel!");
            }
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show(@"New Type created!");
            }
            FormReLoad();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            TypeRepository typeRepo = new TypeRepository();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
               
                int typeId = (int)row.Cells["Id"].Value;

                typeRepo.Delete(typeId);

                MessageBox.Show("Selected rows Deleted!");

            }

            FormReLoad();

        }
        private void FormReLoad()
        {
            dataGridView1.AutoGenerateColumns = true;
            string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True";

            string sqlCmd = "SELECT * FROM [dbo].[Type] ";
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
          
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd, conn);

            DataSet types = new DataSet();

            sqlDataAdapter.Fill(types, "Type");

            dataGridView1.DataSource = types.Tables[0];

            conn.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
               if(String.IsNullOrEmpty(row.Cells["Id"].Value.ToString()))
                {
                    continue;
                }
                int typeId = (int)row.Cells["Id"].Value;
           
                string connectionString = "Server=NAN-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True;";

                SqlConnection conn = new SqlConnection(connectionString);

                conn.Open();

                string cmdText = "UPDATE [IMS].[dbo].[Type] SET Name = @name, Description = @description  WHERE Id = @Id ;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Id", typeId);
                cmd.Parameters.AddWithValue("@name", row.Cells["Name"].Value.ToString());
                cmd.Parameters.AddWithValue("@description", row.Cells["Description"].Value.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Changes Saved!");

            }
            FormReLoad();
        }

    }
}
