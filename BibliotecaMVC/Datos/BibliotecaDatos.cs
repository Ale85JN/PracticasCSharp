using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Pkcs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaMVC.Datos
{
    public class BibliotecaDatos
    {
        private string conexionString = @"Data Source=DESKTOP-SJQDT9G\SQLEXPRESS;Initial Catalog=BibliotecaMVC;Integrated Security=True;Encrypt=False";
        public List<Autor> ListarAutores(int id)//creamos un metodo
        {
            List<Autor> lista = new List<Autor>();//creamos una lista para guardar autores
            using (SqlConnection con = new SqlConnection(conexionString))//establecemos la conexion
            {
                string query = "SELECT * From Autor ";// creamos la query
                if (id > 0)
                {
                    query += $"WHERE IdAutor = {id}";
                }

                con.Open();//abro la coneccion
                SqlCommand cmd = new SqlCommand(query, con);//paso la query y la conexion
                SqlDataReader reader = cmd.ExecuteReader();//ejecuto la lectura

                while (reader.Read())//mientras lea una fila
                {
                    lista.Add(new Autor()// la va agregando a la lista autores que lea de la consulta de la query
                    {
                        IdAutor = (int)reader["IdAutor"],
                        Nombre = reader["Nombre"].ToString(),
                        Nacionalidad = reader["Nacionalidad"].ToString()
                    });
                } 
            }
            return lista;
        }
        public string CrearAutor(Autor autor)
        {
            string query =$"INSERT INTO Autor(Nombre, Nacionalidad) values ('{autor.Nombre}','{autor.Nacionalidad}')";
            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        public string EditarAutor(Autor autor)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $"UPDATE Autor SET Nombre= '{autor.Nombre}', Nacionalidad ='{autor.Nacionalidad}' WHERE IdAutor= {autor.IdAutor} ";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception err)
            {
                return err.Message;
            }

        }
        public string BorrarAutor(int id)
        {
            try
            { 
                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    string query = $"DELETE FROM Autor WHERE IdAutor = {id} ";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }

            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
    }
}
