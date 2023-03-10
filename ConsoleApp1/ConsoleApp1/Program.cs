using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Purchases.dat");
        int fileRecords = 0;
        string[] customerNumbers = { "000001", "000002", "000003", "000004" };
        string[] itemNumbers = { "0001", "0002", "0003", "0004", "0005" };

        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < 100; i++)
            {
                // Write CUST record
                string customerNumber = customerNumbers[random.Next(customerNumbers.Length)];
                writer.WriteLine($"CUST{customerNumber}");

                // Write DATE record
                DateTime date = DateTime.Now.AddHours(-random.Next(1, 24 * 30));
                writer.WriteLine($"DATE{date.ToString("ddMMyyyyHHmm")}");

                // Write ITEM record(s)
                int numberOfItems = random.Next(1, 4);
                for (int j = 0; j < numberOfItems; j++)
                {
                    string itemNumber = itemNumbers[random.Next(itemNumbers.Length)];
                    writer.WriteLine($"ITEM{itemNumber}");
                }
            }
        }
        stopwatch.Stop();
        fileRecords = File.ReadAllLines(filePath).Length;
        Console.WriteLine("File Generato in {0}, generando un numero di righe pari a {1}", stopwatch.Elapsed, fileRecords);
    }
}
