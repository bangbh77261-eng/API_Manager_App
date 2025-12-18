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
    public class ViewControler : ControllerBase
    {
        private readonly AppDbContext _context;

        public ViewControler(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/get user informatio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCompleteInfoView>>> GetUserInfo()
        {
            var data = await _context.UserCompleteInfoViews.ToListAsync();
            foreach (var user in data)
            {
                user.PasswordHash = Convert.ToBase64String(
                    System.Text.Encoding.UTF8.GetBytes(user.PasswordHash + "_ENCODED_2025")
                );
            }
            return Ok(data);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserCompleteInfoView>>> GetUserName(int userId)
        {
            var data = await _context.UserCompleteInfoViews.Where(a=> a.UserID == userId).ToListAsync();
            foreach (var user in data)
            {
                user.PasswordHash = Convert.ToBase64String(
                    System.Text.Encoding.UTF8.GetBytes(user.PasswordHash + "_ENCODED_2025")
                );
            }
            return Ok(data);
        }
    }
}