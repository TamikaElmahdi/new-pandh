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
    public class IndicateursController  : SuperController<Indicateur>
    {
        public IndicateursController(AdminContext context): base(context) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var model = await _context.Indicateurs.Where(e => e.IndicateurMesures.Any(o => o.IdMesure == id ) )
            .ToListAsync();

            return Ok(model);
        }

        [HttpGet("{searchText}")]
        public virtual async Task<IActionResult> GetDataFiltre(string searchText)
        {
            var list = await _context.Indicateurs
                .Where(e => e.Nom.Contains(searchText))
                .ToListAsync()
                ;
            int count = await _context.Indicateurs.CountAsync();

            return Ok(new { list = list, count = count });
        }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public virtual async Task<IActionResult> GetListIndicateur(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
           
            var listIn = await _context.Indicateurs
                .Where(e => e.IndicateurMesures.Any(p => p.Mesure.Id == id))
                .OrderByName<Indicateur>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync()
                ;

            var listOder = await _context.Indicateurs
                .Where(e => e.IndicateurMesures.Any(p => p.Mesure.Id != id))
                .OrderByName<Indicateur>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync()
                ;

            var list = listIn.Union(listOder);
            int count = await _context.Indicateurs.CountAsync();

            return Ok(new { list = list, count = count });
        }

    }
}
