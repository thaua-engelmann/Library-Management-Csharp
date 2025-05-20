using System.Text.Json.Serialization;

namespace Library_Management.Api.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BookGender
    {
        Fiction,
        Romance,
        Action,
        Terror
    }

    public class Book
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public BookGender Gender { get; set; }
    }
}
