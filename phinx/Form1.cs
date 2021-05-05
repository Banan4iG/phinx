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
using System.Threading;
using System.Text.RegularExpressions;

namespace phinx
{
	public partial class Form1 : Form
	{
		MySqlConnection conn;

		string main_path = @"cd e:\OpenServer\domains\localhost\phinx\";
		string migrate = @"php vendor\robmorgan\phinx\bin\phinx migrate";
		string rollback = @"php vendor\robmorgan\phinx\bin\phinx rollback";
		string create = @"php vendor\robmorgan\phinx\bin\phinx create ";
		string status = @"php vendor\robmorgan\phinx\bin\phinx status";
		Dictionary<string, string> pathDictionary;

		public Form1()
		{
			conn = new MySqlConnection("server=127.0.0.1;userid=root;password=root;database=phinx_db;sslMode=none");
			InitializeComponent();
		}
		
		private void Form1_Load(object sender, EventArgs e)
		{
			if(СheckConnection(conn))
			{
				//MigView();
				
			}
			ComboBoxAddItems();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + create + textBox1.Text;
			p.StartInfo = startInfo;
			p.Start();
			p.Close();
			Thread.Sleep(500);
			if(checkBox1.Checked == true)
			{
				string[] listMig = Directory.GetFiles(@"E:\OpenServer\domains\localhost\phinx\migrations");
				int lastEl = listMig.Length;
				Process.Start(listMig[lastEl-1]);
			}
			ComboBoxAddItems();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + rollback + " & exit";
			p.StartInfo = startInfo;
			p.Start();
			p.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + migrate + " & exit";
			p.StartInfo = startInfo;
			p.Start();
			p.Close();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void проверитьПодключениеКБазеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				conn.Open();
				MessageBox.Show(this, "Подлючение есть!", "Проверка подлючения к базе данных");
			}
			catch
			{
				MessageBox.Show(this, "Подлючение отсутствует!", "Проверка подлючения к базе данных");
			}
			finally
			{
				conn.Close();
			}
		}

		private void открытьПапкуСМиграциямиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"E:\OpenServer\domains\localhost\phinx\migrations");

			/*
			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "explorer.exe";
			startInfo.Arguments = @"E:\OpenServer\domains\localhost\phinx\migrations";
			p.StartInfo = startInfo;
			p.Start();
			p.Close();
			*/
		}

		private void открытьКонфигурационныйФайлPhinxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"E:\OpenServer\domains\localhost\phinx\phinx.yml");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string selected = comboBox1.SelectedItem.ToString();
			Process.Start(@"E:\OpenServer\domains\localhost\phinx\migrations\" + pathDictionary[selected]);
		}

		private void MigView()
		{
			/*
			listView1.Items.Clear();
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
			}*/

			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + status + " & exit";
			p.StartInfo = startInfo;
			p.Start();
			StreamReader reader = p.StandardOutput;
			string reads = reader.ReadToEnd();
			p.Close();

			string pattern = @"(?=Status\s)([\s\S]+)(?=\r\n\r\n)";
			RegexOptions option = RegexOptions.Multiline;
			textBox3.Clear();
			string result = "";
			foreach (Match m in Regex.Matches(reads, pattern, option))
			{
				result += m.Value;
				textBox3.Text += result;
			}
		}

		private bool СheckConnection(MySqlConnection conn)
		{
			try
			{
				conn.Open();
				return true;
			}
			catch
			{
				MessageBox.Show(this, "Подлючение отсутствует!", "Проверка подлючения к базе данных");
				return false;
			}
			finally
			{
				conn.Close();
			}
		}

		private void ComboBoxAddItems()
		{
			comboBox1.Items.Clear();
			pathDictionary = new Dictionary<string, string>();
			string pathToMigrates = @"E:\OpenServer\domains\localhost\phinx\migrations";
			List<string> listFiles = (from a in Directory.GetFiles(pathToMigrates) select Path.GetFileName(a)).ToList();
			foreach(var path in listFiles)
			{
				string[] splitedName = path.Split('_');
				string dictionaryKey = "";
				for (int i = 1; i < splitedName.Length; i++)
				{
					dictionaryKey += splitedName[i].ToUpper()[0] + splitedName[i].Substring(1);
				}
				string trimedDictionaryKey = dictionaryKey.Remove(dictionaryKey.Length - 4);
				pathDictionary.Add(trimedDictionaryKey, path);
				comboBox1.Items.Add(trimedDictionaryKey);
			}
		}
	}
}
