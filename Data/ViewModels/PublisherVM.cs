using System.Collections.Generic;

namespace _libreria_RLG.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }//nombre de la editorial
    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }//nombre del editorial relacionado
        public List<BookAuthorVM> BookAuthors { get; set; } //nombre del 
        //libro y el autor o autores

    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }//autores del libro
        }
    }
}
