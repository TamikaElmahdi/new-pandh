using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResponsablesController  : SuperController<Responsable>
    {
        public ResponsablesController(AdminContext context): base(context) { }

        [HttpPost]
        public async Task<ActionResult> PutRange(ModelListResponsable<Responsable> model)
        {
            try
            {
                _context.Responsables.RemoveRange(model.modelsToDelete);
                
                await _context.Responsables.AddRangeAsync(model.modelsToAdd);
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(new { message = ex.Message });
            }

            return Ok();
        }

        
    }

    

    public class ModelListResponsable<T> {
        public List<T> modelsToDelete { get; set; }
        public List<T> modelsToAdd { get; set; }
    }
}
