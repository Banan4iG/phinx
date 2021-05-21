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
			this.StartPosition = FormStartPosition.CenterScreen;
		}
		
		private void Form1_Load(object sender, EventArgs e)
		{
			if(СheckConnection(conn))
			{
				MigView();
			}
			ComboBoxAddItems();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string pattern = @"(?=[A-Z])([A-Z][a-z])";
			RegexOptions option = RegexOptions.Multiline;
			string result = "";
			foreach (Match m in Regex.Matches(textBox1.Text, pattern, option))
			{
				result += m.Value;
			}
			if(result.Length != 2)
			{
				return;
			}

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
			textBox1.Text = "";
			if(checkBox1.Checked == true)
			{
				string[] listMig = Directory.GetFiles(@"E:\OpenServer\domains\localhost\phinx\migrations");
				int lastEl = listMig.Length;
				Process.Start(listMig[lastEl-1]);
			}
			Thread.Sleep(500);
			ComboBoxAddItems();
			MigView();

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
			Thread.Sleep(500);
			MigView();
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
			Thread.Sleep(500);
			MigView();
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

			//string pattern = @"(?=Status\s)([\s\S]+)(?=\r\n\r\n)";
			string pattern2 = @"(?<=--\s)([\s\S]+)(?=\r\n\r\n)";
			RegexOptions option = RegexOptions.Multiline;
			listView1.Items.Clear();
			string result = "";
			foreach (Match m in Regex.Matches(reads, pattern2, option))
			{
				result += m.Value;
			}
			string[] statusArr = result.Split('\n');
			for (int i=1; i<statusArr.Length; i++)
			{
				string[] strArr = statusArr[i].Split(' ');
				if(strArr.Length == 50)
				{
					listView1.Items.Add(strArr[3]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[5]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(" ");
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(" ");
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[49]);
				}
				else
				{
					listView1.Items.Add(strArr[5]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[7]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[9]+ strArr[10]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[12] + strArr[13]);
					listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[15]);
				}
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

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
