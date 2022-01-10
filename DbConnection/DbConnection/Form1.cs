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

namespace DbConnection
{
    public partial class Form1 : Form
    {
        const string connstr = " Data Source =DESKTOP-EBLF17S;Initial Catalog =AgenziaImmobiliare;Integrated Security=True";
//        const string connstr = "Data Source=AULA1D-08\\MSSQLSERVERNEW;Initial Catalog=Prova;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connstr);
        SqlDataAdapter adapt;
        DataTable dt;
        SqlCommand cmd;
        SqlCommandBuilder cb;
      

        public Form1()
        {
            InitializeComponent();
           //showdata();
        }



        private void btnInvia_Click(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection(connstr);
                conn.ConnectionString = connstr;
                conn.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "insert into proprietari(CF, nome, cognome, telefono) values(@CF, @nome, @cognome, @telefono)";
                //cmd.Parameters.AddWithValue("@id", textBox5.Text);
                cmd.Parameters.AddWithValue("@CF", textBox1.Text);
                cmd.Parameters.AddWithValue("@Nome", textBox2.Text);
                cmd.Parameters.AddWithValue("@Cognome", textBox3.Text);
                cmd.Parameters.AddWithValue("@Telefono", textBox4.Text);

                cmd.Connection = conn;
                int i = cmd.ExecuteNonQuery();
                if (i != null)
                {
                    MessageBox.Show("Proprietario inserito con successo!");
                }
                
                cmd.Dispose();
                conn.Close();
           

            //showdata();






        }
        //    public void showdata()
        //{

        //    adapt = new SqlDataAdapter("select * from Proprietari", conn);
        //    dt = new DataTable();
        //    adapt.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    conn.Close();
        //}
        private void btnElimina_Click(object sender, EventArgs e)
        {
            
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                int id_to_remove = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

                //cancelliamo sul DB
                SqlConnection conn = new SqlConnection(connstr);
                conn.ConnectionString = connstr;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from proprietari where id=@id";
                cmd.Parameters.Add("@id", id_to_remove);
                int i = cmd.ExecuteNonQuery();
                if (i != null)
            {
                MessageBox.Show("Proprietario eliminato");
            }




                dataGridView1.Rows.RemoveAt(rowIndex);
                //if (this.dataGridView1.SelectedRows.Count > 0)
                //{
                //    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                //}
                
                cmd.Dispose();
                conn.Close();
           

        }



        private void btnModifica_Click(object sender, EventArgs e)
        {

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int id_to_update = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            SqlConnection conn = new SqlConnection(connstr);
            //DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("UPDATE Proprietari set CF = @CF, nome = @nome, cognome = @cognome, telefono = @telefono where id = @id", conn);

            cmd.Connection = conn;
            //cmd.CommandText = "UPDATE Proprietari set CF = @CF, nome = @nome, cognome = @cognome, telefono = @telefono";

            cmd.Parameters.AddWithValue("@CF", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nome", textBox2.Text);
            cmd.Parameters.AddWithValue("@Cognome", textBox3.Text);
            cmd.Parameters.AddWithValue("@Telefono", textBox4.Text);
            cmd.Parameters.AddWithValue("@id", id_to_update);

            conn.Open();

            //cmd.Parameters.Add("@id", id_to_update);


            int i = cmd.ExecuteNonQuery();
            if (i != null)
            {
                MessageBox.Show("Proprietario modificato");
            }
            cmd.Dispose();
            conn.Close();

            btnMostraTab_Click(null, null);
        }

        private void btnMostraTab_Click(object sender, EventArgs e)
        {
            adapt = new SqlDataAdapter("select * from Proprietari", conn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = (string)dataGridView1.Rows[rowIndex].Cells[1].Value;
            textBox2.Text = (string)dataGridView1.Rows[rowIndex].Cells[2].Value;
            textBox3.Text = (string)dataGridView1.Rows[rowIndex].Cells[3].Value;
            textBox4.Text = (string)dataGridView1.Rows[rowIndex].Cells[4].Value;
        }
    }

}

