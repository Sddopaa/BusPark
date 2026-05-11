using System;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    // Форма заставки — показывается при запуске программы
    public partial class StartForm : Form
    {
        // Время показа заставки — 10 секунд
        private const int SECONDS = 10000;

        // После заставки показываем форму выбора БД, а не сразу главную
        private SelectDbForm selectDbForm = new SelectDbForm();

        private Timer _timer = new Timer();

        public StartForm() => InitializeComponent();

        // Скрываем заставку и показываем форму выбора БД
        private void CloseStartForm()
        {
            selectDbForm.Show();
            this.Hide();
        }

        // При загрузке запускаем таймер
        private void StartForm_Load(object sender, EventArgs e)
        {
            _timer.Interval = SECONDS;
            _timer.Tick += (s, args) => { _timer.Stop(); _timer.Dispose(); CloseStartForm(); };
            _timer.Start();
        }

        // Кнопка "Начать" — останавливаем таймер и открываем форму выбора БД
        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
            CloseStartForm();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}