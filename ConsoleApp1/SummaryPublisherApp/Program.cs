using Connection;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = ConnectionManager.GetConnection();

            var publisherRepository = new PublisherRepository(connection);

            var allPublisher = PublisherRepository.AllPublisher();
            allPublisher.Print();

            var top10Publisher = PublisherRepository.ReadTop10();
            top10Publisher.Print();

            var bookPerPublisher = PublisherRepository.BookPerPublisher();
            bookPerPublisher.Print();

            var sumbookPerPublisher = PublisherRepository.BookSumPerPublisher();
            sumbookPerPublisher.Print();
        }
    }
}
