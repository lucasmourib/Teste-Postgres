using Npgsql;
using System;
using TestePostgres.Model;

namespace TestePostgres.Controller
{
	public class ClienteDAO
	{
		public void InsereCliente(Cliente cliente)
		{
			using (NpgsqlConnection connection = ConnectionFactory.CreateConnection())
			{
				string cmd = $"INSERT INTO Cliente(Nome, Cpf, Idade) VALUES ('{cliente.Nome}','{cliente.Cpf}','{cliente.Idade}')";
				try
				{
					connection.Open();
					using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmd, connection))
					{
						npgsqlCommand.ExecuteNonQuery();
					}

				}
				catch (NpgsqlException ex)
				{
					Console.WriteLine("Ocorreu uma exceção no banco de dados: " + ex);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
		}

		public Cliente BuscaCliente(string cpf)
		{

			string cmd = $"SELECT * FROM Cliente where cpf = '{cpf}'";
			using (NpgsqlConnection connection = ConnectionFactory.CreateConnection())
			{
				try
				{
					Cliente cliente = new Cliente();
					connection.Open();
					using (NpgsqlCommand npgsqlCommand = new NpgsqlCommand(cmd, connection))
					{
						NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
						while (reader.Read())
						{
							cliente.Nome = reader["Nome"].ToString();
							cliente.Cpf = reader["Cpf"].ToString();
							cliente.Idade = (int)reader["Idade"];
						}
					}
					return cliente;
				}

				catch (Exception)
				{
					throw;
				}
			}
		}

		public void AlteraCliente(string cpf, Cliente novosDados)
		{
			string cmd = $"UPDATE cliente SET Nome= {novosDados.Nome}, Cpf = {novosDados.Cpf}, Idade={novosDados.Idade} WHERE Cpf = {cpf}";

			using (NpgsqlConnection connection = ConnectionFactory.CreateConnection())
			{
				try
				{
					connection.Open();
					using (NpgsqlCommand command = new NpgsqlCommand(cmd, connection))
					{
						command.ExecuteNonQuery();
					}
				}
				catch (NpgsqlException)
				{
					Console.WriteLine("Ocorreu um erro ao realizar o update");
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		public void DeletaCliente(string cpf)
		{
			string query = $"DELETE FROM public.cliente	WHERE Cpf = {cpf}";
			using (NpgsqlConnection connection = ConnectionFactory.CreateConnection())
			{
				connection.Open();
				try
				{
					using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
					{
						command.ExecuteNonQuery();
					}
				}
				catch (NpgsqlException)
				{
					Console.WriteLine("Ocorreu um erro ao deletar o cliente");
				}
				catch (Exception)
				{
					throw;
				}
			}


		}

	}
}
