using System;

namespace Lab4
{
    /// <summary>
    /// Конструктор класса DataBasis
    /// <param name="db_name">Название Базы данных</param>
    /// <param name="GetInformation">Метод, позволяющий выводить информацию об используемой Базе Данных</param>
    /// <param name="getMethods">Метод, позволяющий вызывать другие методы Базы Данных</param>
    /// </summary>
    /// <remarks>Класс отвечает за данные Базы Данных</remarks>
    public class DataBasis
    {
        string db_name;
        public DataBasis(string db_n) => db_name = db_n;
        public void GetInformation () { Console.WriteLine(db_name); }

        public void getMethods(string db_name) { Console.WriteLine("вызов нужных методов"); }

    }

    /// <summary>
    /// Конструктор класса Table
    /// <param name="table_name">Имя таблицы</param>
    /// <param name="key">Ключ таблицы</param>
    /// <param name="CreateTable">Метод, отвечающий за создание таблицы</param>
    /// <param name="DeleteTable">Метод, позволяющий удалить таблицу</param>
    /// <param name="AlterTable">Метод, позволяющий изменить таблицу</param>
    /// <param name="ShowInformation">Метод, вывести информацию из таблицы</param>
    /// </summary>
    /// <remarks>Класс отвечает действия с таблицами</remarks>
    public class Table
    {
        public string table_name;
        public string key;
        public Table(string table_n, string k)
        {
            table_name = table_n;
            key = k;
        }
        public void CreateTable(string table_name, string key) { Console.WriteLine("Таблица создана"); }
        public void DeleteTable(string table_name, string key) { Console.WriteLine("Таблица удалена"); }
        public void AlterTable(string table_name, string key) { Console.WriteLine("Таблица изменена"); }
        public void ShowInformation() { Console.WriteLine(table_name + " " + key); }
    }
    /// <summary>
    /// Конструктор класса Information
    /// <param name="rows">Строки и столбцы информации</param>
    /// <param name="GetRows">Метод, отвечающий за измененние данных в таблице</param>
    /// <param name="GetInformation">Метод, позволяющий выводить информацию из таблицы</param>
    /// <param name="AlterInformation">Метод, позволяющий изменить информацию из таблицы</param>
    /// <param name="DeleteInformation">Метод, позволяющий удалить информацию из таблицы</param>
    /// </summary>
    /// <remarks>Класс отвечает за информацию в таблице</remarks>
    class Information : Table
    {

        public string[] rows;

        public Information(string table_name, string key, string[] data) : base(table_name, key)
        {
            rows = GetRows(data);
        }

        private string[] GetRows(string[] data)
        {
            string[] new_row = { "1", "2", "3" };
            //так как прописывать методы не надо, то пусть так и останется
            return new_row;
        }
        public void GetInformation(string table_name, string key)
        {
            Console.WriteLine("Information : {0},{1},{2},{3}", table_name, key);
        }

        public string[] AlterInformation(string table_name, string key, string[] new_data)
        {
            string[] new_row = { "1", "2", "3" };
            Console.WriteLine("Информация изменена");
            //допустим тут я меняю информацию в таблице
            return new_row;
        }

        public Table DeleteInformation(string table_name, string key)
        {
            DeleteTable(table_name, key);
            Console.WriteLine("Данные изменены");
            Table new_t = new Table(this.table_name, this.key);
            return new_t;
        }
    }
    /// <summary>
    /// Конструктор класса References
    /// <param name="reference">Таблица, на которую будет ссылаться исходная таблица</param>
    /// <param name="CreateReference">Метод, отвечающий за создание ссылки</param>
    /// <param name="Delete_Reference">Метод, позволяющий удалить ссылку</param>
    /// <param name="AlterReference">Метод, позволяющий изменить ссылку</param>
    /// </summary>
    /// <remarks>Класс отвечает действия с таблицами, имеющими зависимости и ссылки на другие таблицы</remarks>

    class Referenses : Table
    {
        public Table reference;

        public Referenses(string table_name, string key, Table refe) : base(table_name, key)
        {
            reference = refe;
        }

        public void CreateReference(string table_name_1, string key_1, Table table_ref) { Console.WriteLine("Метод: CreateReference работает"); }
        public static void AlterReference(string table_name_1, string key_1, Table table_ref) { Console.WriteLine("Метод: AlterReference работает");  }
        public void Delete_Reference(string table_name_1, string key_1, Table table_ref) { Console.WriteLine("Метод: Delete_Reference работает"); }
    }

    /// <summary>
    /// Точка входа для приложения.
    /// </summary>
    /// <param name="tab">Переменная для создания таблицы</param>
    /// <param name="NewDB">Метод для тестирования написанных классов</param>
    /// <param name="Test_M">Метод для тестирования написанных классов</param>
    class Program {
        public static void Main() {
            
            NewDB();
            Test_m();

        }

        public static void NewDB()
        {
            DataBasis db = new DataBasis("Oracle");
            Console.WriteLine("Введите название СУБД:");
            string db_name = Console.ReadLine();
            if (db_name == "Oracle") { db = new DataBasis("Oracle"); }
            else if (db_name == "MySql") { db = new DataBasis("MySql"); }
            else if (db_name == "PostgreSQL") db = new DataBasis("PostgreSql");
            else Console.WriteLine("Не верно введено название СУБД");
            //вызываем методы
            db.getMethods(db_name);
        }

        public static void Test_m()
        {
            Console.WriteLine("Введите требуемые методы для проверки:");
            string s = Console.ReadLine();
            String[] methods = s.Split(' ');

            //переменная для тестирования методов Таблиц
            Table tab = new Table("Customers", "customn");
            //переменная для тестирования методов Ссылок 
            Referenses ref_t = new Referenses("Product", "prod", tab);
            //переменная для тестирования методов для изменения информации
            string[] new_row = { "1", "2", "3" };
            Information ninf = new Information("", "",new_row);

            
            
            foreach (string meth in methods)
            {
                if (meth == "AlterTable") tab.AlterTable("Customers", "customn");
                if (meth == "DeleteTable") tab.DeleteTable("Customers", "customn"); 
                if (meth == "CreateReference") ref_t.CreateReference("Product", "prod", tab);
                if (meth == "DeleteInformation") ninf.DeleteInformation("hk", "klj");
            }
           
            Console.ReadKey();

        }
    }
}

  
