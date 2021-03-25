using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Providers;
using System.Text.RegularExpressions;
namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RealisationsController  : SuperController<Realisation>
    {
        public RealisationsController(AdminContext context): base(context) { }

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
                
                .Where(e => model.CodeMesure == "" ? true : e.Code == model.CodeMesure)
                .Where(e => model.NomMesure == "" ? true : e.Nom.Contains(model.NomMesure))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))

                .Include(e => e.Realisations).ThenInclude(e => e.Activite)

                ;

            int count = model.IsAllEmpty() ? await _context.Mesures.CountAsync() : await query.CountAsync();

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

            return Ok(new { list = list, count = count });
        }

       


        
        [HttpPost]
        public async Task<IActionResult> SearchAndGetOld(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Realisations
                .Where(e => hasAcess ? true : (e.Activite.ActiviteMesures.Any(r => r.Mesure.Responsables.Any(r => r.IdUser == idUser))))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdMesure == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.Id == model.IdMesure))
                .Where(e => model.IdResponsable == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.Responsables.Any(o => o.IdUser == model.IdResponsable)))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.IdSousAxe == model.IdSousAxe))
                // .Where(e => model.IdOrganisme == 0 ? true : e.Activite.Mesure.IdOrganisme == model.IdOrganisme)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                ;

            int count = model.IsAllEmpty() ? await _context.Realisations.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Realisation>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                .Include(e => e.Activite)
                .Select(e => new
                {
                    id = e.Id,
                    //mesure = e.Activite.Mesure.Nom,
                    mesure = e.Activite.ActiviteMesures.Select(s => s.Mesure.Nom),
                    activite = e.Activite.Nom,
                    annee = e.Annee,
                    nom = e.Nom,
                    situation = e.Situation,
                    //taux = e.Taux,
                    taux = e.TauxRealisation,
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }

         [HttpPost]
        public async Task<IActionResult> GetRapportLiterary(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Realisations
                .Where(e => hasAcess ? true : (e.Activite.ActiviteMesures.Any(r => r.Mesure.Responsables.Any(o => o.IdUser == idUser))))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdMesure == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.Id == model.IdMesure))
                .Where(e => model.IdResponsable == 0 ? true : e.Activite.ActiviteMesures.Any(r => r.Mesure.Responsables.Any(o => o.IdUser == model.IdResponsable)))
                ;

            int count = model.IsAllEmpty() ? await _context.Realisations.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Realisation>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                .Include(e => e.Activite)
                .Select(e => new
                {
                    id = e.Id,
                    //organisme = e.Activite.Mesure.Responsable.Organisme.Label,
                    //mesure = e.Activite.Mesure.Nom,
                    organisme = "e.Activite.ActiviteMesures.Select(p => p.Mesure.Responsables..Organisme.Label),",
                    mesure = e.Activite.ActiviteMesures.Select(p => p.Mesure.Nom),
                    activite = e.Activite.Nom,
                    annee = e.Annee,
                    situation = e.Situation,
                    //taux = e.Taux,
                    taux = e.TauxRealisation,
                    effet = e.Effet,
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }

         [HttpPost]
        public async Task<IActionResult> GetRapportQualitative(Model model)
        {
            int idUser = HttpContext.GetIdUser();
            int role = HttpContext.GetRoleUser();
            bool hasAcess = (role == 1 || role == 2) ? true : false;

            var query = _context.Mesures
                .Where(e => hasAcess ? true : (e.Responsables.Any(o => o.IdUser == idUser)))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Id == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Responsables.Any(o => o.IdUser == model.IdResponsable))
                .Where(e => model.IdAxe == 0 ? true : e.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.IdSousAxe == model.IdSousAxe)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Activite.Mesure.IdOrganisme == model.IdOrganisme)
                // .Where(e => model.IdOrganisme == 0 ? true : e.Partenariats.Any(p => p.IdOrganisme == model.IdOrganisme))
                ;
            int count = model.IsAllEmpty() ? await _context.Realisations.CountAsync() : await query.CountAsync();

            var list = await query.OrderByName<Mesure>(model.SortBy, model.SortDir == "desc")
                .Skip(model.StartIndex)
                .Take(model.PageSize)
                // .Include(e => e.Responsable)
                // .ThenInclude(e => e.Organisme)
                // .Include(e => e.Activite)
                .Select(e => new
                {
                    id = e.Id,
                    organisme = "e.Responsable.Organisme.Label",
                    mesure = e.Nom,
                    //realisations = e.ActiviteMesures.SelectMany(a => a.Realisations.Select(r => r.Nom)),
                    realisations = "dd",
                    //taux = e.Activites.SelectMany(a => a.Realisations.Select(r => r.Taux)),
                    taux = 25,
                    //taux = e.Activites.SelectMany(a => a.Realisations.Select(r => r.TauxRealisation)),
                    // taux = e.ac,
                    indicateurs = e.IndicateurMesures.Select(i => i.Indicateur.Nom),
                })
                .ToListAsync();
            ;
 
            return Ok(new { list = list, count = count });
        }

        private async Task<object> Calc(IQueryable<Realisation> q, int typeTable)
        {

            // int recommendationsCount = _context.Recommendations.Count();

            var t = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
                            
            var n = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 0))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            var r = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 100))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            var p = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "في طور الإنجاز"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            var c = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            
            var epu = new { n, r, p, c, t };

            t = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null)).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            n = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 0)).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            r = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 100)).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            p = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "في طور الإنجاز")).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            c = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل")).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            // var h = t == 0 ? 1 : t;
            // var h2 = 0/1;
            var ot = new { n, r, p, c, t };

            t = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null)).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            n = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 0)).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            r = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 100)).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            p = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "في طور الإنجاز")).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();
            c = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل")).Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))).CountAsync();

            var ps = new { n, r, p, c, t };

            return new { epu, ot, ps, count = 0 };

        }


          [HttpGet("{typeTable}")]
        public async Task<IActionResult> StateMecanisme(int typeTable) // used
        {
            return Ok(await Calc(_context.Realisations, typeTable));
        }

        
        [HttpGet("{table}/{type}/{typeTable}")]
        public async Task<IActionResult> GenericByRecommendation(string table, string type, int typeTable) // used 
        {
            //https://stackoverflow.com/questions/57131550/why-cant-i-create-a-listt-of-anonymous-type-in-c
            string lng = Request.Headers["mylang"].FirstOrDefault();
            var list = new[] { new { table = "", value = 0 } }.ToList();
            int recommendationsCount = 0;
            if (table == "axe")
            {
                // recommendationsCount = await _context.Realisations
                // .Where(r => r.Activite.Mesure.IdCycle != null)
                // .Where(e => e.Activite.Mesure.Responsable.Organisme.Type == typeTable)
                // .CountAsync();
                // list = await _context.Activites
                //     .Select(e => new
                //     {
                //         table = e.Mesure.Axe.Label,
                //         value = e.Realisations.Where(r => r.Activite.Mesure.IdCycle != null)
                //                             .Where(e => e.Activite.Mesure.Responsable.Organisme.Type == typeTable)
                //                             .Count() * 100 / recommendationsCount,
                //     })
                //     .Distinct()
                //     .ToListAsync();


                recommendationsCount = await _context.Realisations
                .Where(r => r.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => o.Organisme.Type == typeTable)))
                .CountAsync();
                list = await _context.Axes
                    .Select(e => new
                    {
                        table = e.Label,
                        value = e.Mesures.Where(r => r.IdCycle != null)
                                        .Where(e => e.Responsables.Any(o => o.Organisme.Type == typeTable))
                                        .Count() * 100 / recommendationsCount,
                    })
                    .Distinct()
                    .ToListAsync();


            }

            else if (table == "sousAxe")
            {
                recommendationsCount = await _context.Realisations
                .Where(r => r.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => o.Organisme.Type == typeTable)))
                .CountAsync();
                list = await _context.SousAxes
                    .Select(e => new
                    {
                        table = e.Label,
                        value = e.Mesures.Where(r => r.IdCycle != null)
                                        .Where(e => e.Responsables.Any(o => o.Organisme.Type == typeTable))
                                        .Count() * 100 / recommendationsCount,
                    })
                    .Distinct()
                    .ToListAsync()
                ;
            }

           

           
            
            return Ok(list);
        }

         [HttpGet("{type}/{typeTable}/{idAxe}")]
        public async Task<IActionResult> GenericByRecommendationSousAxe( string type, int typeTable, int idAxe) // used 
        {
            //https://stackoverflow.com/questions/57131550/why-cant-i-create-a-listt-of-anonymous-type-in-c
            string lng = Request.Headers["mylang"].FirstOrDefault();
            var list = new[] { new { table = "", value = 0 } }.ToList();
            int recommendationsCount = 0;
           
                recommendationsCount = await _context.Mesures
                .Where(e => e.Axe.Id == idAxe)
                .Where(e => e.TypeMesure == typeTable)
                //.Where(e => e.ActiviteMesures != null)
                .CountAsync();
                list = await _context.SousAxes.Where(e => e.IdAxe == idAxe)
                    .Select(e => new
                    {
                        table = e.Label,
                        value = e.Mesures.Count(),
                        //value = e.Mesures.Select( s => s.Realisations.Select(r => r.TauxRealisation)).Count() * 100 / recommendationsCount,
                    })
                    .Distinct()
                    .ToListAsync()
                ;
            
            return Ok(list);
        }



         [HttpGet("{type}/{typeTable}/{idAxe}")]
        public async Task<IActionResult> GenericByRecommendationSousAxeOld( string type, int typeTable, int idAxe) // used 
        {
            //https://stackoverflow.com/questions/57131550/why-cant-i-create-a-listt-of-anonymous-type-in-c
            string lng = Request.Headers["mylang"].FirstOrDefault();
            var list = new[] { new { table = "", value = 0 } }.ToList();
            int recommendationsCount = 0;
           
                recommendationsCount = await _context.Realisations
                //.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdAxe == idAxe))
                //.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => o.Organisme.Type == typeTable)))

                .Where(e => e.Mesure.Axe.Id == idAxe)
                .Where(e => e.Mesure.TypeMesure == typeTable)
                .Where(e => e.Activite.ActiviteMesures != null)

                .CountAsync();
                list = await _context.SousAxes.Where(e => e.IdAxe == idAxe)
                    .Select(e => new
                    {
                        table = e.Label,
                        // value = e.Mesures
                        // .Where(e => e.IdAxe == idAxe)
                        // .Where(e => e.Responsable.Organisme.Type == typeTable)
                        //                 .Count() * 100 / recommendationsCount,

                        value = e.Mesures.Select(o => o.ActiviteMesures.Select(t => t.Activite))
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

       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneWithInclude(int id)
        {
            var model = await _context.Realisations.Where(e => e.Id == id)
                .Include(e => e.Activite)
                .Include(e => e.Mesure)
                // .ThenInclude(e => e.Cycle)
                .FirstOrDefaultAsync();
                ;

            return Ok(model);
        }


        public int getNumber(string text)
        { return 15;
            // string a = text;
            // string b = string.Empty;
            // int val = 0;

            // for (int i=0; i< a.Length; i++)
            // {
            //     if (Char.IsDigit(a[i]))
            //         b += a[i];
            // }

            // if (b.Length>0)
            //     val = int.Parse(b);
            // return val;
            string input = text;
            int number = 0;
            // Split on one or more non-digit characters.
            string[] numbers = Regex.Split(input, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    Console.WriteLine("Number: {0}", i);
                    number = i;
                }
            }
            return 15;
        }

        // [HttpGet("{type}")]
        // public  async Task<IActionResult> PourcentageParAxe(int type)
        // {
        //     try
        //     { 
               
        //     var q = _context.Realisations
        //     .Where(e=>e.Activite.Mesure.IdAxe==type)
        //         ;
        //     var list = await q
        //         .GroupBy(e => e.Activite.Mesure.Axe.Label)
        //          .Select(e => new
        //         {
        //             name = e.Key,

                    
        //             value = e.Average(getNumber(s => s.Taux)),
        //         })

        //         .ToListAsync()
        //         ;

        //     return Ok(list);

        //     }
        //     catch(Exception ex){throw ex;}
        // }
    }

   
}
