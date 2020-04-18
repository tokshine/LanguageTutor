using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanguageTutor.Core;
using LanguageTutor.Data;
using Microsoft.AspNetCore.Identity;

namespace LanguageTutor.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly LanguageDbContext _context;
        private readonly UserManager<LanguageUser> _userManager;

        public LanguagesController(LanguageDbContext context, UserManager<LanguageUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Languages
        [HttpGet]
        public  async Task<IEnumerable<LanguageText>> GetLanguageText()
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

            return _context.LanguageText.Where(x => x.User.Id == currentUser.Id).AsEnumerable();
            //return _context.LanguageText;
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageText([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languageText = await _context.LanguageText.FindAsync(id);

            if (languageText == null)
            {
                return NotFound();
            }

            return Ok(languageText);
        }

        // PUT: api/Languages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguageText([FromRoute] int id, [FromBody] LanguageText languageText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languageText.Id)
            {
                return BadRequest();
            }

            _context.Entry(languageText).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageTextExists(id))
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

        // POST: api/Languages
        [HttpPost]
        public async Task<IActionResult> PostLanguageText([FromBody] LanguageText languageText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LanguageText.Add(languageText);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguageText", new { id = languageText.Id }, languageText);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguageText([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var languageText = await _context.LanguageText.FindAsync(id);
            if (languageText == null)
            {
                return NotFound();
            }

            _context.LanguageText.Remove(languageText);
            await _context.SaveChangesAsync();

            return Ok(languageText);
        }

        private bool LanguageTextExists(int id)
        {
            return _context.LanguageText.Any(e => e.Id == id);
        }
    }
}