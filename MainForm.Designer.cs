using System;

namespace KursProject_Malyshev_24VP2
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnResetSort = new System.Windows.Forms.Button();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numericMileageUpdate = new System.Windows.Forms.NumericUpDown();
            this.numericExpenseUpdate = new System.Windows.Forms.NumericUpDown();
            this.numericIncomeUpdate = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRouteUpdate = new System.Windows.Forms.ComboBox();
            this.textBoxDriverUpdate = new System.Windows.Forms.TextBox();
            this.textBoxPlateUpdate = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericMileage = new System.Windows.Forms.NumericUpDown();
            this.numericExpense = new System.Windows.Forms.NumericUpDown();
            this.numericIncome = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRoute = new System.Windows.Forms.ComboBox();
            this.textBoxDriver = new System.Windows.Forms.TextBox();
            this.textBoxPlate = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMileageUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpenseUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncomeUpdate)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMileage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncome)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.открытьБДToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.удалитьБДToolStripMenuItem,
            this.создатьОтчётToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // открытьБДToolStripMenuItem
            // 
            this.открытьБДToolStripMenuItem.Name = "открытьБДToolStripMenuItem";
            this.открытьБДToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.открытьБДToolStripMenuItem.Text = "Открыть БД";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // удалитьБДToolStripMenuItem
            // 
            this.удалитьБДToolStripMenuItem.Name = "удалитьБДToolStripMenuItem";
            this.удалитьБДToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.удалитьБДToolStripMenuItem.Text = "Удалить БД";
            // 
            // создатьОтчётToolStripMenuItem
            // 
            this.создатьОтчётToolStripMenuItem.Name = "создатьОтчётToolStripMenuItem";
            this.создатьОтчётToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.создатьОтчётToolStripMenuItem.Text = "Создать отчёт";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(263, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(529, 350);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.btnSort);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxSearch);
            this.groupBox1.Controls.Add(this.textBoxFilter);
            this.groupBox1.Controls.Add(this.comboBoxSort);
            this.groupBox1.Controls.Add(this.comboBoxField);
            this.groupBox1.Location = new System.Drawing.Point(12, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Операции";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(6, 157);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(86, 28);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(6, 112);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(86, 28);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Сортировать";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(6, 62);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(86, 28);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Фильтровать";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Критерий";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(101, 162);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(135, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(103, 67);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(135, 20);
            this.textBoxFilter.TabIndex = 2;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "По возрастанию",
            "По убыванию"});
            this.comboBoxSort.Location = new System.Drawing.Point(101, 117);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(135, 21);
            this.comboBoxSort.TabIndex = 1;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBoxField
            // 
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Items.AddRange(new object[] {
            "Номер ТС",
            "Водитель",
            "Маршрут",
            "Доход в день (руб.)",
            "Расход в день (руб.)",
            "Пробег в день (км)"});
            this.comboBoxField.Location = new System.Drawing.Point(101, 21);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(135, 21);
            this.comboBoxField.TabIndex = 0;
            this.comboBoxField.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(260, 401);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(350, 401);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(111, 28);
            this.btnResetFilter.TabIndex = 9;
            this.btnResetFilter.Text = "Сбросить фильтр";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnResetSort
            // 
            this.btnResetSort.Location = new System.Drawing.Point(465, 401);
            this.btnResetSort.Name = "btnResetSort";
            this.btnResetSort.Size = new System.Drawing.Size(130, 28);
            this.btnResetSort.TabIndex = 10;
            this.btnResetSort.Text = "Отменить сортировку";
            this.btnResetSort.UseVisualStyleBackColor = true;
            this.btnResetSort.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Location = new System.Drawing.Point(598, 401);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(105, 28);
            this.btnResetSearch.TabIndex = 11;
            this.btnResetSearch.Text = "Отменить поиск";
            this.btnResetSearch.UseVisualStyleBackColor = true;
            this.btnResetSearch.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(706, 401);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 28);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button8_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnUpdate);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.numericMileageUpdate);
            this.tabPage2.Controls.Add(this.numericExpenseUpdate);
            this.tabPage2.Controls.Add(this.numericIncomeUpdate);
            this.tabPage2.Controls.Add(this.comboBoxRouteUpdate);
            this.tabPage2.Controls.Add(this.textBoxDriverUpdate);
            this.tabPage2.Controls.Add(this.textBoxPlateUpdate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(239, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Обновление";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(7, 163);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(226, 20);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Обновить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Пробег км/д";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Расход р/д";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Доход р/д";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Маршрут";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Водитель";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Гос. номер ТС";
            // 
            // numericMileageUpdate
            // 
            this.numericMileageUpdate.Location = new System.Drawing.Point(88, 137);
            this.numericMileageUpdate.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMileageUpdate.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericMileageUpdate.Name = "numericMileageUpdate";
            this.numericMileageUpdate.Size = new System.Drawing.Size(145, 20);
            this.numericMileageUpdate.TabIndex = 26;
            this.numericMileageUpdate.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericMileageUpdate.ValueChanged += new System.EventHandler(this.numericMileageUpdate_ValueChanged);
            // 
            // numericExpenseUpdate
            // 
            this.numericExpenseUpdate.Location = new System.Drawing.Point(88, 111);
            this.numericExpenseUpdate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericExpenseUpdate.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericExpenseUpdate.Name = "numericExpenseUpdate";
            this.numericExpenseUpdate.Size = new System.Drawing.Size(145, 20);
            this.numericExpenseUpdate.TabIndex = 25;
            this.numericExpenseUpdate.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericExpenseUpdate.ValueChanged += new System.EventHandler(this.numericExpenseUpdate_ValueChanged);
            // 
            // numericIncomeUpdate
            // 
            this.numericIncomeUpdate.Location = new System.Drawing.Point(88, 85);
            this.numericIncomeUpdate.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numericIncomeUpdate.Minimum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numericIncomeUpdate.Name = "numericIncomeUpdate";
            this.numericIncomeUpdate.Size = new System.Drawing.Size(145, 20);
            this.numericIncomeUpdate.TabIndex = 24;
            this.numericIncomeUpdate.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numericIncomeUpdate.ValueChanged += new System.EventHandler(this.numericIncomeUpdate_ValueChanged);
            // 
            // comboBoxRouteUpdate
            // 
            this.comboBoxRouteUpdate.DisplayMember = "1";
            this.comboBoxRouteUpdate.FormattingEnabled = true;
            this.comboBoxRouteUpdate.Items.AddRange(new object[] {
            "№ 1",
            "№ 2",
            "№ 4",
            "№ 5",
            "№ 6",
            "№ 7",
            "№ 29",
            "№ 54",
            "№ 66",
            "№ 70",
            "№ 75",
            "№ 82С",
            "№ 93",
            "№ 101",
            "№ 105",
            "№ 130",
            "№ 149"});
            this.comboBoxRouteUpdate.Location = new System.Drawing.Point(88, 58);
            this.comboBoxRouteUpdate.Name = "comboBoxRouteUpdate";
            this.comboBoxRouteUpdate.Size = new System.Drawing.Size(145, 21);
            this.comboBoxRouteUpdate.TabIndex = 23;
            this.comboBoxRouteUpdate.SelectedIndexChanged += new System.EventHandler(this.comboBoxRouteUpdate_SelectedIndexChanged);
            // 
            // textBoxDriverUpdate
            // 
            this.textBoxDriverUpdate.Location = new System.Drawing.Point(88, 32);
            this.textBoxDriverUpdate.Name = "textBoxDriverUpdate";
            this.textBoxDriverUpdate.Size = new System.Drawing.Size(145, 20);
            this.textBoxDriverUpdate.TabIndex = 22;
            this.textBoxDriverUpdate.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // textBoxPlateUpdate
            // 
            this.textBoxPlateUpdate.Location = new System.Drawing.Point(88, 6);
            this.textBoxPlateUpdate.Name = "textBoxPlateUpdate";
            this.textBoxPlateUpdate.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlateUpdate.TabIndex = 21;
            this.textBoxPlateUpdate.TextChanged += new System.EventHandler(this.textBoxPlateUpdate_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numericMileage);
            this.tabPage1.Controls.Add(this.numericExpense);
            this.tabPage1.Controls.Add(this.numericIncome);
            this.tabPage1.Controls.Add(this.comboBoxRoute);
            this.tabPage1.Controls.Add(this.textBoxDriver);
            this.tabPage1.Controls.Add(this.textBoxPlate);
            this.tabPage1.Controls.Add(this.btnAdd);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(239, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Добавление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Пробег км/д";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Расход р/д";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Доход р/д";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Маршрут";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Водитель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Гос. номер ТС";
            // 
            // numericMileage
            // 
            this.numericMileage.Location = new System.Drawing.Point(88, 137);
            this.numericMileage.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericMileage.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericMileage.Name = "numericMileage";
            this.numericMileage.Size = new System.Drawing.Size(145, 20);
            this.numericMileage.TabIndex = 14;
            this.numericMileage.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericMileage.ValueChanged += new System.EventHandler(this.numericMileage_ValueChanged);
            // 
            // numericExpense
            // 
            this.numericExpense.Location = new System.Drawing.Point(88, 111);
            this.numericExpense.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericExpense.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericExpense.Name = "numericExpense";
            this.numericExpense.Size = new System.Drawing.Size(145, 20);
            this.numericExpense.TabIndex = 13;
            this.numericExpense.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericExpense.ValueChanged += new System.EventHandler(this.numericExpense_ValueChanged);
            // 
            // numericIncome
            // 
            this.numericIncome.Location = new System.Drawing.Point(88, 85);
            this.numericIncome.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numericIncome.Minimum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numericIncome.Name = "numericIncome";
            this.numericIncome.Size = new System.Drawing.Size(145, 20);
            this.numericIncome.TabIndex = 12;
            this.numericIncome.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.numericIncome.ValueChanged += new System.EventHandler(this.numericIncome_ValueChanged);
            // 
            // comboBoxRoute
            // 
            this.comboBoxRoute.FormattingEnabled = true;
            this.comboBoxRoute.Items.AddRange(new object[] {
            "№ 1",
            "№ 2",
            "№ 4",
            "№ 5",
            "№ 6",
            "№ 7",
            "№ 29",
            "№ 54",
            "№ 66",
            "№ 70",
            "№ 75",
            "№ 82С",
            "№ 93",
            "№ 101",
            "№ 105",
            "№ 130",
            "№ 149"});
            this.comboBoxRoute.Location = new System.Drawing.Point(88, 58);
            this.comboBoxRoute.Name = "comboBoxRoute";
            this.comboBoxRoute.Size = new System.Drawing.Size(145, 21);
            this.comboBoxRoute.TabIndex = 11;
            this.comboBoxRoute.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoute_SelectedIndexChanged);
            // 
            // textBoxDriver
            // 
            this.textBoxDriver.Location = new System.Drawing.Point(88, 32);
            this.textBoxDriver.Name = "textBoxDriver";
            this.textBoxDriver.Size = new System.Drawing.Size(145, 20);
            this.textBoxDriver.TabIndex = 10;
            this.textBoxDriver.TextChanged += new System.EventHandler(this.textBoxDriver_TextChanged);
            // 
            // textBoxPlate
            // 
            this.textBoxPlate.Location = new System.Drawing.Point(88, 6);
            this.textBoxPlate.Name = "textBoxPlate";
            this.textBoxPlate.Size = new System.Drawing.Size(145, 20);
            this.textBoxPlate.TabIndex = 9;
            this.textBoxPlate.TextChanged += new System.EventHandler(this.textBoxPlate_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 163);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(226, 20);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(247, 216);
            this.tabControl1.TabIndex = 2;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResetSearch);
            this.Controls.Add(this.btnResetSort);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(820, 490);
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "MainForm";
            this.Text = "Автобусный парк";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMileageUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpenseUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncomeUpdate)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMileage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIncome)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтчётToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnResetSort;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericMileageUpdate;
        private System.Windows.Forms.NumericUpDown numericExpenseUpdate;
        private System.Windows.Forms.NumericUpDown numericIncomeUpdate;
        private System.Windows.Forms.ComboBox comboBoxRouteUpdate;
        private System.Windows.Forms.TextBox textBoxDriverUpdate;
        private System.Windows.Forms.TextBox textBoxPlateUpdate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericMileage;
        private System.Windows.Forms.NumericUpDown numericExpense;
        private System.Windows.Forms.NumericUpDown numericIncome;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.TextBox textBoxDriver;
        private System.Windows.Forms.TextBox textBoxPlate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

