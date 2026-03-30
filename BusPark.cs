using System;
using System.Collections.Generic;

namespace KursProject_Malyshev_24VP2
{
    // Класс транспортного средства автобусного парка
    public class BusPark
    {
        // Идентификатор записи в базе данных
        public int Id { get; set; }
        // Государственный номер ТС
        public string PlateNumber { get; set; }
        // ФИО водителя
        public string Driver { get; set; }
        // Маршрут ТС
        public string Route { get; set; }
        // Доход по маршруту в рублях
        public decimal Income { get; set; }
        // Расход по маршруту в рублях
        public decimal Expense { get; set; }
        // Пробег в километрах
        public int Mileage { get; set; }

        // Статический список всех ТС
        public static List<BusPark> Buses = new List<BusPark>();

        // Конструктор класса
        public BusPark(string plateNumber, string driver, string route,
                       decimal income, decimal expense, int mileage)
        {
            PlateNumber = plateNumber;
            Driver = driver;
            Route = route;
            Income = income;
            Expense = expense;
            Mileage = mileage;
        }

        // Добавить ТС в список
        public static void AddBus(BusPark bus)
        {
            Buses.Add(bus);
        }

        // Удалить ТС из списка
        public static void RemoveBus(BusPark bus)
        {
            Buses.Remove(bus);
        }
    }
}