using AutoMapper;
using Volleyball.DataAccess.Models;
using Volleyball.Models;

namespace Volleyball.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
        }
    }
}