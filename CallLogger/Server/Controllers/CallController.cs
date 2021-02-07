using CallLogger.Server.Data;
using CallLogger.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallLogger.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CallController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /call?user="{user}"
        [HttpGet]
        public IEnumerable<Call> Get([FromQuery] string user)
        {
            return this._context.Calls
                .Where(x => !x.IsDeleted && x.User == user)
                .OrderByDescending(x => x.StartTime)
                .ToList();
        }

        // GET /call/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var call = await this._context.Calls.FindAsync(id);

            if (call == null || call.IsDeleted == true)
            {
                return NotFound();
            }

            return new JsonResult(call);
        }

        // POST /call
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Call call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            call.CreatedAt = DateTime.Now;

            await this._context.Calls.AddAsync(call);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = call.Id }, call);
        }

        // PUT /call/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Call editedCall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var call = await this._context.Calls.FindAsync(id);

            if (call == null)
            {
                return BadRequest();
            }

            if (editedCall.User != call.User)
            {
                return BadRequest();
            }

            call.ContactId = editedCall.ContactId;
            call.Platform = editedCall.Platform;
            call.StartTime = editedCall.StartTime;
            call.Status = editedCall.Status;
            call.EndTime = editedCall.EndTime;

            call.ModifiedAt = DateTime.Now;

            await this._context.SaveChangesAsync();
            return Ok();
        }

        // DELETE /call/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var call = await this._context.Calls.FindAsync(id);

            if (call == null)
            {
                return BadRequest();
            }

            call.IsDeleted = true;
            call.DeletedAt = DateTime.Now;

            await this._context.SaveChangesAsync();
            return Ok();
        }
    }
}
