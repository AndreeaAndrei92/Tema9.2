using Connection;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionManager.GetConnection();

            var bookRepository = new BookRepository(connection);

            int year = 2010;
            var savedBook = BookRepository.ReadBook2010(year);
            savedBook.Print();

            var maxBook = BookRepository.ReadMaxBook();
            maxBook.Print();

            var top10Book = BookRepository.ReadTop10();
            top10Book.Print();
        }
    }
}
