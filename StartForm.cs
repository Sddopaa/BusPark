using System;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    // Форма заставки — показывается при запуске программы
    public partial class StartForm : Form
    {
        // Время показа заставки — 10 секунд
        private const int SECONDS = 10000;

        // Главная форма приложения
        private MainForm form1 = new MainForm();

        // Таймер для автоматического закрытия заставки
        private Timer _timer = new Timer();

        public StartForm() => InitializeComponent();

        // Скрываем заставку и показываем главную форму
        private void CloseStartForm()
        {
            form1.Show();
            this.Hide();
        }

        // При загрузке запускаем таймер
        private void StartForm_Load(object sender, EventArgs e)
        {
            _timer.Interval = SECONDS;
            _timer.Tick += (s, args) => CloseStartForm();
            _timer.Start();
        }

        // Кнопка "Начать" — останавливаем таймер и открываем главную форму
        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            CloseStartForm();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}