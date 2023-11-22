using System.Collections.Generic;

namespace _libreria_RLG.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Propiedades de navegacion (

        public List<Book_Author> Book_Authors { get; set; }

    }
}
