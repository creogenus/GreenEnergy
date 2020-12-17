using System;
using System.Linq;
using System.Collections.Generic;

#nullable disable

namespace GE_DB
{
    public class Programm
    {
        public static void Main(string[] args)
        {
            GEDatabase GEBD = GEDatabase.Init("Server=(localdb)\\mssqllocaldb;Database=GE_BD;Trusted_Connection=True;");
            
        }
    }
}