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
    public class MesuresController : SuperController<Mesure>
    {
        public MesuresController(AdminContext context) : base(context) { }

        [HttpPost]
        // public async Task<IActionResult> SearchAndGetOld(Model model)
        // {
            // int idUser = HttpContext.GetIdUser();
            // int role = HttpContext.GetRoleUser();
            // bool hasAcess = (role == 1 || role == 4) ? true : false;

            // var query = _context.Mesures
            //     // .Where(e => hasAcess ? true : (e.User.IdOrganisme == idOrganisme))
            //     // this filter = , المخطط التنفيدي   المخطط التنفيدي الترابي    برامج العمل
            //     .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)

            //     .Where(e => model.IdCycle == 0 ? true : e.IdCycle == model.IdCycle)
            //     .Where(e => model.IdMesure == 0 ? true : e.Id == model.IdMesure)
            //     .Where(e => model.IdResponsable == 0 ? true : e.IdResponsable == model.IdResponsable)
            //     .Where(e => model.IdAxe == 0 ? true : e.IdAxe == model.IdAxe)
            //     .Where(e => model.IdSousAxe == 0 ? true : e.IdSousAxe == model.IdSousAxe)
            //     .Where(e => model.IdOrganisme == 0 ? true : e.Responsable.IdOrganisme == model.IdOrganisme)
            //     // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
            //     ;

            // int count = model.IsAllEmpty() ? await _context.Mesures.CountAsync() : await query.CountAsync();

            // var list = await query.OrderByName<Mesure>(model.SortBy, model.SortDir == "desc")
            //     .Skip(model.StartIndex)
            //     .Take(model.PageSize)
            //     // .Include(e => e.Responsable)
            //     // .ThenInclude(e => e.Organisme)
            //     .Include(e => e.Cycle)
            //     .Select(e => new
            //     {
            //         id = e.Id,
            //         cycle = e.Cycle,
            //         organisme = e.Responsable.Organisme,
            //         nom = e.Nom,
            //         responsable = e.Responsable,
            //         resultatsAttendu = e.ResultatsAttendu,
            //         type = e.Responsable.Organisme.Type
            //     })
            //     .ToListAsync();
            // ;

            // return Ok(new { list = list, count = count });
        //}

        [HttpPost]
        public async Task<IActionResult> SearchAndGet(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Mesures
                .Where(e => e.ActiviteMesures  != null)
                .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => hasAcess ? true : e.Responsables.Any(r => r.IdUser == idUser))
                .Where(e => model.IdCycle == 0 ? true : e.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Id == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Responsables.Any(o => o.IdUser == model.IdResponsable))
                .Where(e => model.IdAxe == 0 ? true : e.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.IdSousAxe == model.IdSousAxe)
                .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                
                .Where(e => model.CodeMesure == "" ? true : e.Code == model.CodeMesure)
                .Where(e => model.NomMesure == "" ? true : e.Nom.Contains(model.NomMesure))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => model.SituationMesure == "" ? true : model.SituationMesure == "غير منجز" ? e.Realisations.All(f => f.TauxRealisation == 0) : model.SituationMesure == "منجز" ? e.Realisations.All(f => f.TauxRealisation == 100): e.Realisations.All(f => f.TauxRealisation > 0 && f.TauxRealisation < 100) )


                .Include(e => e.Realisations).ThenInclude(e => e.Activite)

                ;

            int count = model.IsAllEmpty() ? await _context.Mesures.CountAsync() : await query.CountAsync();


            var countActivite = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                 .Where(e => model.IdOrganisme == 0 ? true : e.Mesure.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))

                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => model.SituationMesure == "" ? true : model.SituationMesure == "غير منجز" ? e.TauxRealisation == 0 : model.SituationMesure == "منجز" ? e.TauxRealisation == 100: e.TauxRealisation > 0 && e.TauxRealisation < 100 )
                .Count();

                

            var list = await query.OrderByName<Mesure>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                .Select(e => new
                {
                    id = e.Id,
                    mesure = e.Nom,
                    realisations = e.Realisations,
                    tauxTotal = e.Realisations.Average(f => f.TauxRealisation),

                    
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count , countActivite = countActivite});
        }






        [HttpPost]
        public async Task<IActionResult> GetDataAxes(Model model)
        {

            var countMesure = _context.Mesures.Count();
            var countActivite = _context.Activites.Count();

            var list = await _context.Axes
                //  .Include(e => e.SousAxes)
                //  .Include(e => e.Mesures)
                //  .ThenInclude(e => e.ActiviteMesures)
                //  .Include(e => e.Mesures).ThenInclude(e => e.Realisations)

                .Select(e => new
                {
                    axe = e.Label,
                    nbrSousAxe = e.SousAxes.Count(),
                    nbrMesure = e.Mesures.Count(),
                    pourcentageMesure = e.Mesures.Count() * 100 / countMesure,
                    nbrActivite = e.Mesures.SelectMany(o => o.ActiviteMesures.Select(t => t.Activite)).Count(),
                    pourcentageActivite = e.Mesures.SelectMany(o => o.ActiviteMesures.Select(t => t.Activite)).Count() * 100 / countActivite,
                    pourcentageRealisationMesureRealise = e.Mesures.SelectMany(o => o.Realisations.Where(t => t.TauxRealisation == 100)).Count() * 100 / e.Mesures.SelectMany(o => o.Realisations).Count() ,
                    pourcentageRealisationMesureEncour = e.Mesures.SelectMany(o => o.Realisations.Where(t => t.TauxRealisation > 0 && t.TauxRealisation <100)).Count() * 100 / e.Mesures.SelectMany(o => o.Realisations).Count() ,
                    pourcentageRealisationMesureNonRealie = e.Mesures.SelectMany(o => o.Realisations.Where(t => t.TauxRealisation == 0)).Count() * 100 / e.Mesures.SelectMany(o => o.Realisations).Count(),

                })
                .ToListAsync();
            ;
            return Ok(new { list = list});
        }


         [HttpPost]
        public async Task<IActionResult> GetDataSousAxes(Model model)
        {

            var countMesure = _context.Mesures.Count();
            var countActivite = _context.Activites.Count();

            var list = await _context.SousAxes
               

                .Select(e => new
                {
                    sousAxe = e.Label,
                    nbrMesure = e.Mesures.Count(),
                    pourcentageMesure = e.Mesures.Count() * 100 / countMesure,
                    nbrActivite = e.Mesures.SelectMany(o => o.ActiviteMesures.Select(t => t.Activite)).Count(),
                    pourcentageActivite = e.Mesures.SelectMany(o => o.ActiviteMesures.Select(t => t.Activite)).Count() * 100 / countActivite,
                    pourcentageRealisationMesureRealise = e.Mesures.SelectMany(o => o.Realisations.Where(t => t.TauxRealisation == 100)).Count() * 100 / e.Mesures.SelectMany(o => o.Realisations).Count() ,
                    pourcentageRealisationMesureEncour = e.Mesures.SelectMany(o => o.Realisations.Where(t => t.TauxRealisation > 0 && t.TauxRealisation <100)).Count() * 100 / e.Mesures.SelectMany(o => o.Realisations).Count() ,
                    pourcentageRealisationMesureNonRealie = e.Mesures.SelectMany(o => o.Realisations.Where(t => t.TauxRealisation == 0)).Count() * 100 / e.Mesures.SelectMany(o => o.Realisations).Count(),

                })
                .ToListAsync();
            ;
            return Ok(new { list = list});
        }






        [HttpPost]
        public  async Task<IActionResult> PourcentageParSituation(string situation)
        {
            try
            { 
               
            var q = _context.Realisations
            .Where(e => e.Situation == situation)
                ;
            var list = await q
                .GroupBy(e => e.Situation)
                 .Select(e => new
                {
                    name = e.Key,
                    value = e.Sum(s => s.TauxRealisation),
                    value1 = e.Average(s => s.TauxRealisation),
                })

                .ToListAsync()
                ;

            return Ok(list);

            }
            catch(Exception ex){throw ex;}
        }


        [HttpPost]
        public async Task<IActionResult> SearchAndGetOld(Model model)
        {
            // int idUser = HttpContext.GetIdUser();
            // int role = HttpContext.GetRoleUser();
            // bool hasAcess = (role == 1 || role == 4) ? true : false;

            var query = _context.Responsables
                // .Where(e => hasAcess ? true : (e.User.IdOrganisme == idOrganisme))
                // this filter = , المخطط التنفيدي   المخطط التنفيدي الترابي    برامج العمل
                .Where(e => e.Organisme.Type == model.TypeOrganisme)

                .Where(e => model.IdCycle == 0 ? true : e.Mesure.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Mesure.Id == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Mesure.Responsables.Any(o => o.IdUser == model.IdResponsable))
                .Where(e => model.IdAxe == 0 ? true : e.Mesure.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.Mesure.IdSousAxe == model.IdSousAxe)
                .Where(e => model.IdOrganisme == 0 ? true : e.Mesure.Responsables.Any(o => o.IdOrganisme == model.IdOrganisme))
                // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                ;

            var list = await query
                .OrderByName<Responsable>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                //.Include(e => e.Responsable)
                //.Include(e => e.Organisme)
                //.Include(e => e.Mesure.Cycle)
                //.Include(e => e.User)
                .Select(e => new
                {
                    id = e.Mesure.Id,
                    cycle = e.Mesure.Cycle,
                    organisme = e.Organisme.Label,
                    nom = e.Mesure.Nom,
                    responsable = e.User.Nom + " "+ e.User.Prenom,
                    resultatsAttendu = e.Mesure.ResultatsAttendu,
                    type = e.Organisme.Type
                })
                .OrderBy(e => e.organisme)
                .ToListAsync();
            ;


            int count =  await _context.Mesures.Where(e => e.Responsables.Any(r => r.Organisme.Type == model.TypeOrganisme)).Distinct().CountAsync() ;

            return Ok(new { list = list, count = count });
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneWithInclude(int id)
        {
            var model = await _context.Mesures.Where(e => e.Id == id)
                .Include(e => e.ActiviteMesures)
                .Include(e => e.IndicateurMesures)
                .ThenInclude(e => e.Indicateur)
                .Include(e => e.Responsables)
                .ThenInclude(e => e.Organisme)
                .Include(e => e.Cycle)
                .Include(e => e.Axe)
                .Include(e => e.SousAxe)
                .Include(e => e.Partenariats)
                .ThenInclude(e => e.Organisme)
                .FirstOrDefaultAsync();
                ;

            return Ok(model);
        }

         [HttpGet("{idCycle}/{name}")]
        public async Task<IActionResult> CustomAutocomplete([FromRoute] int idCycle,[FromRoute] string name)
        {

            return Ok(await _context.Mesures
                .Where(e => e.IdCycle == idCycle && e.Nom.Contains(name))
                .Take(10)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByForeignKey(int id)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;
            var model = await _context.Mesures
                .Where(e => hasAcess ? true : (e.Responsables.Any(o => o.User.Id == idUser)))
                .Where(e => e.IdCycle == id)
                .ToListAsync();
                ;

            return Ok(model);
        }


       


        //  [HttpGet("{id}")]
        // public async Task<IActionResult> GetByTypeOrganisme(int id)
        // {
        //     var model = await _context.Mesures.Where(e => e.Responsable.Organisme.Type == id)
        //             .Select(e => new { id = e.Id, nom = e.Nom })
        //             .ToListAsync()
        //             ;

        //     return Ok(model);
        // }
    }

    public class Model
    {
        public int IdCycle { get; set; }
        public int IdMesure { get; set; }
        public int IdResponsable { get; set; }
        public int IdAxe { get; set; }
        public int IdSousAxe { get; set; }
        public int IdOrganisme { get; set; }
        public int TypeOrganisme { get; set; }
        public string CodeMesure { get; set; }
        public string NomMesure { get; set; }
        public string Situation { get; set; }
        public string SituationMesure { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortDir { get; set; }

        public bool IsAllEmpty()
        {
            if (IdSousAxe == 0 && IdMesure == 0 && IdAxe == 0 && IdCycle == 0 && IdResponsable == 0 && TypeOrganisme == 0 && IdOrganisme == 0 && CodeMesure == null && NomMesure == null && Situation == "") 
            {
                return true;
            }

            return false;
        }
    }
}
