using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Moduls
{
    public class test
    {
        string hello = "hello world ";

        public static void Princ() {
            MySqlConnection con= new MySqlConnection("Server=localhost;" +
                                          "Database=schoolbd;" +
                                          "Uid=root;" +
                                          "Pwd=;");

            con.Open();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "select * from admin";
            MySqlDataReader red = com.ExecuteReader();
            Console.WriteLine("people who can access");
            while (red.Read()) {
                Console.WriteLine(red.GetString(0)+"    "+red.GetString(1) + "    " + red.GetString(2));
            }
        }
    }
}
