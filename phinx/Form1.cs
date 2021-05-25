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
		string seed_create = @"php vendor\robmorgan\phinx\bin\phinx seed:create ";
		string seed_run = @"php vendor\robmorgan\phinx\bin\phinx seed:run";

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
			ComboBoxAddSeeds();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string pattern = @"^(!?[A-Z])";
			RegexOptions option = RegexOptions.Multiline;
			string result = "";
			int length = 0;
			foreach (Match m in Regex.Matches(textBox1.Text, pattern, option))
			{
				length += m.Length;
			}
			if(length == 1)
			{
				string pattern1 = @"([A-Z])";
				foreach (Match m in Regex.Matches(textBox1.Text, pattern1, option))
				{
					result += m.Value;
				}
				if (result.Length != 2)
				{
					MessageBox.Show("Название миграции должно быть в стиле CamelCase");
					return;
				}
			}
			else
			{
				MessageBox.Show("Название миграции должно быть в стиле CamelCase");
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
			StreamReader reader = p.StandardOutput;
			string reads = reader.ReadToEnd();
			p.Close();
			if (reads.Contains("All Done."))
			{
				MessageBox.Show(this, "Миграции успешно применены");
			}
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
			if (result != "")
			{
				string[] statusArr = result.Split('\n');
				for (int i = 1; i < statusArr.Length; i++)
				{
					string[] strArr = statusArr[i].Split(' ');
					if (strArr.Length == 50)
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
						listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[9] + strArr[10]);
						listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[12] + strArr[13]);
						listView1.Items[listView1.Items.Count - 1].SubItems.Add(strArr[15]);
					}
				}
			}
			else
			{
				string pattern3 = @"(?=Parse\s)([\s\S]+)(?=\n)";
				//string pattern4 = @"(?<=\s)([\s\S]+)(?=\n)"
				RegexOptions option2 = RegexOptions.Multiline;
				string result2 = "";
				foreach (Match m in Regex.Matches(reads, pattern3, option2))
				{
					result2 += m.Value;
				}
				MessageBox.Show("Отображение списка миграций недостпуно из-за ошибки." + '\n' + '\n' + result2 + '\n' + '\n' + "Исправте ошибку в миграции (см. сообщение об ошибке)", "Ошибка в тексте миграции");
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
			foreach(var fileName in listFiles)
			{
				string[] splitedName = fileName.Split('_');
				string dictionaryKey = "";
				for (int i = 1; i < splitedName.Length; i++)
				{
					dictionaryKey += splitedName[i].ToUpper()[0] + splitedName[i].Substring(1);
				}
				string trimedDictionaryKey = dictionaryKey.Remove(dictionaryKey.Length - 4);
				pathDictionary.Add(trimedDictionaryKey, fileName);
				comboBox1.Items.Add(trimedDictionaryKey);
			}
		}

		private void ComboBoxAddSeeds()
		{
			comboBox2.Items.Clear();
			string pathToSeeds = @"E:\OpenServer\domains\localhost\phinx\seeds";
			List<string> listFiles = (from a in Directory.GetFiles(pathToSeeds) select Path.GetFileName(a)).ToList();
			foreach (var fileName in listFiles)
			{
				string trimedFileName = fileName.Remove(fileName.Length - 4);
				comboBox2.Items.Add(trimedFileName);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{
			string pattern = @"^(!?[A-Z])";
			RegexOptions option = RegexOptions.Multiline;
			string result = "";
			int length = 0;
			foreach (Match m in Regex.Matches(textBox2.Text, pattern, option))
			{
				length += m.Length;
			}
			if (length == 1)
			{
				string pattern1 = @"([A-Z])";
				foreach (Match m in Regex.Matches(textBox2.Text, pattern1, option))
				{
					result += m.Value;
				}
				if (result.Length != 2)
				{
					MessageBox.Show("Название должно быть в стиле CamelCase.");
					return;
				}
			}
			else
			{
				MessageBox.Show("Название должно быть в стиле CamelCase.");
				return;
			}

			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + seed_create + textBox2.Text;
			p.StartInfo = startInfo;
			p.Start();
			p.Close();
			Thread.Sleep(500);
			textBox2.Text = "";
			if (checkBox2.Checked == true)
			{
				string[] listSeeds = Directory.GetFiles(@"E:\OpenServer\domains\localhost\phinx\seeds");
				int lastEl = listSeeds.Length;
				Process.Start(listSeeds[lastEl - 1]);
			}
			Thread.Sleep(500);
			ComboBoxAddSeeds();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + seed_run + " & exit";
			p.StartInfo = startInfo;
			p.Start();
			StreamReader reader = p.StandardOutput;
			string reads = reader.ReadToEnd();
			p.Close();
			Thread.Sleep(500);
			if (reads.Contains("All Done."))
			{
				MessageBox.Show(this, "Посев данных успешно выполнен.");
			}
			else
			{
				string pattern = @"(?=Parse\s)([\s\S]+)(?=\n)";
				RegexOptions option = RegexOptions.Multiline;
				string result = "";
				foreach (Match m in Regex.Matches(reads, pattern, option))
				{
					result += m.Value;
				}
				MessageBox.Show("Посев данных не был выполнен." + '\n' + '\n' + result + '\n' + '\n' + "Исправте ошибку в посеве (см. сообщение об ошибке)", "Ошибка в тексте посева");
			}

		}

		private void button8_Click(object sender, EventArgs e)
		{
			string selected = comboBox2.SelectedItem.ToString();
			Process p = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.UseShellExecute = false;
			startInfo.RedirectStandardOutput = true;
			startInfo.FileName = "CMD.exe";
			startInfo.Arguments = "/C " + main_path + " & " + seed_run + " -s " + selected +" & exit";
			p.StartInfo = startInfo;
			p.Start();
			StreamReader reader = p.StandardOutput;
			string reads = reader.ReadToEnd();
			p.Close();
			Thread.Sleep(500);
			if (reads.Contains("All Done."))
			{
				MessageBox.Show(this, "Посев данных "+ selected +" успешно выполнен.");
			}
			else
			{
				string pattern = @"(?=Parse\s)([\s\S]+)(?=\n)";
				RegexOptions option = RegexOptions.Multiline;
				string result = "";
				foreach (Match m in Regex.Matches(reads, pattern, option))
				{
					result += m.Value;
				}
				MessageBox.Show("Посев данных "+ selected + " не был выполнен." + '\n' + '\n' + result + '\n' + '\n' + "Исправте ошибку в посеве (см. сообщение об ошибке)", "Ошибка в тексте посева");
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			string selected = comboBox2.SelectedItem.ToString();
			Process.Start(@"E:\OpenServer\domains\localhost\phinx\seeds\" + selected + ".php");
		}

		private void открытьПапкуСПосевамиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(@"E:\OpenServer\domains\localhost\phinx\seeds");
		}
	}
}
