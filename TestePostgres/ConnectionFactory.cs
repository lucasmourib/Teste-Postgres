using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePostgres
{
	public class ConnectionFactory
	{
		private static readonly string stringConnection = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
												"localhost", "5432", "postgres", "root","TestePostgres");


		public static NpgsqlConnection CreateConnection()
		{
			return new NpgsqlConnection(stringConnection);
		}	
	}
}
