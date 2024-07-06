using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StudentMangementSystem
{
    internal class DBconnect
    {
        //creating connection
        MySqlConnection connect = new MySqlConnection("Server=localhost;Port=3306;Username=root;Password=;Database=studentdb;");

        //getting connection
        public MySqlConnection getconnection
        {
            get
            {
                return connect;
            }
        }

        // fun opening connection
        public void openConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
        }

        // fun closing connection
        public void closeConnect() 
        {
            if (connect.State == System.Data.ConnectionState.Open)
            {
                connect.Close();
            }
        }
    }
}
