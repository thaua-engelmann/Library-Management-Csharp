using Library_Management.Models;

namespace Library_Management.Communication.Requests
{
    public class CreateBookRequestJson
    {

        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
    }
}
