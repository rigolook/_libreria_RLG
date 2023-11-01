using _libreria_RLG.Data.Models.Services;
using _libreria_RLG.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _libreria_RLG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService; 
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBook(book);
            return Ok();
        }
    }
}
