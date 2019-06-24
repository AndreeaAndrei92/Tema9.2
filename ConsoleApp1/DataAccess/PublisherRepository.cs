using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PublisherRepository : BaseRepository
    {
        public PublisherRepository(SqlConnection connection) : base(connection)
        {
        }

        public Publisher AllPublisher()
        {
            string query = $"select count(*) from Publisher";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var publisherId = (int)reader["id"];
                var name = reader["name"] as string;

                return new Publisher
                {
                    Name = name,
                };
            }
            else
            {
                throw new InvalidOperationException($"Table publisher is empty");
            }
        }

        public Publisher ReadTop10()
        {
            string query = $"select top 10 PublisherId,name from Publisher";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var publisherId = (int)reader["id"];
                var name = reader["name"] as string;

                return new Publisher
                {
                    Name = name,
                };
            }
            else
            {
                throw new InvalidOperationException($"Table publisher is empty");
            }

        }

        public Publisher BookPerPublisher()
        {
            string query = $"select count(bookid), name from Publisher p inner join book b on p.PublisherId=b.PublisherId group by name";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var publisherId = (int)reader["id"];
                var name = reader["name"] as string;

                return new Publisher
                {
                    Name = name,
                };
            }
            else
            {
                throw new InvalidOperationException($"Table publisher is empty");
            }
        }

        public Publisher BookSumPerPublisher()
        {
            string query = $"select sum(price), name from Publisher p inner join book b on p.PublisherId=b.PublisherId group by name";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var publisherId = (int)reader["id"];
                var name = reader["name"] as string;

                return new Publisher
                {
                    Name = name,
                };
            }
            else
            {
                throw new InvalidOperationException($"Table publisher is empty");
            }
        }

        public Publisher NumberBookPerPublisher()
        {
            string query = $"select count(bookid), name from Publisher p inner join book b on p.PublisherId=b.PublisherId group by name";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            SqlDataReader reader = command.ExecuteReader();

            List<NumberOfBooksPerPublisher> listpublisher = new List<NumberOfBooksPerPublisher>();

            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
                Publisher publisher = new Publisher();
                publisher.Name = reader["Name"] as string;
                publisher.PublisherId = (int)reader["PublisherId"];

                listpublisher.Add(publisher);

            }

            foreach (var elem in listpublisher)
            {
                Console.WriteLine($"Elem {elem.Name} - {elem.PublisherId}");
            }

            if (reader.HasRows)
            {
                reader.Read();

                var publisherId = (int)reader["id"];
                var name = reader["name"] as string;

                return new Publisher
                {
                    Name = name,
                };
            }
            else
            {
                throw new InvalidOperationException($"Table publisher is empty");
            }

        }

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

    }
}

