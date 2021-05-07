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
        public async Task<IActionResult> StateOrganismeActivite(int type) 
        {

            if(type==0)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)

                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "غير منجز")).Count()*100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    //val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "غير منجز")).Count()) ,
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else if(type==1)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
               
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "عمل متواصل")).Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else 
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                
                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                // .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "منجز")).Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> StateOrganismeMesure(int type) 
        {

            if(type==0)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)

                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "غير منجز")).Count()*100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                   // val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "غير منجز")).Count()),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else if(type==1)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
               
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "عمل متواصل")).Count() * 100 ) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else 
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                
                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                // .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "منجز")).Count() * 100 ) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            
        }




        [HttpGet("{type}")]
        public async Task<IActionResult> StateAxeActivite(int type) 
        {
               

            if(type==0)
            {
                var q = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.Axe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = e.Where(s => s.TauxRealisation == 0).Count() * 100 / e.Count(),
                    //val = (e.Where(s => s.Situation == "غير منجز").Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    //val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.TauxRealisation == 0)).Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    //val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "غير منجز")).Count()) ,
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else if(type==1)
            {
                var q = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.Axe)
                ;

            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy(e=>e.Mesure.Axe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = e.Where(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 ).Count() * 100 / e.Count(),
                    t = e.Count()
                    
                    // // t = count,
                   
                })
                .ToList()
                ;
            return Ok(list2);
            }
            else 
            {
                 var q = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.Axe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.TauxRealisation == 100).Count() * 100) / e.Count(),
                   // val = e.Where(s => s.TauxRealisation == 100).Count() * 100 / e.Count(),
                    //val = (e.Where(s => s.TauxRealisation == 100).Count() * 100) / e.Count(),
                    //val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.TauxRealisation == 100)).Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Count()
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> StateAxeMesure(int type) 
        {

            if(type==0)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)

                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.Axe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.Axe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "غير منجز")).Count()*100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                   // val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "غير منجز")).Count()),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else if(type==1)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.Axe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.Axe.Label)
               
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "عمل متواصل")).Count() * 100 ) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else 
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                
                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.Axe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                // .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.Axe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "منجز")).Count() * 100 ) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            
        }


                [HttpGet("{type}")]
        public async Task<IActionResult> StateSousAxeActivite(int type) 
        {

            if(type==0)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)

                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.SousAxe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.SousAxe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "غير منجز")).Count()*100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    //val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "غير منجز")).Count()) ,
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else if(type==1)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.SousAxe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.SousAxe.Label)
               
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "عمل متواصل")).Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else 
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                
                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.SousAxe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                // .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.SousAxe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "منجز")).Count() * 100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            
        }

        [HttpGet("{type}")]
        public async Task<IActionResult> StateSousAxeMesure(int type) 
        {

            if(type==0)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)

                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.SousAxe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.SousAxe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "غير منجز")).Count()*100) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                   // val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "غير منجز")).Count()),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else if(type==1)
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.SousAxe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.SousAxe.Label)
               
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "عمل متواصل")).Count() * 100 ) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            else 
            {
                    var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                
                 .Include(e => e.Mesure)
                 .ThenInclude(e => e.SousAxe)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                // .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Mesure.SousAxe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    val = (e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.All(s => s.Situation == "منجز")).Count() * 100 ) / e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                }).OrderByDescending(f => f.val)
                .ToList()
                ;
            return Ok(list2);
            }
            
        }


        [HttpGet("{type}/{isHome}")]
        public async Task<IActionResult> StateAxes(int type, int isHome) 
        {

            if(isHome == 0)
            {
                var q = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Where(e => type > 0 ? e.Mesure.TypeMesure == type: true)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.Axe)
                ;

            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy(e=>e.Mesure.Axe.Label)
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
           
            var q = _context.Responsables
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.ActiviteMesures != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => e.Mesure.Realisations != null)
                .Where(e => e.Organisme.TypeHome == type)

                //.Where(e => e.Mesure.Responsables.Any(p => p.Organisme.TypeHome == type))

                 .Include(e => e.Mesure)
                 .Include(e => e.Organisme)
                 .Include(e => e.Mesure.Realisations)
                // .Include(e => e.Mesure.Axe)
                ;
            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy( e=>e.Organisme.Label)
               // .GroupBy( e=>e.Mesure.Responsables.Select(e => e.Organisme.Label))
                .Select(e => new
                {
                    name = e.Key,
                    // p = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 && s.Situation == "في طور الإنجاز")).Count(),
                    // r = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.TauxRealisation == 100)).Count(),
                    // c = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.TauxRealisation < 100 && s.TauxRealisation > 0 && s.Situation == "عمل متواصل")).Count(),
                    // n = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s=>s.TauxRealisation == 0)).Count(),
                    // t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null).Count(),

                    p = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "في طور الإنجاز")).Count(),
                    r = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "منجز")).Count(),
                    c = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "عمل متواصل")).Count(),
                    n = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null && s.Mesure.Realisations.Any(s => s.Situation == "غير منجز")).Count(),
                    t = e.Where(s => s.Mesure.Responsables != null && s.Mesure.Realisations != null ).Count(),
                    

                })
                .ToList()
                ;
            return Ok(list2);

            }
        }

        
        
        [HttpGet("{type}/{typeTable}")]
        public async Task<IActionResult> GenericByRecommendationType( string type, int typeTable) // used 
        {
            //https://stackoverflow.com/questions/57131550/why-cant-i-create-a-listt-of-anonymous-type-in-c
            string lng = Request.Headers["mylang"].FirstOrDefault();
            var list = new[] { new { table = "", value = 0 } }.ToList();
            int recommendationsCount = 0;
           
                recommendationsCount = await _context.Realisations
                
                //.Where(e => e.Mesure.TypeMesure == typeTable)
                .Where(e => e.Activite.ActiviteMesures != null)

                .CountAsync();
                list = await _context.Natures
                    .Select(e => new
                    {
                        table = e.Label,
                        // value = e.Mesures
                        // .Where(e => e.IdAxe == idAxe)
                        // .Where(e => e.Responsable.Organisme.Type == typeTable)
                        //                 .Count() * 100 / recommendationsCount,

                        //value = e.Mesures.ActiviteMesures.Select(t => t.Activite)
                        value = e.Mesures.Select(r => r.ActiviteMesures.Select(t => t.Activite))
                        //.Where(e => e.Any( o => o.ActiviteMesures != null) && e.Any(o => o.ActiviteMesures.Any(r => r.Mesure.IdAxe == idAxe)))
                        //.Where(e => e.Any( o => o.ActiviteMesures != null)  && e.Any(u => u.ActiviteMesures.Any(o=>o.Mesure.TypeMesure == typeTable)))
                        .Count() * 100 / recommendationsCount,

                        //value = 10
                    })
                    .Distinct()
                    .ToListAsync()
                ;
            
            return Ok(list);
        }
      
        
    }
}
