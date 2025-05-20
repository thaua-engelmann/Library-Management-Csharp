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

        List<string> Errors = new List<string>();
        bool isGenderInvalid = false;

        [HttpPost]
        [ProducesResponseType(typeof(CreatedBookResponseJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] CreateBookRequestJson request)
        {

            if (!TryParseGender(request.Gender, out BookGender parsedGender)) {

                Errors.Add("Gender is not valid.");
                isGenderInvalid = true;
            }

            const decimal MINIMUM_PRICE = 0.99m;

            if (request.Price < MINIMUM_PRICE)
            {
                Errors.Add("Price must be greater than or equal to $0,99.");
            }

            if (Errors.Any())
            {

                var errorResponse = new Dictionary<string, object>
                {
                    {"Errors", Errors }
                };

                if (isGenderInvalid)
                {
                    errorResponse.Add("GenderValidOptions", Enum.GetNames(typeof(BookGender)));
                }

                return BadRequest(errorResponse);
            }

            var response = new CreatedBookResponseJson
            {
                Name = request.Name,
                Author = request.Author,
                Price = request.Price,
                Gender = parsedGender
            };

            return Created(string.Empty, response);
        }

        private bool TryParseGender(string gender, out BookGender parsedGender)
        {
            return Enum.TryParse<BookGender>(gender, ignoreCase: true, out parsedGender);
        }
    }

}
