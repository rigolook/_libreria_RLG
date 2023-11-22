using _libreria_RLG.Data.Models.Services;
using _libreria_RLG.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _libreria_RLG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        //acceder a la referencia
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]//publicar una editorial
        public IActionResult Addpublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(Addpublisher), newPublisher); //parte 2 de semana 14 al 20
            }
            catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        //obtener datos de la editorial, los libros publicados y el nombre del autos
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersService.GetPublisherByID(id);
            if(_response != null)
            {
                return Ok(_response);//llamar a la variable de referencia _response 
            }
            else
            {
                return NotFound();//mostrar numero de excepcion
            }
            //que contiene el metodo dandole un id en la interfaz
        }

        [HttpGet("get-publisher-books-whith-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);//llamar a la variable de referencia _response 
           
        }

        [HttpDelete("delete-publisher-by-id")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                 _publishersService.DeletePublisherById(id);//llama al metodo para romever por id la editorial
                  return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
