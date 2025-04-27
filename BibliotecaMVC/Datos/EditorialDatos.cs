using BibliotecaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Pkcs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaMVC.Datos
{
    public class EditorialDatos
    {
        private string conexionString = @"Data Source=DESKTOP-SJQDT9G\SQLEXPRESS;Initial Catalog = BibliotecaMVC; Integrated Security = True; Encrypt=False";
        public List<Editorial> ListarEditoriales(int id)
        {
            List<Editorial> lista = new List<Editorial>();
            using (SqlConnection con = new SqlConnection(conexionString))//establecemos la conexion
            {
                string query ="SELECT * FROM Editorial";
                if (id > 0)
                {
                    query += $"WHERE IdEditorial {id} ";
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Editorial()
                    {
                        IdEditorial = (int)reader["IdEditorial"],
                        NombreEd = reader["NombreEd"].ToString()
                    });
                }
            }
            return lista;
        }
        public string CrearEditorial(Editorial editorial) 
        {
            string query = $"INSERT INTO Editorial (NombreEd) values ('{editorial.NombreEd}')";
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
        public string EditarEditorial(Editorial editorial)
        {
            string query = $"UPDATE Editorial SET NombreEd = '{editorial.NombreEd}' WHERE IdEditorial = {editorial.IdEditorial} ";
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
    }
}
