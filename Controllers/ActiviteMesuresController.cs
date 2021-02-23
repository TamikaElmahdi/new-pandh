using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Providers;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActiviteMesuresController  : SuperController<ActiviteMesure>
    {
        public ActiviteMesuresController(AdminContext context): base(context) { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public virtual async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
            // int i = typeof(T).FullName.LastIndexOf('.');
            // string tableName = typeof(T).FullName.Substring(i + 1) + "s";

            var list = await _context.ActiviteMesures
                .Where(e => e.IdMesure == id)
                .OrderByName<ActiviteMesure>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .Include(e => e.Activite)
                .ToListAsync()
                ;
            int count = await _context.ActiviteMesures.CountAsync();

            return Ok(new { list = list, count = count });
        }

        [HttpPost]
        public async Task<ActionResult> PutRange(ModelListActivite<ActiviteMesure> model)
        {
            try
            {
                _context.ActiviteMesures.RemoveRange(model.modelsToDelete);
                
                await _context.ActiviteMesures.AddRangeAsync(model.modelsToAdd);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(new { message = ex.Message });
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PutActiviteMesure(ActiviteMesure model)
        {
            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return NoContent();
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var list = await _context.ActiviteMesures.Where(e => e.IdMesure == id)
                .Include(e => e.Activite)
                .Select(e => e.Activite)
                .ToListAsync()
                ;

            return Ok(list);
        }

        public class ModelListActivite<T> {
        public List<T> modelsToDelete { get; set; }
        public List<T> modelsToAdd { get; set; }
    }
    }

}
