using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProyectoInfinityCreations.BD

{
    class Conexion
    {

        MySqlConnection conex = new MySqlConnection();
        static string servidor = "localhost";
        static string bd = "infinitycreations";
        static string usuario = "root";
        static string password = "";
        static string port = "3306";
        List<String> user = new List<String>();
        List<String> contraseña = new List<String>();

        String Conecc = "server=" + servidor + ";" + "port=" + port + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
        public bool VerifyUser(string data){
            try
            {
                conex.ConnectionString = Conecc;
                conex.Open();     
                MySqlDataReader reader = null;

                MySqlCommand cmd = new MySqlCommand(data, conex);
                reader = cmd.ExecuteReader();


                while (reader.Read()) {

                    contraseña.Add(reader.GetString(1));
                    user.Add(reader.GetString(0));
                }
                if (user.Count == 0) {
                    
                    return false;
                }
                return true;
            }
            catch (MySqlException a)
            {
                MessageBox.Show(a.Message);
                return false;
            }
            finally
            {
                conex.Close();
            }
        }
    }
}
