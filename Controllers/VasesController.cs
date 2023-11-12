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
    public class VasesController : ControllerBase {
        private ApplicationContext db;
        private IConfiguration config;

        const string VASE_NOT_FOUND = "Горшок не найден.";

        public VasesController(ApplicationContext context, IConfiguration config) {
            this.db = context;
            this.config = config;
        }

        private static void SetParameters(Vase dest, Vase src) {
            dest.Autowatering         = src.Autowatering        ;
            dest.WateringIntensity    = src.WateringIntensity   ;
            dest.Autofertilizeing     = src.Autofertilizeing    ;
            dest.FertilizingIntensity = src.FertilizingIntensity;
            dest.IsLightingToggled    = src.IsLightingToggled   ;
            dest.LightingIntensity    = src.LightingIntensity   ;
            dest.GlassOpacity         = src.GlassOpacity        ;
        }

        [HttpGet("list")]
        public IActionResult GetList() {
            var vases = db.Vases.Include(x => x.MainColor)
                .Include(x => x.SideColor).Include(x => x.FlowerGenus);
            return Ok(vases);
        }

        [HttpGet("{id}")]
        public IActionResult GetConcrete([FromRoute] int id) {
            var vase = db.Vases.Include(x => x.MainColor).Include(x => x.SideColor)
                .Include(x => x.FlowerGenus).FirstOrDefault(x => x.Id == id);
            if (vase == null) return NotFound(VASE_NOT_FOUND);
            return Ok(vase);
        }

        [HttpPost]
        public IActionResult AddVase([FromBody] Vase vase) {
            db.Vases.Add(vase);
            db.SaveChanges();
            return Ok(vase);
        }

        [HttpPut("{id}")]
        public IActionResult RedactVase([FromRoute] int id, [FromBody] Vase request) {
            var vase = db.Vases.Include(x => x.MainColor).Include(x => x.SideColor)
                .Include(x => x.FlowerGenus).FirstOrDefault(x => x.Id == id);
            if (vase == null) return NotFound(VASE_NOT_FOUND);
            vase.Name = request.Name;
            vase.WateredLevel   = request.WateredLevel   ;
            vase.MainColorId    = request.MainColorId    ;
            vase.SideColorId    = request.SideColorId    ;
            vase.FlowerGenusId  = request.FlowerGenusId  ;
            vase.Commentary     = request.Commentary     ;
            vase.VaseCondition  = request.VaseCondition  ;
            vase.LastRepairDate = request.LastRepairDate ;
            vase.MountingDate   = request.MountingDate   ;
            vase.LastWatering   = request.LastWatering   ;
            vase.VaseWeight     = request.VaseWeight     ;

            SetParameters(vase, request);

            db.Vases.Update(vase);
            db.SaveChanges();
            return Ok(vase);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVase([FromRoute] int id) {
            var vase = db.Vases.Include(x => x.MainColor).Include(x => x.SideColor)
                .Include(x => x.FlowerGenus).FirstOrDefault(x => x.Id == id);
            if (vase == null) return NotFound(VASE_NOT_FOUND);
            db.Vases.Remove(vase);
            db.SaveChanges();
            return Ok(vase);
        }

        [HttpPatch("{id}")]
        public IActionResult ChangeParameters([FromRoute] int id, [FromBody] Vase request) {
            var vase = db.Vases.Include(x => x.MainColor).Include(x => x.SideColor)
                .Include(x => x.FlowerGenus).FirstOrDefault(x => x.Id == id);
            if (vase == null) return NotFound(VASE_NOT_FOUND);

            SetParameters(vase, request);

            db.Vases.Update(vase);
            db.SaveChanges();
            return Ok(vase);
        }
    }
}
