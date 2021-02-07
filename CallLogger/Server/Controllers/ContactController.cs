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
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /contact?user={user}
        [HttpGet]
        public IEnumerable<Contact> Get([FromQuery] string user)
        {
            return this._context.Contacts
                .Where(x => !x.IsDeleted && x.User == user)
                .OrderByDescending(x => x.IsFavorite)
                .ToList();
        }

        // GET /contact/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await this._context.Contacts.FindAsync(id);

            if (contact == null || contact.IsDeleted == true)
            {
                return NotFound();
            }

            return new JsonResult(contact);
        }

        // POST /contact
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            contact.CreatedAt = DateTime.Now;

            await this._context.Contacts.AddAsync(contact);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        // PUT /contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact editedContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contact = await this._context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return BadRequest();
            }

            if (editedContact.User != contact.User)
            {
                return BadRequest();
            }

            contact.Name = editedContact.Name;
            contact.MessengerName = editedContact.MessengerName;
            contact.PhoneNumber = editedContact.PhoneNumber;
            contact.DiscordName = editedContact.DiscordName;
            contact.IsFavorite = editedContact.IsFavorite;

            contact.ModifiedAt = DateTime.Now;

            await this._context.SaveChangesAsync();
            return Ok();
        }

        // DELETE /contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await this._context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return BadRequest();
            }

            contact.IsDeleted = true;
            contact.DeletedAt = DateTime.Now;

            await this._context.SaveChangesAsync();
            return Ok();
        }
    }
}
