using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AxesController : SuperController<Axe>
    {
        public AxesController(AdminContext context) : base(context)
        { }

        [HttpGet("{type}")]
        public async Task<IActionResult> StateAxes(int type) 
        {

            
            var q = _context.Realisations.Where(e => e.Activite.Mesure.Axe != null)
                .Where(e => e.Activite.Mesure.Responsable.Organisme.Type == type)
                //.Where(e => e.Activite.Mesure.IdType.Organisme.Type == type)
                //.Where(e => e.Id == 1)
                .Include(e => e.Activite.Mesure.Axe)
                ;

            var list = await q.ToListAsync();
            // var count = await q.CountAsync();
            var list2 = list
                .GroupBy(e=>e.Activite.Mesure.Axe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    p = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0).Count(),
                    r = e.Where(s => s.TauxRealisation == 100).Count(),
                    n = e.Where(s => s.TauxRealisation == 0).Count(),
                    // // t = count,
                    t = e.Count(),
                })
                .ToList()
                ;

            return Ok(list2);
        }
        
    }
}
