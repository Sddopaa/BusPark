using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace KursProject_Malyshev_24VP2
{
    // Класс для работы с таблицей DataGridView на главной форме
    internal class WorkWithTable
    {
        // Ссылка на таблицу с главной формы
        private DataGridView dataGridView;

        // Оригинальный список до сортировки/фильтрации — нужен для сброса
        private List<BusPark> default_List;

        // Конструктор — принимаем ссылку на таблицу
        public WorkWithTable(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        // ================= ИНИЦИАЛИЗАЦИЯ =================

        // Создание колонок таблицы при запуске
        public void InitialTable()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("PlateNumber", "Номер ТС");
            dataGridView.Columns.Add("Driver", "Водитель");
            dataGridView.Columns.Add("Route", "Маршрут");
            dataGridView.Columns.Add("Income", "Доход (руб/д)");
            dataGridView.Columns.Add("Expense", "Расход (руб/д)");
            dataGridView.Columns.Add("Mileage", "Пробег (км/д)");
        }

        // ================= ДОБАВЛЕНИЕ / ОБНОВЛЕНИЕ =================

        // Добавление одной строки в таблицу
        public void AddBusToTable(BusPark bus)
        {
            dataGridView.Rows.Add(
                bus.PlateNumber,
                bus.Driver,
                bus.Route,
                bus.Income,
                bus.Expense,
                bus.Mileage
            );
        }

        // Полное обновление таблицы из списка
        public void UpdateTable()
        {
            dataGridView.Rows.Clear();
            foreach (var bus in BusPark.Buses)
                AddBusToTable(bus);
        }

        // ================= СОРТИРОВКА =================

        // Сортировка по выбранному полю и направлению
        public void Sort(string column, bool ascending)
        {
            // Сохраняем оригинальный список для возможности сброса
            default_List = new List<BusPark>(BusPark.Buses);

            switch (column)
            {
                case "Номер ТС":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.PlateNumber).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.PlateNumber).ToList();
                    break;
                case "Водитель":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Driver).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Driver).ToList();
                    break;
                case "Маршрут":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Route).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Route).ToList();
                    break;
                case "Доход (руб/д)":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Income).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Income).ToList();
                    break;
                case "Расход (руб/д)":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Expense).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Expense).ToList();
                    break;
                case "Пробег (км/д)":
                    BusPark.Buses = ascending
                        ? BusPark.Buses.OrderBy(b => b.Mileage).ToList()
                        : BusPark.Buses.OrderByDescending(b => b.Mileage).ToList();
                    break;
            }

            UpdateTable();
        }

        // ================= ФИЛЬТРАЦИЯ =================

        // Фильтрация по выбранному полю и значению
        public void Filter(string column, string value)
        {
            // Сохраняем оригинальный список для возможности сброса
            default_List = new List<BusPark>(BusPark.Buses);

            switch (column)
            {
                case "Номер ТС":
                    BusPark.Buses = BusPark.Buses.Where(b => b.PlateNumber.Contains(value)).ToList();
                    break;
                case "Водитель":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Driver.Contains(value)).ToList();
                    break;
                case "Маршрут":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Route.Contains(value)).ToList();
                    break;
                case "Доход (руб/д)":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Income.ToString().Contains(value)).ToList();
                    break;
                case "Расход (руб/д)":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Expense.ToString().Contains(value)).ToList();
                    break;
                case "Пробег (км/д)":
                    BusPark.Buses = BusPark.Buses.Where(b => b.Mileage.ToString().Contains(value)).ToList();
                    break;
            }

            UpdateTable();
        }

        // ================= ПОИСК =================

        // Подсвечивает найденные строки зелёным, сбрасывает предыдущую подсветку
        public void Finder(string searchText)
        {
            // Сбрасываем предыдущую подсветку
            foreach (DataGridViewRow row in dataGridView.Rows)
                row.DefaultCellStyle.BackColor = Color.White;

            searchText = searchText.ToLower();

            // Подсвечиваем строки содержащие искомый текст
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                bool containsText =
                    row.Cells["PlateNumber"].Value.ToString().ToLower().Contains(searchText) ||
                    row.Cells["Driver"].Value.ToString().ToLower().Contains(searchText) ||
                    row.Cells["Route"].Value.ToString().ToLower().Contains(searchText) ||
                    row.Cells["Income"].Value.ToString().ToLower().Contains(searchText) ||
                    row.Cells["Expense"].Value.ToString().ToLower().Contains(searchText) ||
                    row.Cells["Mileage"].Value.ToString().ToLower().Contains(searchText);

                if (containsText)
                    row.DefaultCellStyle.BackColor = Color.YellowGreen;
            }
        }

        // ================= СБРОС =================

        // Отмена сортировки — возвращаем оригинальный список
        public void CancelSort()
        {
            if (default_List == null) return;
            BusPark.Buses = default_List;
            default_List = null;
            UpdateTable();
        }

        // Отмена фильтрации — возвращаем оригинальный список
        public void CancelFilter()
        {
            if (default_List == null) return;
            BusPark.Buses = default_List;
            default_List = null;
            UpdateTable();
        }

        // Убираем подсветку поиска
        public void CancelFinder()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
                row.DefaultCellStyle.BackColor = Color.White;
        }
    }
}