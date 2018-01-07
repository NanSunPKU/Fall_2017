﻿using System;
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
            string connectionString = "Server=Nan-PC\\MSSQLSERVER01;Database=IMS;Integrated Security=True";

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //selected row--to see which row user has picked to delete
                 foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    //read the row Id
                    int rowIndex = row["Id"].Index;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                                  
                    //delete the row with this Id from Database
                   // row..Delete(row["Id"]);

                }
        }
    }

}