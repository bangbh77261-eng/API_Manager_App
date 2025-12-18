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
    public class LevelUsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LevelUsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LevelUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelUser>>> GetLevelUser()
        {
            return await _context.LevelUser.ToListAsync();
        }

        // GET: api/LevelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelUser>> GetLevelUser(int id)
        {
            var levelUser = await _context.LevelUser.FindAsync(id);

            if (levelUser == null)
            {
                return NotFound();
            }

            return levelUser;
        }

        // PUT: api/LevelUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevelUser(int id, LevelUser levelUser)
        {
            if (id != levelUser.LevelID)
            {
                return BadRequest();
            }

            _context.Entry(levelUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelUserExists(id))
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

        // POST: api/LevelUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LevelUser>> PostLevelUser(LevelUser levelUser)
        {
            _context.LevelUser.Add(levelUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevelUser", new { id = levelUser.LevelID }, levelUser);
        }

        // DELETE: api/LevelUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevelUser(int id)
        {
            var levelUser = await _context.LevelUser.FindAsync(id);
            if (levelUser == null)
            {
                return NotFound();
            }

            _context.LevelUser.Remove(levelUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LevelUserExists(int id)
        {
            return _context.LevelUser.Any(e => e.LevelID == id);
        }
    }
}
