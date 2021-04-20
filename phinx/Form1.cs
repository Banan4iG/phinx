using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace phinx
{
	public partial class Form1 : Form
	{
		MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=phinx_db;sslMode=none");
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				conn.Open();

				MySqlDataAdapter SDA = new MySqlDataAdapter("SELECT * FROM phinxlog", conn);
				DataTable DATA = new DataTable();
				SDA.Fill(DATA);
				dataGridView1.DataSource = DATA;
				conn.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				conn.Close();
			}
		}
	}
}
