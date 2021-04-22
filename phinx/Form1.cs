using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.SqlClient;

namespace phinx
{
	public partial class Form1 : Form
	{
		MySqlConnection conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=phinx_db;sslMode=none");
		public Form1()
		{
			InitializeComponent();
			MigView();
		}
		string main_path = @"cd e:\OpenServer\domains\localhost\phinx\";
		string migrate = @"php vendor\robmorgan\phinx\bin\phinx migrate";
		string rollback = @"php vendor\robmorgan\phinx\bin\phinx rollback";
		string create = @"php vendor\robmorgan\phinx\bin\phinx create";
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				conn.Open();

				MySqlDataAdapter SDA = new MySqlDataAdapter("SELECT version, migration_name FROM phinxlog", conn);
				DataTable DATA = new DataTable();
				SDA.Fill(DATA);
				//dataGridView1.DataSource = DATA;
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

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			Process.Start("CMD.exe", "/K " + main_path + " & " + rollback);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Process.Start("CMD.exe", "/K " + main_path + " & " + migrate);
		}

		private void MigView()
		{
			string pathToMigrates = @"E:\OpenServer\domains\localhost\phinx\migrations";
			List<string> listfiles = (from a in Directory.GetFiles(pathToMigrates) select Path.GetFileName(a)).ToList();
			List<string> numberMigFromDir = new List<string>();
			List<string> numberMigFromTable = new List<string>();
			foreach (var el in listfiles)
			{
				string[] splitstr = el.Split('_');
				numberMigFromDir.Add(splitstr[0]);
 			}
			conn.Open();
			MySqlCommand command = new MySqlCommand("SELECT version FROM phinxlog", conn);
			MySqlDataReader reader = command.ExecuteReader();
			while(reader.Read())
			{
				numberMigFromTable.Add(reader[0].ToString());
			}
			numberMigFromDir.Sort();
			numberMigFromTable.Sort();
			conn.Close();
			for (int i = 0; i < numberMigFromDir.Count; i++)
			{
				try
				{
					if(numberMigFromDir[i] == numberMigFromTable[i])
					{
						conn.Open();
						string sql = "SELECT migration_name FROM phinxlog WHERE version=" + numberMigFromTable[i];
						MySqlCommand command1 = new MySqlCommand(sql, conn);
						MySqlDataReader reader1 = command1.ExecuteReader();
						while (reader1.Read())
						{
							string name = reader1[0].ToString();
							listView1.Items.Add(name);
							listView1.Items[listView1.Items.Count - 1].SubItems.Add("Done");
						}
						conn.Close();
					}
				}
				catch
				{
					//MySqlCommand command1 = new MySqlCommand("SELECT migration_name FROM phinxlog WHERE version='" + numberMigFromTable + "'", conn);
					//MySqlDataReader reader1 = command.ExecuteReader();
					//string name = reader[0].ToString();
					listView1.Items.Add("№" + numberMigFromDir[i]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add("None");
				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
