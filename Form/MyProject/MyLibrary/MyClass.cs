using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyLibrary
{
    public class MyClass
    {
        public int Topla(int value1, int value2)
        {
            return value1 + value2;
        }

        public void Insert(int ID, string name, string surname, string age)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0BJTEAC\SQLEXPRESS; Initial Catalog=OrnekDB; Integrated Security=true");
            conn.Open();

            SqlCommand cmd = new SqlCommand("Insert into Kisiler (ID, name, surname, age) values (@p1, @p2, @p3, @p4)", conn);
            cmd.Parameters.AddWithValue("@p1", ID);
            cmd.Parameters.AddWithValue("@p2", name);
            cmd.Parameters.AddWithValue("@p3", surname);
            cmd.Parameters.AddWithValue("@p4", age);

            cmd.ExecuteNonQuery();
            conn.Close();
        }


    }
}
