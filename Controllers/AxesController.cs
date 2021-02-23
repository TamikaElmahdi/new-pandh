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

        [HttpGet("{type}/{isHome}")]
        public async Task<IActionResult> StateAxes(int type, int isHome) 
        {

            if(isHome == 0)
            {
                var q = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.TypeMesure == type)
                //.Where(e => e.Activite.Mesure.Responsable.Organisme.Type == type)
                //.Where(e => e.Activite.Mesure.IdType.Organisme.Type == type)
                //.Where(e => e.Id == 1)
                //.Where(e => e.Activite.ActiviteMesures.Any(m => m.Mesure.Responsables.Any(p => p.Organisme.Type == type)))

                //.Include(e => e.Activite.Mesure.Axe)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.Axe)
                ;

            var list = await q.ToListAsync();
            // var count = await q.CountAsync();
            var list2 = list
                .GroupBy(e=>e.Mesure.Axe.Label)
                //.GroupBy(e=>e.Activite.Mesure.Axe.Label)
                //.GroupBy(e=>e.Activite.Mesure.Responsable.Organisme.Type)
                .Select(e => new
                {
                    name = e.Key,
                    p = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 && s.Situation == "في طور الإنجاز").Count(),
                    r = e.Where(s => s.TauxRealisation == 100).Count(),
                    c = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 && s.Situation == "عمل متواصل").Count(),
                    n = e.Where(s => s.TauxRealisation == 0).Count(),
                    
                    // // t = count,
                    t = e.Count(),
                })
                .ToList()
                ;

             return Ok(list2);
            }
            else
            {
            //     var q = _context.Realisations.Where(e => e.Activite.Mesure.Axe != null)
            //     .Where(e => e.Activite.Mesure.Responsable.Organisme.Type == type)
            //     //.Where(e => e.Activite.Mesure.IdType.Organisme.Type == type)
            //     .Include(e => e.Activite.Mesure.Axe)
            //     ;

            // var list = await q.ToListAsync();
            // // var count = await q.CountAsync();
            // var list2 = list
            //     .GroupBy(e=>e.Activite.Mesure.Axe.Label)
            //     //.GroupBy(GetUser(e=>e.Activite.Mesure.IdResponsable))
            //     .Select(e => new
            //     {
            //         name = e.Key,
            //         p = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0).where(s => s.Situation == "في طور الإنجاز").Count(),
            //         r = e.Where(s => s.TauxRealisation == 100).Count(),
            //         n = e.Where(s => s.TauxRealisation == 0).Count(),
            //         // // t = count,
            //         t = e.Count(),
            //     })
            //     .ToList()
            //     ;

            // return Ok(list2);

                var q = _context.Realisations
                // .Where(e => e.Activite.ActiviteMesures != null ? e.Activite.ActiviteMesures.Any(f => f.Mesure.Axe != null) : false)
                // .Where(e => e.Activite.ActiviteMesures != null ? e.Activite.ActiviteMesures.Any(m => m.Mesure.Responsables.Any(p => p.Organisme.Type == type)): false)

                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.TypeMesure == type)
                //.Where(e => e.Mesure.Responsables.Any(p => p.Organisme.Type == type))

                //.Where(e => e.Activite.Mesure.IdType.Organisme.Type == type)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.Axe)
                ;

            var list = await q.ToListAsync();
            // var count = await q.CountAsync();
            var list2 = list
                .GroupBy(e=>e.Mesure.Axe.Label)
                //.GroupBy(e=>e.Activite.Mesure.Responsable.Organisme.Label)
                //.GroupBy(e=> e.Activite.ActiviteMesures.Select(p => p.Mesure.Responsables.Select(p => p.Organisme.Label)))

                .Select(e => new
                {
                    name = e.Key,
                    p = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 && s.Situation == "في طور الإنجاز").Count(),
                    r = e.Where(s => s.TauxRealisation == 100).Count(),
                    c = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 && s.Situation == "عمل متواصل").Count(),
                    n = e.Where(s => s.TauxRealisation == 0).Count(),
                    t = e.Count(),
                })
                .ToList()
                ;

            return Ok(list2);

            }
            
        }

      
        
    }
}
