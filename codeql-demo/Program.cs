using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.WriteLine("Kullanıcı adını girin:");
        string username = Console.ReadLine();

        string connectionString = "Data Source=server;Initial Catalog=db;User ID=user;Password=pass";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Kullanıcı girdisi doğrudan sorguya ekleniyor (SQL Injection riski!)
            string query = $"SELECT * FROM Users WHERE Username = '{username}'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Kullanıcı: {reader["Username"]}");
                    }
                }
            }
        }
    }
}
