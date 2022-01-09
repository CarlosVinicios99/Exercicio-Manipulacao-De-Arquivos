using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

using Exercicio1.Entities;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            Console.Write("Enter the file path: ");
            string sourcePath = Console.ReadLine();

            try
            {
                string[] salesData = File.ReadAllLines(sourcePath);

                for(int i = 0; i < salesData.Length; i++)
                {
                    Console.WriteLine(salesData[i]);
                    string[] itemData = salesData[i].Split(",");

                    string name = itemData[0];
                    double price = double.Parse(itemData[1], CultureInfo.InvariantCulture);
                    int quantity = int.Parse(itemData[2]);
                    items.Add(new Item(name, price, quantity));
                }

                 string targetPath = @"/home/carlos/Documentos/C#/Projetos/Exercicio-manipulacao-arquivos/Exercicio1/Arquivos/summary.csv";

                FileInfo fileInfo = new FileInfo(targetPath);
                fileInfo.CreateText();
                StreamWriter sw = fileInfo.AppendText();

                foreach(Item item in items)
                { 
                    string line = item.Name + "," + item.TotalValue().ToString("F2", CultureInfo.InvariantCulture);
                    sw.WriteLine(line);
                }
                sw.Close();
            }

            catch(IOException e)
            {
                Console.WriteLine("Error occurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}
