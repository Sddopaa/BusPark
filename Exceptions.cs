using System;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    // Класс для обработки исключений и вывода сообщений об ошибках
    internal class Exceptions : Exception
    {
        // Сообщение для пользователя
        public string UserMessage { get; }

        // Конструктор - показывает MessageBox с ошибкой
        public Exceptions(string userMessage) : base("Произошла ошибка: " + userMessage)
        {
            UserMessage = userMessage;
            MessageBox.Show(UserMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Возвращает текст ошибки
        public override string ToString() => UserMessage;
    }
}