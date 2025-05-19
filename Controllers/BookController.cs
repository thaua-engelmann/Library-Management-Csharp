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

            if (!TryParseGender(request.Gender, out BookGender parsedGender)) {

                return BadRequest(new
                {
                    Message = "Gender is not valid.",
                    validOptions = Enum.GetNames(typeof(BookGender))
                });
            }

            var response = new CreatedBookResponseJson
            {
                Name = request.Name,
                Author = request.Author,
                Gender = parsedGender,
            };

            return Created(string.Empty, response);
        }

        private bool TryParseGender(string gender, out BookGender parsedGender)
        {
            return Enum.TryParse<BookGender>(gender, ignoreCase: true, out parsedGender);
        }
    }

}
