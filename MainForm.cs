using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    public partial class MainForm : Form
    {
        // Класс для работы с таблицей DataGridView
        private WorkWithTable table;

        public MainForm()
        {
            InitializeComponent();

            // При закрытии формы — завершаем приложение
            this.FormClosing += (s, e) => Application.Exit();

            // Инициализируем класс работы с таблицей
            table = new WorkWithTable(dataGridView1);

            // Создаём колонки таблицы
            table.InitialTable();

            // Подписываемся на клик по строке таблицы
            dataGridView1.CellClick += DataGridView1_CellClick;

            // Подписываемся на пункты меню "Файл"
            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            открытьБДToolStripMenuItem.Click += открытьБДToolStripMenuItem_Click;
            сохранитьКакToolStripMenuItem.Click += сохранитьКакToolStripMenuItem_Click;
            удалитьБДToolStripMenuItem.Click += удалитьБДToolStripMenuItem_Click;
            создатьОтчётToolStripMenuItem.Click += создатьОтчётToolStripMenuItem_Click;
        }

        // ================= ЗАГРУЗКА ФОРМЫ =================
        private void MainForm_Load(object sender, EventArgs e)
        {
            // БД уже выбрана на предыдущем экране (SelectDbForm) — просто отображаем данные
            table.UpdateTable();
            UnlockControls();

            // Запрет редактирования ячеек напрямую
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].ReadOnly = true;

                // Заголовки колонок по центру
                dataGridView1.Columns[i].HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            // Настройки внешнего вида таблицы
            dataGridView1.AllowUserToAddRows = false; // запрет добавления строк
            dataGridView1.RowHeadersVisible = false; // убираем левый столбец с номерами
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // колонки на всю ширину
            dataGridView1.AllowUserToResizeColumns = false; // запрет изменения ширины колонок
            dataGridView1.AllowUserToResizeRows = false; // запрет изменения высоты строк
            dataGridView1.EnableHeadersVisualStyles = false; // свой стиль заголовков
            dataGridView1.RowsDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter; // текст в ячейках по центру

            // Запрет ввода текста в комбобоксы — только выбор из списка
            comboBoxField.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRoute.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRouteUpdate.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ================= БЛОКИРОВКА КОНТРОЛОВ =================

        // Блокирует все контролы кроме меню и кнопки выхода
        private void LockControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Name == "menuStrip1" || ctrl.Name == "btnExit")
                    ctrl.Enabled = true;
                else
                    ctrl.Enabled = false;
            }
        }

        // Разблокирует все контролы
        private void UnlockControls()
        {
            foreach (Control ctrl in this.Controls)
                ctrl.Enabled = true;
        }

        // ================= КЛИК ПО СТРОКЕ ТАБЛИЦЫ =================

        // При клике на строку — заполняем поля вкладки "Обновление"
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Игнорируем клик по заголовку
            if (e.RowIndex < 0) return;

            // Выделяем строку
            dataGridView1.Rows[e.RowIndex].Selected = true;
            var row = dataGridView1.Rows[e.RowIndex];

            // Заполняем поля вкладки "Обновление" данными из выбранной строки
            textBoxPlateUpdate.Text = row.Cells["PlateNumber"].Value.ToString();
            textBoxDriverUpdate.Text = row.Cells["Driver"].Value.ToString();
            comboBoxRouteUpdate.Text = row.Cells["Route"].Value.ToString();
            numericIncomeUpdate.Value = Convert.ToDecimal(row.Cells["Income"].Value);
            numericExpenseUpdate.Value = Convert.ToDecimal(row.Cells["Expense"].Value);
            numericMileageUpdate.Value = Convert.ToInt32(row.Cells["Mileage"].Value);
        }

        // ================= ДОБАВЛЕНИЕ =================

        // Создаём объект автобуса и добавляем в список и БД
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем что строковые поля не пустые
                if (string.IsNullOrWhiteSpace(textBoxPlate.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDriver.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxRoute.Text))
                {
                    new Exceptions("Поля не могут быть пустыми!");
                    return;
                }

                // Создаём объект автобуса из введённых данных
                var bus = new BusPark(
                    textBoxPlate.Text,
                    textBoxDriver.Text,
                    comboBoxRoute.Text,
                    numericIncome.Value,
                    numericExpense.Value,
                    (int)numericMileage.Value
                );

                // Добавляем в список и сохраняем в БД
                BusPark.AddBus(bus);
                Database.InsertBus(bus);

                // Обновляем таблицу
                table.UpdateTable();

                // Очищаем текстовые поля
                textBoxPlate.Clear();
                textBoxDriver.Clear();
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        // ================= ОБНОВЛЕНИЕ =================

        // Применяем изменения к выбранной записи и сохраняем в БД
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем что строка выбрана
                if (dataGridView1.CurrentRow == null)
                {
                    new Exceptions("Выберите строку в таблице для обновления!");
                    return;
                }

                // Проверяем что поля не пустые
                if (string.IsNullOrWhiteSpace(textBoxPlateUpdate.Text) ||
                    string.IsNullOrWhiteSpace(textBoxDriverUpdate.Text) ||
                    string.IsNullOrWhiteSpace(comboBoxRouteUpdate.Text))
                {
                    new Exceptions("Поля не могут быть пустыми!");
                    return;
                }

                // Берём объект из списка по индексу выбранной строки
                int index = dataGridView1.CurrentRow.Index;
                var bus = BusPark.Buses[index];

                // Обновляем поля объекта данными из формы
                bus.PlateNumber = textBoxPlateUpdate.Text;
                bus.Driver = textBoxDriverUpdate.Text;
                bus.Route = comboBoxRouteUpdate.Text;
                bus.Income = numericIncomeUpdate.Value;
                bus.Expense = numericExpenseUpdate.Value;
                bus.Mileage = (int)numericMileageUpdate.Value;

                // Сохраняем изменения в БД
                Database.UpdateBus(bus);

                // Обновляем таблицу
                table.UpdateTable();

                // Очищаем текстовые поля
                textBoxPlateUpdate.Clear();
                textBoxDriverUpdate.Clear();
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        // ================= УДАЛЕНИЕ =================

        // Удаляем выбранную запись из списка и БД
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Если ничего не выбрано — просто выходим
                if (dataGridView1.CurrentRow == null) return;

                int index = dataGridView1.CurrentRow.Index;
                var bus = BusPark.Buses[index];

                // Удаляем из БД и из списка
                Database.DeleteBus(bus.Id);
                BusPark.RemoveBus(bus);

                // Обновляем таблицу
                table.UpdateTable();
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        // ================= СОРТИРОВКА =================

        // Сортируем таблицу по выбранному полю и порядку
        private void btnSort_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxField.Text))
                {
                    new Exceptions("Выберите поле для сортировки!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(comboBoxSort.Text))
                {
                    new Exceptions("Выберите порядок сортировки!");
                    return;
                }

                bool ascending = comboBoxSort.Text == "По возрастанию";
                table.Sort(comboBoxField.Text, ascending);
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        // ================= ФИЛЬТР =================

        // Фильтруем таблицу по выбранному полю и значению
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBoxField.Text))
                {
                    new Exceptions("Выберите поле для фильтрации!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBoxFilter.Text))
                {
                    new Exceptions("Введите значение для фильтрации!");
                    return;
                }

                table.Filter(comboBoxField.Text, textBoxFilter.Text);
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        // ================= ПОИСК =================

        // Подсвечиваем строки содержащие введённый текст
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    new Exceptions("Введите текст для поиска!");
                    return;
                }

                table.Finder(textBoxSearch.Text);
            }
            catch (Exception ex)
            {
                new Exceptions(ex.Message);
            }
        }

        // ================= СБРОС =================

        // Сбрасываем фильтр и очищаем поле
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            table.CancelFilter();
            textBoxFilter.Clear();
        }

        // Сбрасываем сортировку
        private void btnResetSort_Click(object sender, EventArgs e)
        {
            table.CancelSort();
        }

        // Убираем подсветку поиска и очищаем поле
        private void btnResetSearch_Click(object sender, EventArgs e)
        {
            table.CancelFinder();
            textBoxSearch.Clear();
        }

        // ================= ВЫХОД =================

        // Завершаем приложение
        private void btnExit_Click(object sender, EventArgs e) => Application.Exit();

        // ================= МЕНЮ "ФАЙЛ" =================

        // Создать новую БД — открываем диалог ввода имени
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var inputForm = new CreationDataBase())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    Database.CreateDatabase(inputForm.DatabaseName);
                    BusPark.Buses.Clear();
                    table.UpdateTable();
                    UnlockControls();
                    this.Text = "Автобусный парк / " + inputForm.DatabaseName;
                }
            }
        }

        // Открыть существующую БД из .sql файла
        private void открытьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title = "Открыть базу данных"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                bool success = Database.OpenSqlFile(openDialog.FileName);
                if (success)
                {
                    table.UpdateTable();
                    UnlockControls();
                    this.Text = "Автобусный парк / " +
                        Path.GetFileNameWithoutExtension(openDialog.FileName);
                }
            }
        }

        // Сохранить текущую БД в .sql файл
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "SQL файлы (*.sql)|*.sql",
                Title = "Сохранить базу данных",
                FileName = Database.CurrentDatabase + ".sql"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
                Database.SaveDatabase(saveDialog.FileName);
        }

        // Удалить текущую БД после подтверждения
        private void удалитьБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Вы действительно хотите удалить базу данных '{Database.CurrentDatabase}'?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Database.DeleteDatabase(Database.CurrentDatabase);
                BusPark.Buses.Clear();
                table.UpdateTable();
                LockControls();
                this.Text = "Автобусный парк";
            }
        }

        // Экспортировать таблицу в PDF файл
        private void создатьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BusPark.Buses.Count == 0)
            {
                new Exceptions("Таблица пуста — нечего экспортировать!");
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                Filter = "PDF файлы (*.pdf)|*.pdf",
                Title = "Сохранить отчёт",
                FileName = "Отчёт_автобусный_парк.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
                Database.SaveTableToPdf(saveDialog.FileName);
        }

        // ================= ЗАГЛУШКИ ДИЗАЙНЕРА =================
        private void button1_Click(object sender, EventArgs e) => btnFilter_Click(sender, e);
        private void button2_Click(object sender, EventArgs e) => btnSort_Click(sender, e);
        private void button3_Click(object sender, EventArgs e) => btnFind_Click(sender, e);
        private void button4_Click(object sender, EventArgs e) => btnDelete_Click(sender, e);
        private void button5_Click(object sender, EventArgs e) => btnResetFilter_Click(sender, e);
        private void button6_Click(object sender, EventArgs e) => btnResetSort_Click(sender, e);
        private void button7_Click(object sender, EventArgs e) => btnResetSearch_Click(sender, e);
        private void button8_Click(object sender, EventArgs e) => btnExit_Click(sender, e);
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void textBoxPlate_TextChanged(object sender, EventArgs e) { }
        private void textBoxDriver_TextChanged(object sender, EventArgs e) { }
        private void comboBoxRoute_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numericIncome_ValueChanged(object sender, EventArgs e) { }
        private void numericExpense_ValueChanged(object sender, EventArgs e) { }
        private void numericMileage_ValueChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void textBoxPlateUpdate_TextChanged(object sender, EventArgs e) { }
        private void comboBoxRouteUpdate_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numericIncomeUpdate_ValueChanged(object sender, EventArgs e) { }
        private void numericExpenseUpdate_ValueChanged(object sender, EventArgs e) { }
        private void numericMileageUpdate_ValueChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e) { }
    }
}