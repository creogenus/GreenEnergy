using System;
using System.Linq;
using System.Collections.Generic;

#nullable disable

namespace GE_BD
{
    public enum type { Int = 1, Double = 2, String = 3}
    public class Column
    {
        public string Name { get; set; }
        public type Type { get; set; }
        public int Length { get; set; }
        public Column(string Name, int Length, type Type)
        {
            this.Name = Name;
            this.Length = Length;
            this.Type = Type;
        }
    }
    public class Class
    {
        public List<Column> Columns { get; set; }
        public Class() 
        { 
            Columns = new List<Column>();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Class EnergySource_Class = new Class();
            EnergySource_Class.Columns.Add(new Column("Id", 5, type.Int));
            EnergySource_Class.Columns.Add(new Column("Type", 10, type.String));
            EnergySource_Class.Columns.Add(new Column("Name", 15, type.String));
            EnergySource_Class.Columns.Add(new Column("Brand", 15, type.String));
            EnergySource_Class.Columns.Add(new Column("Voltage", 10, type.Int));
            EnergySource_Class.Columns.Add(new Column("Amperage", 10, type.Int));
            EnergySource_Class.Columns.Add(new Column("Price", 10, type.Double));

            using (GE_BDContext db = new GE_BDContext())
            {
                while (true)
                {
                    int TableNumber = ConsoleNumber("\nВыберите таблицу\n" +
                   "\t1 | EnergySource\n" +
                   "\t2\n" +
                   "\t3\n" +
                   "\t0 | Выход\n", 3);
                    if (TableNumber == 0) return;

                    while (true)
                    {
                        int ActionNumber = ConsoleNumber("\nEnergySource\n" +
                                "\t1 | Вывести все отношения\n" +
                                "\t2 | Найти по ID\n" +
                                "\t3 | Добавить\n" +
                                "\t4 | Удалить по ID\n" +
                                "\t0 | Назад\n", 4);
                        if (ActionNumber == 0) break;
                        switch (ActionNumber)
                        {
                            case 1:
                                {
                                    var DB_ES = db.EnergySources.ToList();
                                    if (DB_ES.Count == 0) Console.WriteLine("\nТаблица пуста");
                                    else
                                    {
                                        Console.Write("\n");
                                        foreach (Column c in EnergySource_Class.Columns) Console.Write(c.Name.PadLeft(c.Length/2 + c.Name.Length/2, '-').PadRight(c.Length, '-') + "|");
                                        Console.Write("\n");
                                        foreach (EnergySource ES in DB_ES)
                                        {
                                            Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|", ES.Id.ToString().PadRight(EnergySource_Class.Columns[0].Length,' '), ES.Type.PadRight(EnergySource_Class.Columns[1].Length, ' '), ES.Name.PadRight(EnergySource_Class.Columns[2].Length, ' '), ES.Brand.PadRight(EnergySource_Class.Columns[3].Length, ' '), ES.Voltage.ToString().PadRight(EnergySource_Class.Columns[4].Length, ' '), ES.Amperage.ToString().PadRight(EnergySource_Class.Columns[5].Length, ' '), ES.Price.ToString().PadRight(EnergySource_Class.Columns[6].Length, ' '));
                                        }
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    while (true)
                                    {
                                        int Id = ConsoleInt("ID");
                                        if (Id == 0) break;
                                        EnergySource ES = db.EnergySources.Find(Id);
                                        if (ES == null) Console.WriteLine("\nТаблица не найдена");
                                        else
                                        {
                                            Console.Write("\n");
                                            foreach (Column c in EnergySource_Class.Columns) Console.Write(c.Name.PadLeft(c.Length / 2 + c.Name.Length / 2, '-').PadRight(c.Length, '-') + "|");
                                            Console.Write("\n");
                                            Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|", ES.Id.ToString().PadRight(EnergySource_Class.Columns[0].Length, ' '), ES.Type.PadRight(EnergySource_Class.Columns[1].Length, ' '), ES.Name.PadRight(EnergySource_Class.Columns[2].Length, ' '), ES.Brand.PadRight(EnergySource_Class.Columns[3].Length, ' '), ES.Voltage.ToString().PadRight(EnergySource_Class.Columns[4].Length, ' '), ES.Amperage.ToString().PadRight(EnergySource_Class.Columns[5].Length, ' '), ES.Price.ToString().PadRight(EnergySource_Class.Columns[6].Length, ' '));
                                        }
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    string TName = ConsoleString(EnergySource_Class.Columns[0].Name);
                                    string TType = ConsoleString(EnergySource_Class.Columns[0].Name);
                                    string TBrand = ConsoleString(EnergySource_Class.Columns[0].Name);
                                    double TVoltage = ConsoleDouble(EnergySource_Class.Columns[0].Name);
                                    double TAmperage = ConsoleDouble(EnergySource_Class.Columns[0].Name);
                                    double TPrice = ConsoleDouble(EnergySource_Class.Columns[0].Name);
                                    db.EnergySources.Add(new EnergySource { Name = TName, Type = TType, Brand = TBrand, Voltage = TVoltage, Amperage = TAmperage, Price = TPrice });
                                    db.SaveChanges();
                                    break;
                                }
                            case 4:
                                {
                                    int Id = ConsoleInt("ID");
                                    if (Id == 0) break;
                                    EnergySource ES = db.EnergySources.Find(Id);
                                    if (ES == null) Console.WriteLine("\nТаблица не найдена");
                                    else
                                    {
                                        Console.WriteLine("Удалено отношение:");
                                        foreach (Column c in EnergySource_Class.Columns) Console.Write(c.Name.PadLeft(c.Length / 2 + c.Name.Length / 2, '-').PadRight(c.Length, '-') + "|");
                                        Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|", ES.Id.ToString().PadRight(EnergySource_Class.Columns[0].Length, ' '), ES.Type.PadRight(EnergySource_Class.Columns[1].Length, ' '), ES.Name.PadRight(EnergySource_Class.Columns[2].Length, ' '), ES.Brand.PadRight(EnergySource_Class.Columns[3].Length, ' '), ES.Voltage.ToString().PadRight(EnergySource_Class.Columns[4].Length, ' '), ES.Amperage.ToString().PadRight(EnergySource_Class.Columns[5].Length, ' '), ES.Price.ToString().PadRight(EnergySource_Class.Columns[6].Length, ' '));
                                        db.EnergySources.Remove(ES);
                                        db.SaveChanges();
                                    }
                                    break;
                                }
                        
                        }
                    }
                }
            }
        }
        static int ConsoleNumber(string text, int limit)
        {
            ConsoleKeyInfo CKI;
            do
                do
                {
                    Console.WriteLine(text);
                    CKI = Console.ReadKey();
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(" ");
                } while (!char.IsNumber(CKI.KeyChar));
            while (Convert.ToInt32(CKI.KeyChar.ToString()) > limit);
            return Convert.ToInt32(CKI.KeyChar.ToString());
        }
        static string ConsoleString(string text)
        {
            string temp;
            do
            {
                Console.WriteLine("\n Введите {0} (string)", text);
                temp = Console.ReadLine();
            } while (temp.Length < 1);
            return temp;
        }
        static int ConsoleInt(string text)
        {
            string temp;
            int tempint;
            do
            {
                Console.WriteLine("\n Введите {0} (int)", text);
                temp = Console.ReadLine();
            } while (!Int32.TryParse(temp, out tempint));
            return Convert.ToInt32(tempint);
        }
        static double ConsoleDouble(string text)
        {
            string temp;
            double tempdbl;
            do
            {
                Console.WriteLine("\n Введите {0} (double)", text);
                temp = Console.ReadLine();
            } while (!Double.TryParse(temp, out tempdbl));
            return Convert.ToDouble(tempdbl);
        }
    }
}
