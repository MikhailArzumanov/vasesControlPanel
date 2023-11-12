using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vaseApi.Models;
using vaseApi.Utils;
using vaseApi.Data;

namespace vaseApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CorsAllowAny")]
    public class GenusesController : ControllerBase {
        private ApplicationContext db;
        private IConfiguration config;

        const string GENUS_NOT_FOUND = "Вид не найден.";

        public GenusesController(ApplicationContext context, IConfiguration config) {
            this.db = context;
            this.config = config;
        }

        
        [HttpGet("list")]
        public IActionResult GetList() {
            var entries = db.Genuses;
            return Ok(entries);
        }
        [HttpGet("{id}")]
        public IActionResult GetConcrete(int id) {
            var entry = db.Genuses.FirstOrDefault(x => x.Id == id);
            if (entry == null) return NotFound(GENUS_NOT_FOUND);
            return Ok(entry);
        }

        [HttpPost]
        public IActionResult AddEntry([FromBody] Genus entry) {
            db.Genuses.Add(entry);
            db.SaveChanges();
            return Ok(entry);
        }

        [HttpPut("{id}")]
        public IActionResult RedactEntry([FromRoute] int id, [FromBody] Genus genus) {
            var entry = db.Genuses.FirstOrDefault(x => x.Id == id);
            if (entry == null) return NotFound(GENUS_NOT_FOUND);
            entry.Name = genus.Name;
            entry.Description = genus.Description;
            entry.HtmlMarkup = genus.HtmlMarkup;
            entry.MarkdownText = genus.MarkdownText;
            db.Genuses.Update(entry);
            db.SaveChanges();
            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEntry([FromRoute] int id) {
            var entry = db.Genuses.FirstOrDefault(x => x.Id == id);
            if (entry == null) return NotFound(GENUS_NOT_FOUND);
            db.Genuses.Remove(entry);
            return Ok(entry);
        }
    }
}
