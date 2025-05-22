using AutoMapper;
using Library_Management.Api.Entities;
using Library_Management.Api.Services.Interfaces;
using Library_Management.Communication.Requests;
using Library_Management.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        private List<string> Errors = new List<string>();
        private readonly decimal _MINIMUM_PRICE = 0.99m;

        bool IsGenderInvalid = false;

        [HttpPost]
        [ProducesResponseType(typeof(CreatedBookResponseJson), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] CreateBookRequestJson request)
        {

            if (IsAnyFieldInvalid(request.Gender, request.Price, out BookGender parsedGender))
            {
                return CustomBadRequest();
            }

            var book = _mapper.Map<Book>(request);
            book.Gender = parsedGender;

            _bookService.Add(book);

            var response = _mapper.Map<CreatedBookResponseJson>(book);

            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {

            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFound($"Book with ID <{id}> was not found.");
            }

            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, UpdateBookRequestJson request)
        {
            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFoundBook(id);
            }

            if (IsAnyFieldInvalid(request.Gender, request.Price, out BookGender parsedGender))
            {
                return CustomBadRequest();
            }

            _mapper.Map(request, book);

            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {

            var book = _bookService.Get(id);

            if (book == null)
            {
                return NotFoundBook(id);
            }

            _bookService.Delete(book);

            return Ok($"Book with id <{book.Id}> deleted successfully.");
        }

        private bool IsAnyFieldInvalid(string gender, decimal price, out BookGender parsedGender)
        {
            if (!TryParseGender(gender, out parsedGender))
            {
                Errors.Add("Gender is invalid.");
                IsGenderInvalid = true;
            }

            if (price < _MINIMUM_PRICE) {
                Errors.Add("Price must be greater than or equal to $0,99");
            }

            return Errors.Any();
        }
        private bool TryParseGender(string gender, out BookGender parsedGender)
        {
            return Enum.TryParse<BookGender>(gender, ignoreCase: true, out parsedGender);
        }

        private IActionResult CustomBadRequest()
        {
            var errorResponse = new Dictionary<string, object>
            {
                {"Errors", Errors }
            };

            if (IsGenderInvalid)
            {
                errorResponse.Add("ValidGenderOptions", Enum.GetNames(typeof(BookGender)));
            }

            return BadRequest(errorResponse);
        }

        private IActionResult NotFoundBook(Guid id)
        {
            return NotFound($"Book with ID <{id}> was not found.");
        }
    }

}
