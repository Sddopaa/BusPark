using System;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    // Форма выбора действия с базой данных — показывается после заставки
    // Пользователь либо создаёт новую БД, либо открывает существующую из файла
    public partial class SelectDbForm : Form
    {
        // Главная форма создаётся здесь — откроется после выбора БД
        private MainForm mainForm = new MainForm();

        public SelectDbForm()
        {
            InitializeComponent();
            this.Text = "Автобусный парк — выбор базы данных";
            this.FormClosing += (s, e) => Application.Exit();
        }

        // Кнопка "Создать базу данных"
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            using (var inputForm = new CreationDataBase())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Database.CreateDatabase(inputForm.DatabaseName);
                        Database.LoadFromDatabase();
                        mainForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        new Exceptions("Ошибка создания БД: " + ex.Message);
                    }
                }
            }
        }

        // Кнопка "Подключиться к существующей" — открываем .sql файл
        private void btnConnect_Click_1(object sender, EventArgs e)
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
                    mainForm.Show();
                    this.Hide();
                }
            }
        }
    }
}
