﻿using System;

namespace LawsuitsAPI.Data
{
	public class MySQLConfiguration
	{
		public MySQLConfiguration(string connectionString) => ConnectionString = connectionString;

		public string ConnectionString { get; set; }
	}
}

