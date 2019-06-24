using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Book b1 = new Book();
            Book b2 = new Book();
            Book b4 = new Book();
            Book b3 = new Book();
            b1.Id = 1;
            b1.Price = 140;
            b1.Title = "Amintiri din copilarie";
            b1.PublisherId = 2;
            b1.Year = 1980;

            b2.Id = 11;
            b2.Price = 120;
            b2.Title = "Fluturi";
            b2.PublisherId = 2;
            b2.Year = 2014;
            b3.Id = 12;
            b3.Price = 30;
            b3.Title = "Basme";
            b3.PublisherId = 3;
            b3.Year = 2019;
            b4.Id = 3;
            b4.Price = 10;
            b4.Title = "Inger si demon";
            b4.PublisherId = 1;
            b4.Year = 2018;
            books.Add(b1);
            books.Add(b2);
            books.Add(b3);
            books.Add(b4);

            var json = new JavaScriptSerializer();
            var serializedResult = json.Serialize(books);
            string JsonFile = @"C:\Users\karin\Desktop\Book.json";
            try
            {

                if (File.Exists(JsonFile))
                {

                    File.Delete(JsonFile);
                }

                // Create
                using (FileStream JSON = File.Create(JsonFile))
                {
                    Byte[] a = new UTF8Encoding(true).GetBytes(serializedResult);

                    JSON.Write(a, 0, a.Length);

                }
            }
            catch (Exception e)
            {
                Console.Write("Eroare: " + e.Message);
            }
            //XML
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
            string XMLFile = @"C:\Users\karin\Desktop\Book.xml";
            try
            {
                if (File.Exists(XMLFile))
                {

                    File.Delete(XMLFile);
                }

                using (FileStream XML = File.Create(XMLFile))
                {

                    writer.Serialize(XML, books);

                }
            }
            catch (Exception e)
            {
                Console.Write("Eroare :" + e.Message);
            }

        }
    }
