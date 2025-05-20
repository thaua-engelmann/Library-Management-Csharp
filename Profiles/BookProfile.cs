using AutoMapper;
using Library_Management.Api.Entities;
using Library_Management.Communication.Requests;
using Library_Management.Communication.Responses;

namespace Library_Management.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<CreateBookRequestJson, Book>();
            CreateMap<Book, CreatedBookResponseJson>();
        }

    }
}
