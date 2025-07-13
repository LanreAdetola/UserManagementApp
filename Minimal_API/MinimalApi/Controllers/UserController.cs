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
        public UserController(AppDbContext context) => _context = context;

        // ──────────────────────────────── READ ALL
        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
            => await _context.Users.AsNoTracking().ToListAsync();

        // ──────────────────────────────── READ ONE
        // GET: api/user/5
        [HttpGet("{id:int}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        // ──────────────────────────────── CREATE
        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> Create(User newUser)
        {
            if (!ModelState.IsValid)              return BadRequest(ModelState);

            bool emailExists = await _context.Users
                .AnyAsync(u => u.Email!.ToLower() == newUser.Email!.ToLower());
            if (emailExists)                      return Conflict("Email already exists.");

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Point to GetById so Location header is correct
            return CreatedAtRoute("GetUserById", new { id = newUser.Id }, newUser);
        }

        // ──────────────────────────────── UPDATE (full)
        // PUT: api/user/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, User updated)
        {
            if (!ModelState.IsValid)              return BadRequest(ModelState);
            if (id != updated.Id)                 return BadRequest("ID mismatch.");

            var existing = await _context.Users.FindAsync(id);
            if (existing is null)                 return NotFound();

            // simple field-by-field update
            existing.FirstName = updated.FirstName;
            existing.LastName  = updated.LastName;
            existing.Email     = updated.Email;
            existing.Phone     = updated.Phone;

            await _context.SaveChangesAsync();
            return NoContent();                    // 204 – standard for PUT success
        }

        // ──────────────────────────────── DELETE
        // DELETE: api/user/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)                     return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
