using Library_Management.Communication.Requests;
using Library_Management.Communication.Responses;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(CreatedBookResponseJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] CreateBookRequestJson request)
        {

            var response = new CreatedBookResponseJson
            {
                Name = request.Name,
                Author = request.Author,
                Gender = request.Gender,
            };

            return Created(string.Empty, response);
        }

    }
}
