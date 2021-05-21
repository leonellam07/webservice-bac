using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webservice_bac.Models;

namespace webservice_bac.DataAccess
{
    public class ClienteRepository
    {
        public string CON_STRING = System.Configuration.ConfigurationManager.AppSettings["AppConnection"];

        public List<Cliente> GetAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "select * from te_clientes";

            using (SqlConnection connection = new SqlConnection(CON_STRING))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(reader["cli_codigo_cliente"].ToString());
                    cliente.Nombre1 = reader["cli_nombre1"].ToString();
                    cliente.Nombre2 = reader["cli_nombre2"].ToString();
                    cliente.Apellido1 = reader["cli_apellido1"].ToString();
                    cliente.Apellido2 = reader["cli_apellido2"].ToString();
                    cliente.ApellidoCasada = reader["cli_apellido_casada"].ToString();
                    cliente.Direccion = reader["cli_direccion"].ToString();
                    cliente.Telefono1 = Convert.ToDecimal(reader["cli_telefono1"].ToString());
                    cliente.Telefono2 = Convert.ToDecimal(reader["cli_telefono2"].ToString());
                    cliente.Identificacion = reader["cli_identificacion"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(reader["cli_fecha_nacimiento"].ToString());
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }
        public Cliente FindById(int codigo)
        {
            Cliente cliente = new Cliente();
            string query = "  exec sp_mantenimiento_clientes"
                            + " @w_opcion = 'C_IX'"
                            + ", @i_cli_codigo_cliente = ''"
                            + ", @i_cli_nombre1 = ''"
                            + ", @i_cli_nombre2 = ''"
                            + ", @i_cli_apellido1 = ''"
                            + ", @i_cli_apellido2 = ''"
                            + ", @i_cli_apellido_casada = ''"
                            + ", @i_cli_direccion = ''"
                            + ", @i_cli_telefono1 = '0'"
                            + ", @i_cli_telefono2 = '0'"
                            + ", @i_cli_identificacion = '1231321-123132-13141'"
                            + ", @i_cli_fecha_nacimiento = '02/10/1996'";

            using (SqlConnection connection = new SqlConnection(CON_STRING))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cliente.Codigo = Convert.ToInt32(reader["cli_codigo_cliente"].ToString());
                    cliente.Nombre1 = reader["cli_nombre1"].ToString();
                    cliente.Nombre2 = reader["cli_nombre2"].ToString();
                    cliente.Apellido1 = reader["cli_apellido1"].ToString();
                    cliente.Apellido2 = reader["cli_apellido2"].ToString();
                    cliente.ApellidoCasada = reader["cli_apellido_casada"].ToString();
                    cliente.Direccion = reader["cli_direccion"].ToString();
                    cliente.Telefono1 = Convert.ToDecimal(reader["cli_telefono1"].ToString());
                    cliente.Telefono2 = Convert.ToDecimal(reader["cli_telefono2"].ToString());
                    cliente.Identificacion = reader["cli_identificacion"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(reader["cli_fecha_nacimiento"].ToString());
                
                }
            }

            return cliente;
        }
        public Cliente Add(Cliente cliente)
        {
            string query = "  exec sp_mantenimiento_clientes"
                            + " @w_opcion = 'I'"
                            + ", @i_cli_codigo_cliente = @codigo"
                            + ", @i_cli_nombre1 = @nombre1"
                            + ", @i_cli_nombre2 = @nombre2"
                            + ", @i_cli_apellido1 = @apellido1"
                            + ", @i_cli_apellido2 = @apellido2"
                            + ", @i_cli_apellido_casada = @apellidoCasada"
                            + ", @i_cli_direccion = @direccion"
                            + ", @i_cli_telefono1 = @telefono1"
                            + ", @i_cli_telefono2 = @telefono2"
                            + ", @i_cli_identificacion = @identificacion"
                            + ", @i_cli_fecha_nacimiento = @fechaNacimiento";

            using (SqlConnection connection = new SqlConnection(CON_STRING))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo", cliente.Codigo);
                command.Parameters.AddWithValue("@nombre1", cliente.Nombre1);
                command.Parameters.AddWithValue("@nombre2", cliente.Nombre2);
                command.Parameters.AddWithValue("@apellido1", cliente.Apellido1);
                command.Parameters.AddWithValue("@apellido2", cliente.Apellido2);
                command.Parameters.AddWithValue("@apellidoCasada", cliente.ApellidoCasada);
                command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@telefono1", cliente.Telefono1);
                command.Parameters.AddWithValue("@telefono2", cliente.Telefono2);
                command.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento.ToString("MM/dd/yyyy"));
                double key = Convert.ToDouble(command.ExecuteScalar());
                connection.Close();

                cliente.Codigo = Convert.ToInt32(key);
            }

            return cliente;
        }
        public Cliente Update(Cliente cliente)
        {
            string query = "  exec sp_mantenimiento_clientes"
                            + " @w_opcion = 'U'"
                            + ", @i_cli_codigo_cliente = @codigo"
                            + ", @i_cli_nombre1 = @nombre1"
                            + ", @i_cli_nombre2 = @nombre2"
                            + ", @i_cli_apellido1 = @apellido1"
                            + ", @i_cli_apellido2 = @apellido2"
                            + ", @i_cli_apellido_casada = @apellidoCasada"
                            + ", @i_cli_direccion = @direccion"
                            + ", @i_cli_telefono1 = @telefono1"
                            + ", @i_cli_telefono2 = @telefono2"
                            + ", @i_cli_identificacion = @identificacion"
                            + ", @i_cli_fecha_nacimiento = @fechaNacimiento";

            using (SqlConnection connection = new SqlConnection(CON_STRING))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo", cliente.Codigo);
                command.Parameters.AddWithValue("@nombre1", cliente.Nombre1);
                command.Parameters.AddWithValue("@nombre2", cliente.Nombre2);
                command.Parameters.AddWithValue("@apellido1", cliente.Apellido1);
                command.Parameters.AddWithValue("@apellido2", cliente.Apellido2);
                command.Parameters.AddWithValue("@apellidoCasada", cliente.ApellidoCasada);
                command.Parameters.AddWithValue("@direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@telefono1", cliente.Telefono1);
                command.Parameters.AddWithValue("@telefono2", cliente.Telefono2);
                command.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento.ToString("MM/dd/yyyy"));
                command.ExecuteNonQuery();
                connection.Close();

            }

            return FindById(cliente.Codigo);
        }
        public string Delete(int codigo)
        {
            string query = "  exec sp_mantenimiento_clientes"
                            + " @w_opcion = 'D'"
                            + ", @i_cli_codigo_cliente = @codigo"
                            + ", @i_cli_nombre1 = ''"
                            + ", @i_cli_nombre2 = ''"
                            + ", @i_cli_apellido1 = ''"
                            + ", @i_cli_apellido2 = ''"
                            + ", @i_cli_apellido_casada = ''"
                            + ", @i_cli_direccion = ''"
                            + ", @i_cli_telefono1 = '0'"
                            + ", @i_cli_telefono2 = '0'"
                            + ", @i_cli_identificacion = ''"
                            + ", @i_cli_fecha_nacimiento = ''";

            using (SqlConnection connection = new SqlConnection(CON_STRING))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo", codigo);
                command.ExecuteNonQuery();
                connection.Close();

            }

            return "Eliminado";
        }
    }
}