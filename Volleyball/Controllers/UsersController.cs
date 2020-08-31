using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volleyball.DataAccess;
using Volleyball.DataAccess.Models;
using Volleyball.Models;

namespace Volleyball.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly VolleyballContext _context;
        private readonly IMapper _mapper;

        public UsersController(VolleyballContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreateUserModel model)
        {
            var newUser = _mapper.Map<User>(model);

            await _context.Users.AddAsync(newUser).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}