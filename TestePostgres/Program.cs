using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePostgres.Controller;
using TestePostgres.Model;

namespace TestePostgres
{
	class Program
	{
		static void Main(string[] args)
		{
			ClienteDAO clienteDAO = new ClienteDAO();

			// Cliente cliente = new Cliente() {Nome = "Lucas", Cpf = "462.563.238.23", Idade = 21};


			//clienteDAO.InsereCliente(cliente);

			Cliente cliente = clienteDAO.BuscaCliente("462.563.238.23");

			Console.WriteLine(cliente.Idade);
			Console.ReadLine();
		}
	}
}
