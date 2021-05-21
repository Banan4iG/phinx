namespace phinx
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button4 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.опцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.проверитьПодключениеКБазеДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьПапкуСМиграциямиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьКонфигурационныйФайлPhinxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(6, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(233, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(459, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Создать миграцию";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 218);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Применить";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(87, 218);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Text = "Откатить";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listView1);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(583, 288);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Миграции";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(6, 46);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(571, 166);
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Status";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "[Migration ID]";
			this.columnHeader2.Width = 107;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Started";
			this.columnHeader3.Width = 115;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Finished";
			this.columnHeader4.Width = 115;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Migration Name";
			this.columnHeader5.Width = 140;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(246, 245);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 2;
			this.button4.Text = "Открыть";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(245, 21);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(208, 17);
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "Открыть файл созданной миграции";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(6, 247);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(234, 21);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.опцииToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(608, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// опцииToolStripMenuItem
			// 
			this.опцииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проверитьПодключениеКБазеДанныхToolStripMenuItem,
            this.открытьПапкуСМиграциямиToolStripMenuItem,
            this.открытьКонфигурационныйФайлPhinxToolStripMenuItem});
			this.опцииToolStripMenuItem.Name = "опцииToolStripMenuItem";
			this.опцииToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.опцииToolStripMenuItem.Text = "Опции";
			// 
			// проверитьПодключениеКБазеДанныхToolStripMenuItem
			// 
			this.проверитьПодключениеКБазеДанныхToolStripMenuItem.Name = "проверитьПодключениеКБазеДанныхToolStripMenuItem";
			this.проверитьПодключениеКБазеДанныхToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
			this.проверитьПодключениеКБазеДанныхToolStripMenuItem.Text = "Проверить подключение к базе данных";
			this.проверитьПодключениеКБазеДанныхToolStripMenuItem.Click += new System.EventHandler(this.проверитьПодключениеКБазеДанныхToolStripMenuItem_Click);
			// 
			// открытьПапкуСМиграциямиToolStripMenuItem
			// 
			this.открытьПапкуСМиграциямиToolStripMenuItem.Name = "открытьПапкуСМиграциямиToolStripMenuItem";
			this.открытьПапкуСМиграциямиToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
			this.открытьПапкуСМиграциямиToolStripMenuItem.Text = "Открыть папку с миграциями";
			this.открытьПапкуСМиграциямиToolStripMenuItem.Click += new System.EventHandler(this.открытьПапкуСМиграциямиToolStripMenuItem_Click);
			// 
			// открытьКонфигурационныйФайлPhinxToolStripMenuItem
			// 
			this.открытьКонфигурационныйФайлPhinxToolStripMenuItem.Name = "открытьКонфигурационныйФайлPhinxToolStripMenuItem";
			this.открытьКонфигурационныйФайлPhinxToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
			this.открытьКонфигурационныйФайлPhinxToolStripMenuItem.Text = "Открыть конфигурационный файл Phinx";
			this.открытьКонфигурационныйФайлPhinxToolStripMenuItem.Click += new System.EventHandler(this.открытьКонфигурационныйФайлPhinxToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(608, 334);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem опцииToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem проверитьПодключениеКБазеДанныхToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьПапкуСМиграциямиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьКонфигурационныйФайлPhinxToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
	}
}

