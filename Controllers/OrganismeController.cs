using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Providers;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganismeController : SuperController<Organisme>
    {
        public OrganismeController(AdminContext context) : base(context)
        { }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            var model = await _context.Organismes.Where(e => e.Partenariats.Any(o => o.IdMesure == id))
            .ToListAsync();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponsableByForeignKey(int id)
        {
            var model = await _context.Organismes.Where(e => e.Responsables.Any(o => o.IdMesure == id))
            .ToListAsync();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByType(int id)
        {
            var model = await _context.Organismes.Where(e => e.Type == id)
                    .Select(e => new { id = e.Id, label = e.Label })
                    .ToListAsync()
                    ;

            return Ok(model);
        }

        
        [HttpGet("{searchText}")]
        public virtual async Task<IActionResult> GetDataFiltre(string searchText)
        {
            var list = await _context.Organismes
                .Where(e => e.Label.Contains(searchText))
                .ToListAsync()
                ;
            int count = await _context.Organismes.CountAsync();

            return Ok(new { list = list, count = count });
        }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}")]
        public virtual async Task<IActionResult> GetListByType(int startIndex, int pageSize, string sortBy, string sortDir, int type)
        {
            var list = await _context.Organismes.Where(e => e.Type == type)
                .ToListAsync()
                ;
            int count = await _context.Organismes.CountAsync();

            return Ok(new { list = list, count = count });
        }


        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public virtual async Task<IActionResult> GetResponsableByMesure(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
            var list = await _context.Responsables
            .Where(e => e.IdMesure == id)
            //.OrderByName<Organisme>(sortBy, sortDir == "desc")
            .Skip(startIndex)
            .Take(pageSize)
             .Select(e => new 
                {
                idUser = e.IdUser,
                user = e.User.Nom + ' ' + e.User.Prenom,
                idOrganisme = e.IdOrganisme,
                organisme = e.Organisme.Label,
                idMesure = e.IdMesure,

                })
            .ToListAsync();

            int count = await _context.Organismes.Where(e => e.Responsables.Any(o => o.IdMesure == id)).CountAsync();
            return Ok(new { list = list, count = count });

           // return Ok(model);
        }

        // [HttpPost]
        // public async Task<IActionResult> SearchAndGet(Model model)
        // {
            
        //     var query = _context.Organismes
        //         .Where(e => e.Type == model.TypeOrganisme)
        //         .Where(e => model.IdCycle == 0 ? true : e.Responsables.Any(m => m.Mesure.IdCycle == model.IdCycle))
        //         .Where(e => model.IdResponsable == 0 ? true : e.Responsables.Any(m => m.Mesure.Responsables.Any(o => o.IdUser == model.IdResponsable)))
        //         .Where(e => model.IdAxe == 0 ? true : e.Responsables.Any(m => m.Mesure.IdAxe == model.IdAxe))
        //         .Where(e => model.IdSousAxe == 0 ? true : e.Responsables.Any(m => m.Mesure.IdSousAxe == model.IdSousAxe))
        //         .Where(e => model.IdOrganisme == 0 ? true : e.Responsables.Any(m => m.Mesure.Responsables.Any(o => o.IdOrganisme == model.IdOrganisme)))
        //         ;

        //     var list = await query
        //         .OrderByName<Organisme>(model.SortBy, model.SortDir == "desc")
        //         .Skip(model.StartIndex)
        //         .Take(model.PageSize)
               
        //         .Select(e => new
        //         {
        //             id = e.Id,
        //             cycle = e.Responsables.Select(m => m.Mesure.Cycle),
        //             organisme = e.Label,
        //             type = e.Type
        //         })
        //         .OrderBy(e => e.organisme)
        //         .ToListAsync();
        //     ;


        //     int count =  await _context.Mesures.Where(e => e.Responsables.Any(r => r.Organisme.Type == model.TypeOrganisme)).Distinct().CountAsync() ;

        //     return Ok(new { list = list, count = count });
        // }
        [HttpPost]
        public async Task<IActionResult> SearchAndGet(Model model)
        {
            
            var query = _context.Organismes
                .Where(e => e.Type == model.TypeOrganisme)
                .Where(e => e.Responsables.Any(f => f.Mesure != null))
                .Include(e => e.Responsables).ThenInclude(e => e.Mesure)
                .Include(e => e.Responsables).ThenInclude(e => e.User)
                

                // .Where(e => model.IdCycle == 0 ? true : e.Responsables.Any(m => m.Mesure.IdCycle == model.IdCycle))
                // .Where(e => model.IdResponsable == 0 ? true : e.Responsables.Any(m => m.Mesure.Responsables.Any(o => o.IdUser == model.IdResponsable)))
                // .Where(e => model.IdAxe == 0 ? true : e.Responsables.Any(m => m.Mesure.IdAxe == model.IdAxe))
                // .Where(e => model.IdSousAxe == 0 ? true : e.Responsables.Any(m => m.Mesure.IdSousAxe == model.IdSousAxe))
                // .Where(e => model.IdOrganisme == 0 ? true : e.Responsables.Any(m => m.Mesure.Responsables.Any(o => o.IdOrganisme == model.IdOrganisme)))
                ;

            var list = await query

                .OrderByName<Organisme>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
               
                .Select(e => new
                {
                    id = e.Id,
                    idMesure = e.Id,
                    cycle = "2018 - 2021",
                    organisme = e.Label,
                    idOrganisme = e.Id,
                    type = e.Type,
                    responsables = e.Responsables, 
                })
                .OrderBy(e => e.id)
                .ToListAsync();
            ;


            int count =  await _context.Organismes.Where(e => e.Type == model.TypeOrganisme).Distinct().CountAsync() ;
            int countMesures =  await _context.Mesures.Where(e => e.Responsables.Any(o => o.Organisme.Type == model.TypeOrganisme)).Distinct().CountAsync() ;

            return Ok(new { list = list, count = count , countMesures = countMesures });
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetInfoResponsable(int id)
        // {
           
        //     return Ok(await _context.Responsables
        //                     .Where(e => e.IdOrganisme == id)
        //                     //.Include(e => e.Responsables)
        //                     //.Include(e => e.Mesures)
        //                     .FirstOrDefaultAsync()
        //                     );
        // }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoResponsable(int id)
        {
            
            return Ok(await _context.Organismes
                            .Where(e => e.Id == id)
                            .Include(e => e.Responsables).ThenInclude(e => e.Mesure)
                            .Include(e => e.Responsables).ThenInclude(e => e.User)
                            
                            .FirstOrDefaultAsync()
                            );
        }


        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        public virtual async Task<IActionResult> GetListPartenaire(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        {
           
            var listIn = await _context.Organismes
                .Where(e => e.Partenariats.Any(p => p.Mesure.Id == id))
                .OrderByName<Organisme>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync()
                ;

            var listOder = await _context.Organismes
                .Where(e => e.Partenariats.Any(p => p.Mesure.Id != id))
                .OrderByName<Organisme>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync()
                ;

            var list = listIn.Union(listOder);
            int count = await _context.Organismes.CountAsync();

            return Ok(new { list = list, count = count });
        }


    }
}