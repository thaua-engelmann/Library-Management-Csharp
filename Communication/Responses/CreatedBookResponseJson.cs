using Library_Management.Api.Entities;

namespace Library_Management.Communication.Responses
{
    public class CreatedBookResponseJson
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public BookGender Gender { get; set; }
    }
}
