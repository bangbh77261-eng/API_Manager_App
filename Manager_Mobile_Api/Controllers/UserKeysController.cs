using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Manager_mobile_Api.Data;

namespace Manager_Mobile_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserKeysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserKeysController(AppDbContext context)
        {
            _context = context;
        }     
        // GET: api/UserKeys/
        [HttpGet("{id}")]
        public async Task<ActionResult<UserKey>> GetUserKey(int id)
        {
            var userKey = await _context.UserKey.FindAsync(id);

            if (userKey == null)
            {
                return NotFound();
            }

            return userKey;
        }

        // PUT: api/UserKeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserKey(int id, UserKey userKey)
        {
            if (id != userKey.UserID)
            {
                return BadRequest();
            }

            _context.Entry(userKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserKeyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostUserKey(UserKey userKey)
        {
            bool exists = await _context.UserKey.AnyAsync(u => u.CMND == userKey.CMND);

            if (exists)
                return BadRequest("CMND already exists");

            _context.UserKey.Add(userKey);
            await _context.SaveChangesAsync();
            return Ok(userKey);
        }


        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteUserKey(int id)
        {
            var userKey = await _context.UserKey.FindAsync(id);
            if (userKey == null)
            {
                return NotFound();
            }

            _context.UserKey.Remove(userKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserKeyExists(int id)
        {
            return _context.UserKey.Any(e => e.UserID == id);
        }
    }
}
