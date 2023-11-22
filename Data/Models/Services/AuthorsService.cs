using _libreria_RLG.Data.ViewModels;
using System;
using System.Linq;

namespace _libreria_RLG.Data.Models.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }
        //metodo que nos permite agregar un nuevo autor en la BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
               
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AutorWithBooksVM GetAutorWithBooksVM(int authorId)
        {
            var _author = _context.Authors.Where(n=>n.Id == authorId).Select(n=> new AutorWithBooksVM()
            {
                FullName = n.FullName,
                BooksTitles = n.Book_Authors.Select(n=>n.Book.Titulo).ToList(),
            }).FirstOrDefault();
            return _author;
        }
    }
}
