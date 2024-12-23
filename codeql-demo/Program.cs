using System;
using System.Data.SqlClient;

class Program
{
    const string ApiKey = "sk_test_1234567890abcdef"; // Hardcoded API Key (Secret)

    static void Main()
    {
        Console.WriteLine("Kullanıcı adını girin:");
        string username = Console.ReadLine();

        string connectionString = "Data Source=server;Initial Catalog=db;User ID=user;Password=pass";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // SQL Injection açığı: Kullanıcı girdisi doğrudan SQL sorgusunda kullanılıyor
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

        Console.WriteLine($"API Key: {ApiKey}");
    }
}
