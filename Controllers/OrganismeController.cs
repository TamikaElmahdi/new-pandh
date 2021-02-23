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

        // [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{id}")]
        // public virtual async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int id)
        // {
        //     // int i = typeof(T).FullName.LastIndexOf('.');
        //     // string tableName = typeof(T).FullName.Substring(i + 1) + "s";

        //     var list = await _context.Activites
        //         .Where(e => e.IdMesure == id)
        //         .OrderByName<Activite>(sortBy, sortDir == "desc")
        //         .Skip(startIndex)
        //         .Take(pageSize)
        //         .ToListAsync()
        //         ;
        //     int count = await _context.Activites.CountAsync();

        //     return Ok(new { list = list, count = count });
        // }



    }
}