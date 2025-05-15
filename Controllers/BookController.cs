using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create(Book book)
        {
            return Created(string.Empty, book);
        }

    }
}
