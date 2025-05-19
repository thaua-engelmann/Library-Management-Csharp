using Library_Management.Models;

namespace Library_Management.Communication.Responses
{
    public class CreatedBookResponseJson
    {

        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public BookGender Gender { get; set; }
    }
}
