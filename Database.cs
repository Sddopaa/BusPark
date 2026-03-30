using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace KursProject_Malyshev_24VP2
{
    // Класс для работы с базой данных PostgreSQL
    internal class Database
    {
        // ================= КОНСТАНТЫ ПОДКЛЮЧЕНИЯ =================

        private const string PgHost = "localhost";
        private const int PgPort = 5432;
        private const string PgUser = "postgres";
        private const string PgPassword = "password";
        private const string PgBinPath = @"C:\Program Files\PostgreSQL\18\bin\";

        // Текущая активная БД — меняется при создании/открытии/удалении
        public static string CurrentDatabase = "bus_park";

        // Строка подключения к текущей БД
        private static string ConnectionString =>
            $"Host={PgHost};Port={PgPort};Database={CurrentDatabase};Username={PgUser};Password={PgPassword};";

        // Строка подключения к служебной БД postgres — нужна для создания/удаления других БД
        private static string MasterConnectionString =>
            $"Host={PgHost};Port={PgPort};Database=postgres;Username={PgUser};Password={PgPassword};";

        // ================= ПРОВЕРКА СУЩЕСТВОВАНИЯ БД =================

        // Проверяет существует ли текущая БД, создаёт её если нет
        public static void EnsureDatabaseExists()
        {
            try
            {
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(
                        "SELECT 1 FROM pg_database WHERE datname = @db;", conn))
                    {
                        cmd.Parameters.AddWithValue("db", CurrentDatabase);
                        var exists = cmd.ExecuteScalar();

                        // Если БД не найдена — создаём
                        if (exists == null)
                            new NpgsqlCommand($"CREATE DATABASE \"{CurrentDatabase}\";", conn)
                                .ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка проверки БД: " + ex.Message);
            }
        }

        // ================= ИНИЦИАЛИЗАЦИЯ =================

        // Создаёт таблицу buses если её ещё нет
        public static void InitializeDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS buses (
                        id           SERIAL PRIMARY KEY,
                        plate_number VARCHAR(20)    NOT NULL,
                        driver       VARCHAR(100)   NOT NULL,
                        route        VARCHAR(100)   NOT NULL,
                        income       NUMERIC(12,2)  NOT NULL,
                        expense      NUMERIC(12,2)  NOT NULL,
                        mileage      INT            NOT NULL
                    );";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка инициализации БД: " + ex.Message);
            }
        }

        // ================= ЗАГРУЗКА =================

        // Загружает все записи из БД в статический список BusPark.Buses
        public static void LoadFromDatabase()
        {
            try
            {
                BusPark.Buses.Clear();
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM buses ORDER BY id;", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bus = new BusPark(
                                reader["plate_number"].ToString(),
                                reader["driver"].ToString(),
                                reader["route"].ToString(),
                                Convert.ToDecimal(reader["income"]),
                                Convert.ToDecimal(reader["expense"]),
                                Convert.ToInt32(reader["mileage"])
                            );
                            bus.Id = Convert.ToInt32(reader["id"]);
                            BusPark.Buses.Add(bus);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка загрузки данных: " + ex.Message);
            }
        }

        // ================= СОХРАНЕНИЕ СПИСКА В БД =================

        // Полностью перезаписывает таблицу buses данными из списка (используется в pg_dump)
        public static void SaveToDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Очищаем таблицу и сбрасываем счётчик id
                            new NpgsqlCommand("TRUNCATE TABLE buses RESTART IDENTITY;", conn, transaction)
                                .ExecuteNonQuery();

                            // Вставляем все записи из списка
                            foreach (var bus in BusPark.Buses)
                            {
                                string sql = "INSERT INTO buses (plate_number, driver, route, income, expense, mileage) " +
                                             "VALUES (@p, @d, @r, @i, @e, @m);";
                                using (var cmd = new NpgsqlCommand(sql, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("p", bus.PlateNumber);
                                    cmd.Parameters.AddWithValue("d", bus.Driver);
                                    cmd.Parameters.AddWithValue("r", bus.Route);
                                    cmd.Parameters.AddWithValue("i", bus.Income);
                                    cmd.Parameters.AddWithValue("e", bus.Expense);
                                    cmd.Parameters.AddWithValue("m", bus.Mileage);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            transaction.Commit();
                        }
                        catch
                        {
                            // Откатываем транзакцию при ошибке
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка сохранения данных: " + ex.Message);
            }
        }

        // ================= INSERT =================

        // Добавляет одну запись в БД и возвращает её id
        public static void InsertBus(BusPark bus)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO buses (plate_number, driver, route, income, expense, mileage) " +
                                 "VALUES (@p, @d, @r, @i, @e, @m) RETURNING id;";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("p", bus.PlateNumber);
                        cmd.Parameters.AddWithValue("d", bus.Driver);
                        cmd.Parameters.AddWithValue("r", bus.Route);
                        cmd.Parameters.AddWithValue("i", bus.Income);
                        cmd.Parameters.AddWithValue("e", bus.Expense);
                        cmd.Parameters.AddWithValue("m", bus.Mileage);
                        bus.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка добавления записи: " + ex.Message);
            }
        }

        // ================= UPDATE =================

        // Обновляет запись в БД по id
        public static void UpdateBus(BusPark bus)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "UPDATE buses SET plate_number=@p, driver=@d, route=@r, " +
                                 "income=@i, expense=@e, mileage=@m WHERE id=@id;";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("p", bus.PlateNumber);
                        cmd.Parameters.AddWithValue("d", bus.Driver);
                        cmd.Parameters.AddWithValue("r", bus.Route);
                        cmd.Parameters.AddWithValue("i", bus.Income);
                        cmd.Parameters.AddWithValue("e", bus.Expense);
                        cmd.Parameters.AddWithValue("m", bus.Mileage);
                        cmd.Parameters.AddWithValue("id", bus.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка обновления записи: " + ex.Message);
            }
        }

        // ================= DELETE =================

        // Удаляет запись из БД по id
        public static void DeleteBus(int id)
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM buses WHERE id=@id;", conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка удаления записи: " + ex.Message);
            }
        }

        // ================= ОЧИСТКА =================

        // Удаляет все записи из таблицы buses
        public static void ClearDatabase()
        {
            try
            {
                using (var conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM buses;", conn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка очистки БД: " + ex.Message);
            }
        }

        // ================= СОЗДАТЬ БД =================

        // Создаёт новую БД с указанным именем и переключается на неё
        public static void CreateDatabase(string dbName)
        {
            try
            {
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    new NpgsqlCommand($"CREATE DATABASE \"{dbName}\";", conn).ExecuteNonQuery();
                }

                // Переключаемся на новую БД и создаём таблицу
                CurrentDatabase = dbName;
                InitializeDatabase();

                MessageBox.Show($"База данных '{dbName}' создана.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка создания БД: " + ex.Message);
            }
        }

        // ================= УДАЛИТЬ БД =================

        // Удаляет указанную БД и возвращается на дефолтную bus_park
        public static void DeleteDatabase(string dbName)
        {
            try
            {
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();

                    // Отключаем все активные сессии перед удалением
                    new NpgsqlCommand($@"
                        SELECT pg_terminate_backend(pid)
                        FROM pg_stat_activity
                        WHERE datname = '{dbName}' AND pid <> pg_backend_pid();",
                        conn).ExecuteNonQuery();

                    new NpgsqlCommand($"DROP DATABASE IF EXISTS \"{dbName}\";", conn)
                        .ExecuteNonQuery();
                }

                // Возвращаемся на дефолтную БД
                CurrentDatabase = "bus_park";

                MessageBox.Show($"База данных '{dbName}' удалена.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка удаления БД: " + ex.Message);
            }
        }

        // ================= СОХРАНИТЬ КАК .SQL =================

        // Сохраняет текущую БД в .sql файл через pg_dump
        public static void SaveDatabase(string outputPath)
        {
            try
            {
                string pgDump = Path.Combine(PgBinPath, "pg_dump.exe");
                if (!File.Exists(pgDump))
                {
                    new Exceptions("pg_dump.exe не найден: " + pgDump);
                    return;
                }

                // Синхронизируем список с БД перед дампом
                SaveToDatabase();

                var psi = new ProcessStartInfo
                {
                    FileName = pgDump,
                    Arguments = $"-U {PgUser} -d \"{CurrentDatabase}\" -F p -f \"{outputPath}\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Environment = { ["PGPASSWORD"] = PgPassword }
                };

                using (var process = Process.Start(psi))
                {
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        new Exceptions("Ошибка pg_dump: " + error);
                        return;
                    }
                }

                MessageBox.Show("БД сохранена в файл: " + outputPath, "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка сохранения БД: " + ex.Message);
            }
        }

        // ================= ОТКРЫТЬ .SQL =================

        // Восстанавливает БД из .sql файла через psql и переключается на неё
        public static bool OpenSqlFile(string filePath)
        {
            try
            {
                string dbName = Path.GetFileNameWithoutExtension(filePath);
                string psql = Path.Combine(PgBinPath, "psql.exe");

                if (!File.Exists(psql))
                {
                    new Exceptions("psql.exe не найден: " + psql);
                    return false;
                }

                // Создаём БД с именем файла
                using (var conn = new NpgsqlConnection(MasterConnectionString))
                {
                    conn.Open();
                    new NpgsqlCommand($"CREATE DATABASE \"{dbName}\";", conn).ExecuteNonQuery();
                }

                // Восстанавливаем данные из файла
                var psi = new ProcessStartInfo
                {
                    FileName = psql,
                    Arguments = $"-U {PgUser} -d \"{dbName}\" -f \"{filePath}\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Environment = { ["PGPASSWORD"] = PgPassword }
                };

                using (var process = Process.Start(psi))
                {
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        new Exceptions("Ошибка восстановления БД: " + error);
                        return false;
                    }
                }

                // Переключаемся на восстановленную БД и загружаем данные
                CurrentDatabase = dbName;
                LoadFromDatabase();

                MessageBox.Show($"База данных '{dbName}' открыта.", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка открытия файла: " + ex.Message);
                return false;
            }
        }

        // ================= PDF =================

        // Экспортирует текущую таблицу в PDF файл через iTextSharp
        public static void SaveTableToPdf(string outputPath)
        {
            try
            {
                // Загружаем Arial из Windows для поддержки кириллицы
                string fontPath = @"C:\Windows\Fonts\arial.ttf";
                var baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(
                    fontPath,
                    iTextSharp.text.pdf.BaseFont.IDENTITY_H,
                    iTextSharp.text.pdf.BaseFont.EMBEDDED);

                var titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                var headerFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                var cellFont = new iTextSharp.text.Font(baseFont, 9);

                using (var fs = new FileStream(outputPath, FileMode.Create))
                {
                    var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate());
                    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Заголовок документа
                    var title = new iTextSharp.text.Paragraph(
                        $"Автобусный парк — отчёт ({CurrentDatabase})", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new iTextSharp.text.Paragraph(" "));

                    // Таблица с 6 колонками
                    var table = new iTextSharp.text.pdf.PdfPTable(6);
                    table.WidthPercentage = 100;

                    // Заголовки колонок
                    foreach (var header in new[]
                    {
                        "Номер ТС", "Водитель", "№ Маршрута",
                        "Доход (руб/д)", "Расход (руб/д)", "Пробег (км/д)"
                    })
                    {
                        var cell = new iTextSharp.text.pdf.PdfPCell(
                            new iTextSharp.text.Phrase(header, headerFont));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(200, 200, 200);
                        cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        cell.Padding = 5;
                        table.AddCell(cell);
                    }

                    // Строки данных
                    foreach (var bus in BusPark.Buses)
                    {
                        foreach (var val in new string[]
                        {
                            bus.PlateNumber,
                            bus.Driver,
                            bus.Route,
                            bus.Income.ToString(),
                            bus.Expense.ToString(),
                            bus.Mileage.ToString()
                        })
                        {
                            var cell = new iTextSharp.text.pdf.PdfPCell(
                                new iTextSharp.text.Phrase(val, cellFont));
                            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.Padding = 4;
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                MessageBox.Show("Отчёт сохранён: " + outputPath, "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                new Exceptions("Ошибка создания PDF: " + ex.Message);
            }
        }
    }
}