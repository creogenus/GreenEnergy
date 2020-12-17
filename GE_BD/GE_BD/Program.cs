using System;
using System.Linq;
using System.Collections.Generic;

#nullable disable

namespace GE_DB
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
        new public string ToString()
        {
            string temp = "\n";
            foreach (Column c in Columns)
                temp += c.Name.PadLeft(c.Length / 2 + c.Name.Length / 2, '-').PadRight(c.Length, '-') + "|";
            return temp;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Class EnergySource_Class = new Class();

            EnergySource_Class.Columns.Add(new Column("Id", 5, type.Int));
            EnergySource_Class.Columns.Add(new Column("Namе", 15, type.String));
            EnergySource_Class.Columns.Add(new Column("Brand", 10, type.String));
            EnergySource_Class.Columns.Add(new Column("Type", 10, type.String));
            EnergySource_Class.Columns.Add(new Column("Material", 10, type.String));
            EnergySource_Class.Columns.Add(new Column("Price", 10, type.Double));

            EnergySource_Class.Columns.Add(new Column("V_wrk", 10, type.Double));
            EnergySource_Class.Columns.Add(new Column("A_wrk", 10, type.Double));

            EnergySource_Class.Columns.Add(new Column("A_sc", 10, type.Double));
            EnergySource_Class.Columns.Add(new Column("V_max", 10, type.Double));
            EnergySource_Class.Columns.Add(new Column("A_max", 10, type.Double));

            EnergySource_Class.Columns.Add(new Column("H", 10, type.Double));
            EnergySource_Class.Columns.Add(new Column("W", 10, type.Double));

            using (GE_DBContext db = new GE_DBContext())
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
                                        Console.WriteLine(EnergySource_Class.ToString());
                                        foreach (EnergySource ES in DB_ES)
                                        {
                                            Console.WriteLine(ES_ToString(ES, EnergySource_Class));
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
                                            Console.WriteLine(EnergySource_Class.ToString());
                                            Console.WriteLine(ES_ToString(ES, EnergySource_Class));
                                        }
                                    }
                                    break;
                                }
                            case 3:
                                {

                                    object[] rows = new object[EnergySource_Class.Columns.Count - 1];
                                    for(int i = 0; i < rows.Length; i++)
                                    {
                                        rows[i] = ConsoleGet(EnergySource_Class.Columns[i+1]);
                                    }
                                    EnergySource ES = new EnergySource();

                                    int ic = 0;

                                    ES.Name = (string) rows[ic++];
                                    ES.Brand = (string) rows[ic++];
                                    ES.Type = (string) rows[ic++];
                                    ES.Material = (string) rows[ic++];
                                    ES.Price = (double) rows[ic++];

                                    ES.Voltage_work = (double) rows[ic++];
                                    ES.Amperage_work = (double) rows[ic++];

                                    ES.Short_circuit_Amperage = (double) rows[ic++];

                                    ES.Voltage_max = (double) rows[ic++];
                                    ES.Amperage_max = (double) rows[ic++];

                                    ES.Height = (double) rows[ic++];
                                    ES.Width = (double) rows[ic++];

                                    db.EnergySources.Add(ES);
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
                                        Console.WriteLine(EnergySource_Class.ToString());
                                        Console.WriteLine(ES_ToString(ES, EnergySource_Class));
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

        static string PadString(string str, int l)
        {
            if (str.Length == l) return str;
            if (str.Length > l) return str.Substring(0, l);
            else return str.PadRight(l, ' ');
        }
        static string ES_ToString(EnergySource ES, Class ES_Class)
        {
            int ic = 0;
            return (PadString(ES.Id.ToString(), ES_Class.Columns[ic++].Length) + "|" +

                    PadString(ES.Name.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Brand.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Type.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Material.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Price.ToString(), ES_Class.Columns[ic++].Length) + "|" +

                    PadString(ES.Voltage_work.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Amperage_work.ToString(), ES_Class.Columns[ic++].Length) + "|" +

                    PadString(ES.Short_circuit_Amperage.ToString(), ES_Class.Columns[ic++].Length) + "|" +

                    PadString(ES.Voltage_max.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Amperage_max.ToString(), ES_Class.Columns[ic++].Length) + "|" +

                    PadString(ES.Height.ToString(), ES_Class.Columns[ic++].Length) + "|" +
                    PadString(ES.Width.ToString(), ES_Class.Columns[ic++].Length) + "|");

        }

        static object ConsoleGet(Column cln)
        {
            switch (cln.Type){
                case type.Double: return ConsoleDouble(cln.Name);
                case type.Int: return ConsoleInt(cln.Name);
                case type.String: return ConsoleString(cln.Name);
                default: return -1;
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
