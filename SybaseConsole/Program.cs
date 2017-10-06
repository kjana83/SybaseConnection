using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SybaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DbHelper helper = new DbHelper();
            var dataReader =  helper.ExecuteReader("SELECT syscolumns.name, systypes.name FROM sysobjects JOIN syscolumns ON sysobjects.id = syscolumns.id JOIN systypes ON systypes.type = syscolumns.type AND systypes.usertype = syscolumns.usertype WHERE sysobjects.name LIKE 'Claims'");

            while (dataReader.Read())
            {
                Console.WriteLine(dataReader[0] + "," + dataReader[1]);
            }
            Console.ReadKey();
        }
    }
}
