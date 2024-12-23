using System;

class Program
{
    const string ApiKey = "sk_test_1234567890abcdef"; // Hardcoded Secret

    static void Main()
    {
        Console.WriteLine("Bu program bir güvenlik açığı içeriyor!");
        Console.WriteLine($"API Anahtarı: {ApiKey}"); // Hardcoded Secret Kullanımı
    }
}
