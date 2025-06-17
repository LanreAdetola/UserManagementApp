using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Models; 


namespace MinimalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            // ✅ Check if a user with the same email already exists (case-insensitive)
            bool emailExists = await _context.Users
                .AnyAsync(u => u.Email.ToLower() == newUser.Email.ToLower());

            if (emailExists)
            {
                // Return a 409 Conflict response if email already exists
                return Conflict("A user with this email already exists.");
            }


            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            
            return CreatedAtAction(nameof(GetAllUsers), new { id = newUser.Id }, newUser);
        }

        // ✅ UPDATE user
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User updatedUser)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 with validation errors
            }


            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Phone = updatedUser.Phone;

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // ❌ DELETE user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent(); // 204 No Content
        }
    }
}
