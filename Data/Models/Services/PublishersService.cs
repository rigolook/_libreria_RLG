using _libreria_RLG.Data.ViewModels;
using _libreria_RLG.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using static _libreria_RLG.Data.ViewModels.PublisherWithBooksAndAuthorsVM;

namespace _libreria_RLG.Data.Models.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        //metodo que nos permite agregar un nueva editora en la BD
        public Publisher AddPublisher(PublisherVM Publisher)
        {
            if (StringStartsWithNumber(Publisher.Name)) throw new PublisherNameException("El nombre empieza con un número",
                Publisher.Name);
            var _publisher = new Publisher()
            {
              Name = Publisher.Name,
               
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);
        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    { 
                        BookName = n.Titulo,
                        BookAuthors = n.Book_Authors.Select(n=>n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherById(int id)
        {
            var _publisher =  _context.Publishers.FirstOrDefault(n => n.Id == id);
            if(_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con el id: {id} no existe!");
            }
        }
        private bool StringStartsWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));

    }
}
