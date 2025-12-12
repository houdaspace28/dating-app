using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    
    public class MembersController(AppDbContext context) : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
          var members=await context.Users.ToListAsync();
          return members;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var member=await context.Users.FindAsync(id);
            if (member == null) return NotFound();
            return member;
        }
    }
}
