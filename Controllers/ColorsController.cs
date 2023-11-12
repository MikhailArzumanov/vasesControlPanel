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
    public class ColorsController : ControllerBase {
        private ApplicationContext db;
        private IConfiguration config;

        const string COLOR_NOT_FOUND = "Цвет не найден.";

        public ColorsController(ApplicationContext context, IConfiguration config) {
            this.db = context;
            this.config = config;
        }

        
        [HttpGet("list")]
        public IActionResult GetList() {
            var colors = db.Colors;
            return Ok(colors);
        }
        [HttpGet("{id}")]
        public IActionResult GetConcrete(int id) {
            var color = db.Colors.FirstOrDefault(x => x.Id == id);
            if (color == null) return NotFound(COLOR_NOT_FOUND);
            return Ok(color);
        }

        [HttpPost]
        public IActionResult AddColor([FromBody] Color entry) {
            db.Colors.Add(entry);
            db.SaveChanges();
            return Ok(entry);
        }

        [HttpPut("{id}")]
        public IActionResult RedactColor([FromRoute] int id, [FromBody] Color color) {
            var entry = db.Colors.FirstOrDefault(x => x.Id == id);
            if (entry == null) return NotFound(COLOR_NOT_FOUND);
            entry.HexRepresentation = color.HexRepresentation;
            entry.Name = color.Name;
            entry.Commentary = color.Commentary;
            db.Colors.Update(entry);
            db.SaveChanges();
            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteColor([FromRoute] int id) {
            var entry = db.Colors.FirstOrDefault(x => x.Id == id);
            if (entry == null) return NotFound(COLOR_NOT_FOUND);
            db.Colors.Remove(entry);
            return Ok(entry);
        }
    }
}
