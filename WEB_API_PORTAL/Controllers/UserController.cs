using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_PORTAL.models;
using Microsoft.EntityFrameworkCore;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace WEB_API_PORTAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _dbContext;

        public UserController(UserContext dbContext)
        {
            _dbContext = dbContext; 
        }

        [HttpGet("GetUsers")]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            return await _dbContext.Users.ToListAsync();
        }

        [HttpGet("getuserbyid")]
        public async Task<ActionResult<User>> GetUserbyId(int id)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost("postuser")]
        public async Task<ActionResult<User>> Postuser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.ID }, user);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<User>> PutBrand(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }
            _dbContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAvaialable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
        private bool UserAvaialable(int id)
        {
            return (_dbContext.Users?.Any(x => x.ID == id)).GetValueOrDefault();
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("GetLoginUser")]

        public async Task<ActionResult<IEnumerable<Login>>> GetLoginUser()
        {
            if (_dbContext.Logins == null)
            if (_dbContext.Logins == null)
            {
                return NotFound();
            }
            return await _dbContext.Logins.ToListAsync();
        }

    }

}
