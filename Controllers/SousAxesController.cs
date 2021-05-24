using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SousAxesController : SuperController<SousAxe>
    {
        public SousAxesController(AdminContext context) : base(context)
        {
        }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}")]
        public override async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir)
        {
            var tableName = "SousAxes";
            var list = await _context.SousAxes
                .FromSqlRaw($"SELECT * FROM dbo.[{tableName}] order by {sortBy} {sortDir} OFFSET {startIndex} ROWS FETCH NEXT {pageSize} ROWS ONLY")
                // .FromSqlRaw(@"SELECT * FROM dbo.[{0}] ORDER BY {1} '{2}' OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY"
                // , tableName, sortBy, sortDir, startIndex, pageSize)
                // .Skip(startIndex)
                // .Take(pageSize)
                .Include(e => e.Axe)
                .ToListAsync();

            int count = await _context.SousAxes.CountAsync();


            return Ok(new { list = list, count = count });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SousAxe>>> GetByIdAxe(int id)
        {
            return Ok(await _context.SousAxes.Where(e => e.IdAxe == id).ToListAsync());
        }


        [HttpGet("{idAxe}/{idSousAxe}")]
        public async Task<IActionResult> StateSousAxesDetails(int idAxe, int idSousAxe) 
        {

           
                var q = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => idAxe == 0 ? true : e.Mesure.IdAxe == idAxe)
                .Where(e => idSousAxe == 0 ? true : e.Mesure.IdSousAxe == idSousAxe)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.SousAxe)
                ;

            var list = await q.ToListAsync();
            var list2 = list
                .GroupBy(e=>e.Mesure.SousAxe.Label)
                .Select(e => new
                {
                    name = e.Key,
                    p = 0,
                    r = e.Where(s => s.Mesure.Realisations.All(f => f.TauxRealisation == 100)).Count(),
                    c = e.Where(s => s.Mesure.Realisations.Any(f => f.TauxRealisation < 100 && s.TauxRealisation > 0)).Count(),
                    n = e.Where(s => s.Mesure.Realisations.All(f => f.TauxRealisation == 0)).Count(),
                    
                    // // t = count,
                    t = e.Count(),
                })
                .ToList()
                ;
             return Ok(list2);
        }

        public class ModelDetails
    {
      
        public int IdAxeDetails { get; set; }
        public int IdSousAxeDetails { get; set; }
    

        public bool IsAllEmpty()
        {
            if (IdAxeDetails == 0 && IdSousAxeDetails == 0) 
            {
                return true;
            }

            return false;
        }
    }



        
    }
}
