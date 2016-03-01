using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Controllers;
using Npgsql;
using WebService.Models;
using System.Configuration;

namespace WebService.Models
{
    public class ClienteManager
    {

        string cadenaConexion = ConfigurationManager.ConnectionStrings["DBUsers"].ConnectionString;

        public bool InsertarCliente(Cliente cli)
        {
            NpgsqlConnection con = new NpgsqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO Clientes (Nombre, Telefono) VALUES (@nombre, @telefono)";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cli.Nombre;
            cmd.Parameters.Add("@telefono", NpgsqlTypes.NpgsqlDbType.Integer).Value = cli.Telefono;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarCliente(Cliente cli)
        {
            NpgsqlConnection con = new NpgsqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE Clientes SET Nombre = @nombre, Telefono = @telefono WHERE IdCliente = @idcliente";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.Add("@nombre", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cli.Nombre;
            cmd.Parameters.Add("@telefono", NpgsqlTypes.NpgsqlDbType.Integer).Value = cli.Telefono;
            cmd.Parameters.Add("@idcliente", NpgsqlTypes.NpgsqlDbType.Integer).Value = cli.Id;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public LoginModel ObtenerCliente(int id, string nombre)
        {
            LoginModel cli = null;

            NpgsqlConnection con = new NpgsqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT Nombre, Telefono FROM Clientes WHERE IdCliente = @idcliente";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente",NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
            cmd.Parameters.Add("@telefono", NpgsqlTypes.NpgsqlDbType.Text).Value = nombre;

            NpgsqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            if (reader.Read())
            {
                cli = new LoginModel();
                cli.UserName = reader.GetString(0);
                cli.UserPassword = reader.GetString(1);
            }

            reader.Close();

            return cli;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            NpgsqlConnection con = new NpgsqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT IdCliente,Nombre,Telefono FROM Clientes";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            NpgsqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Cliente cli = new Cliente();

                cli = new Cliente();
                cli.Id = reader.GetInt32(0);
                cli.Nombre = reader.GetString(1);
                cli.Telefono = reader.GetString(2);

                lista.Add(cli);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCliente(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM Clientes WHERE IdCliente = @idcliente";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public List<LoginModel> ClienteLogin()
        {
            List<LoginModel> lista = new List<LoginModel>();

            NpgsqlConnection con = new NpgsqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT IdCliente,Telefono FROM Clientes";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            NpgsqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                LoginModel cli = new LoginModel();

                cli = new LoginModel();
                cli.UserName = reader.GetString(0);
                cli.UserPassword = reader.GetString(1);

                lista.Add(cli);
            }

            reader.Close();

            return lista;
        }

    }
}