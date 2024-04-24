using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DolgozokConsoleApp
{
    internal class Adatbazis
    {
        MySqlCommand sqlCommand;
        MySqlConnection sqlConnection;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dolgozok";
            sqlConnection = new MySqlConnection(builder.ConnectionString);
            sqlCommand = sqlConnection.CreateCommand();
            try
            {
                kapcsolatNyit();
                kapcsolatZar();
            }
            catch (MySqlException sql)
            {
                Console.WriteLine(sql.Message);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void kapcsolatZar()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        private void kapcsolatNyit()
        {
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }

        internal List<Dolgozo> getAllDolgozo()
        {
            List<Dolgozo> dolgozok = new List<Dolgozo>();
            sqlCommand.CommandText = "SELECT `nev`, `neme`, `reszleg`, `belepesev`, `ber` FROM `dolgozok` WHERE 1";
            kapcsolatNyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader()) 
            {
                while (dr.Read())
                {
                    Dolgozo dolgozo = new Dolgozo(dr.GetString("nev"), dr.GetString("neme"), dr.GetString("reszleg"), dr.GetInt32("belepesev"), dr.GetInt32("ber"));
                    dolgozok.Add(dolgozo);
                }
                return dolgozok;
            }
        }
    }
}
