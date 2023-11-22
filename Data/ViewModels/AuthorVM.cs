using System.Collections.Generic;

namespace _libreria_RLG.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AutorWithBooksVM
    {
        public string FullName { get; set;}
        public List<string> BooksTitles { get; set;}
    }
}
