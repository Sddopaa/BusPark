using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    public partial class CreationDataBase : Form
    {
        // Имя введённой БД — читаем снаружи
        public string DatabaseName { get; private set; }

        public CreationDataBase() => InitializeComponent();

        // Кнопка ОК
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите имя базы данных.");
                return;
            }
            DatabaseName = textBoxName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Кнопка Отмена
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CreationDataBase_Load(object sender, EventArgs e) { }
    }
}
