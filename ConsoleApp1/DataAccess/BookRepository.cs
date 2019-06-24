using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookRepository : BaseRepository
    {
        public BookRepository(SqlConnection connection) : base(connection)
        {
        }

        public int Insert(Book book)
        {
            const string query = "insert into book (title, publisherid, year, price) values (@title, @publisherid, @year, @price); select cast(scope_identity() as int);";

            SqlParameter title = new SqlParameter("@title", System.Data.DbType.String)
            {
                Value = book.Title
            };

            SqlParameter publisherid = new SqlParameter("@publisherid", System.Data.DbType.Int32)
            {
                Value = book.PublisherId
            };

            SqlParameter year = new SqlParameter("@year", System.Data.DbType.Int32)
            {
                Value = book.Year
            };

            SqlParameter price = new SqlParameter("@price", System.Data.DbType.Int32)
            {
                Value = book.Price
            };

            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(title);
            command.Parameters.Add(publisherid);
            command.Parameters.Add(year);
            command.Parameters.Add(price);

            return (int)command.ExecuteScalar();
        }

        public Book ReadBook2010(int year)
        {
            string query = $"select * from book where year = @year";

            SqlParameter yearParam = new SqlParameter("@year", System.Data.DbType.Int32)
            {
                Value = year
            };

            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(yearParam);

            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var userId = (int)reader["id"];
                var title = reader["title"] as string;
                var publisherid = (int)reader["publisherid"];
                var yearBook = (int)reader["year"];
                var price = (float)reader["price"];

                return new Book
                {
                    Title = title,
                    PublisherId = publisherid,
                    Year = yearBook,
                    Price = price
                };
            }
            else
            {
                throw new InvalidOperationException($"Book with {year} does not exits!");
            }
        }

        public Book ReadMaxBook()
        {
            string query = $"select top 1 * from book order by year desc";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var userId = (int)reader["id"];
                var title = reader["title"] as string;
                var publisherid = (int)reader["publisherid"];
                var yearBook = (int)reader["year"];
                var price = (float)reader["price"];

                return new Book
                {
                    Title = title,
                    PublisherId = publisherid,
                    Year = yearBook,
                    Price = price
                };
            }
            else
            {
                throw new InvalidOperationException($"Table book is empty");
            }
        }

        public Book ReadTop10()
        {
            string query = $"select top 10 * from book";


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };


            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                var userId = (int)reader["id"];
                var title = reader["title"] as string;
                var publisherid = (int)reader["publisherid"];
                var yearBook = (int)reader["year"];
                var price = (float)reader["price"];

                return new Book
                {
                    Title = title,
                    PublisherId = publisherid,
                    Year = yearBook,
                    Price = price
                };
            }
            else
            {
                throw new InvalidOperationException($"Table book is empty");
            }
        }

        public float Update(int id, Book price)
        {
            string query = $"update book set price=@price where id=@id";

            SqlParameter idParam = new SqlParameter("@id", System.Data.DbType.Int32)
            {
                Value = id
            };

            SqlParameter priceParam = new SqlParameter("@price", System.Data.DbType.Int32)
            {
                Value = price
            };

            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(idParam);
            command.Parameters.Add(priceParam);

            return (int)command.ExecuteScalar();
        }

        public int Delete(int id)
        {
            string query = $"delete from book where id=@id";

            SqlParameter idParam = new SqlParameter("@id", System.Data.DbType.Int32)
            {
                Value = id
            };


            var command = new SqlCommand
            {
                CommandText = query,
                Connection = Connection
            };

            command.Parameters.Add(idParam);

            return (int)command.ExecuteScalar();
        }
    }
}
