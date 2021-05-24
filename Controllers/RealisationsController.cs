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
                //.Where(e => model.SituationMesure == "" ? true : model.SituationMesure == "غير منجز" ? e.Realisations.All(f => f.TauxRealisation == 0) : model.SituationMesure == "منجز" ? e.Realisations.All(f => f.TauxRealisation == 100): e.Realisations.All(f => f.TauxRealisation > 0 && f.TauxRealisation < 100) )


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


        private async Task<object> CalcMesure(IQueryable<Mesure> q, int typeTable)
        {

            // int recommendationsCount = _context.Recommendations.Count();

            // var count = _context.Mesures
            //     // .Where(e => e.ActiviteMesures  != null)
            //     // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
            //     .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
            //     .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
            //     .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
            //     .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
            //     .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
            //     .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
            //     .Where(e => (model.SituationMesure == "" || model.SituationMesure == "غير منجز")  && e.Realisations.All(f => f.TauxRealisation == 0) )
            //     .Distinct().Count();
                

            var t = await q.CountAsync();
                            
                            
            var n = await q.Where(e => e.Realisations.All(r => r.TauxRealisation == 0))
                           //.Where(e => e.Realisations.Any( f=>f.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))))
                           .Distinct().CountAsync();

            var r = await q.Where(e => e.Realisations.All(r => r.TauxRealisation == 100))
                           //.Where(e => e.Realisations.Any( f=>f.Activite.ActiviteMesures.Any(f => f.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))))
                           .Distinct().CountAsync();
            
            var c = await q.Where(e => e.Realisations.Any(r => r.TauxRealisation < 100 && r.TauxRealisation > 0 ))
                          // .Where(e => e.Realisations.Any( f=>f.Activite.ActiviteMesures.Any(f => f.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true))))
                           .Distinct().CountAsync();
            
            var epu = new { n, r, c, t };


            return new { epu, count = 0 };

        }



        private async Task<object> CalcByType(IQueryable<Realisation> q, int typeTable, int axe, int type)
        {

            // int recommendationsCount = _context.Recommendations.Count();

            var t = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdAxe == axe))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
                            
            var n = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 0))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdAxe == axe))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            var r = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 100))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdAxe == axe))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            var p = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "في طور الإنجاز"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdAxe == axe))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            var c = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdAxe == axe))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            
            var epu = new { n, r, p, c, t };

           

            return new { epu, count = 0 };

        }


        private async Task<object> CalcByTypeDetails(IQueryable<Realisation> q, int typeTable, int axe, int sousAxe, int type)
        {

            // int recommendationsCount = _context.Recommendations.Count();

            var t = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
                            
            var n = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 0))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            var r = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 100))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            var p = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "في طور الإنجاز"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            var c = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdNature == type))
                            .CountAsync();
            
            var epu = new { n, r, p, c, t };

           

            return new { epu, count = 0 };

        }



         private async Task<object> CalcBySousAxe(IQueryable<Realisation> q, int axe, int sousAxe)
        {

            
               var req = _context.Realisations
                .Where(e => e.Mesure.Axe != null)
                .Where(e => e.Mesure.Responsables != null)
                .Where(e => axe == 0 ? true : e.Mesure.IdAxe == axe)
                .Where(e => sousAxe == 0 ? true : e.Mesure.IdSousAxe == sousAxe)
                .Include(e => e.Mesure)
                .Include(e => e.Mesure.SousAxe)
                ;

            var list = await req.ToListAsync();
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

            var epu = new { list2.FirstOrDefault().n, list2.FirstOrDefault().r, list2.FirstOrDefault().c, list2.FirstOrDefault().t };

             return new { epu, count = 0 };



        }






        private async Task<object> CalcByDepartementDetails(IQueryable<Realisation> q, int typeTable, int axe, int sousAxe, int departement)
        {

            // int recommendationsCount = _context.Recommendations.Count();

            var t = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any( r => r.Organisme.Id == departement)))
                            .CountAsync();
                            
            var n = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 0))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any( r => r.Organisme.Id == departement)))
                            .CountAsync();
            var r = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation == 100))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any( r => r.Organisme.Id == departement)))
                            .CountAsync();
           
            var c = await q.Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null && e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل"))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => typeTable > 0 ? o.Organisme.Type == typeTable : true)))
                           .Where(e => e.Activite.ActiviteMesures.Any(f => axe > 0? f.Mesure.IdAxe == axe: true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => sousAxe > 0 ? f.Mesure.IdSousAxe == sousAxe : true))
                            .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any( r => r.Organisme.Id == departement)))
                            .CountAsync();
            
            var epu = new { n, r, c, t };

           

            return new { epu, count = 0 };

        }


        [HttpGet("{typeTable}")]
        public async Task<IActionResult> StateMecanisme(int typeTable) // used
        {
            return Ok(await Calc(_context.Realisations, typeTable));
        }

        [HttpGet("{typeTable}")]
        public async Task<IActionResult> StateMecanismeMesure(int typeTable) // used
        {
            return Ok(await CalcMesure(_context.Mesures, typeTable));
        }

        [HttpGet("{typeTable}/{axe}/{type}")]
        public async Task<IActionResult> StateMecanismeByType(int typeTable,int axe,int type) // used
        {
            return Ok(await CalcByType(_context.Realisations, typeTable, axe, type));
        }

        [HttpGet("{typeTable}/{axe}/{sousAxe}/{type}")]
        public async Task<IActionResult> StateMecanismeByTypeDetails(int typeTable,int axe,int sousAxe,int type) // used
        {
            return Ok(await CalcByTypeDetails(_context.Realisations, typeTable, axe, sousAxe, type));
        }

        [HttpGet("{axe}/{sousAxe}")]
        public async Task<IActionResult> stateSousAxesDetailsColors(int axe,int sousAxe) // used
        {
            return Ok(await CalcBySousAxe(_context.Realisations, axe, sousAxe));
        }
        

        [HttpGet("{typeTable}/{axe}/{sousAxe}/{type}")]
        public async Task<IActionResult> StateMecanismeByDepartementDetails(int typeTable,int axe,int sousAxe,int type) // used
        {
            return Ok(await CalcByDepartementDetails(_context.Realisations, typeTable, axe, sousAxe, type));
        }

       

        [HttpPost]
        public int GetNbNonTermine(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation == 0).Count();

                var countAll = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation).Count();

                var moyen = ( count * countAll ) / 100;
                return count;
                //return Tuple.Create(count,moyen);


        }

        


        [HttpPost]
        public int GetNbTermine(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation == 100).Count();
                return count;

        }


        [HttpPost]
        public  int GetNbContinue(Model model)
        {
          
            
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل").Count();
                //return count;

                var countAll = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation).Count();

                var moyen = ( count * countAll ) / 100;
                return count;
                //return Tuple.Create(count,moyen);

        }


        [HttpPost]
        public int GetNbEncours(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "في طور الإنجاز").Count();
                return count;

        }

        [HttpPost]
        public int GetNbNonTermineMesure(Model model)
        {
          
             var count = _context.Mesures
                // .Where(e => e.ActiviteMesures  != null)
                // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => (model.SituationMesure == "" || model.SituationMesure == "غير منجز")  && e.Realisations.All(f => f.TauxRealisation == 0) )
                .Distinct().Count();

                var countAll = _context.Mesures.Count();

                var countNull = 0;
                if(model.SituationMesure == "" || model.SituationMesure == "غير منجز")
                {
                    countNull =  countAll - (GetNbTermineMesure(model)+ GetNbEncoursMesure(model) + count);
                     return count + countNull;

                }
                else
                    return count ;
                //return Tuple.Create(count,moyen);
        }

        [HttpPost]
        public int GetNbTermineMesure(Model model)
        {
          
             var count = _context.Mesures
                // .Where(e => e.ActiviteMesures  != null)
                // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => (model.SituationMesure == "" || model.SituationMesure == "منجز")  && e.Realisations.All(f => f.TauxRealisation == 100)).Distinct().Count();
                return count;
                //return Tuple.Create(count,moyen);
        }

         [HttpPost]
        public int GetNbEncoursMesure(Model model)
        {
          
             var count = _context.Mesures
                // .Where(e => e.ActiviteMesures  != null)
                // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => (model.SituationMesure == "" || model.SituationMesure == "عمل متواصل")  && e.Realisations.Any(f => f.TauxRealisation > 0 && f.TauxRealisation < 100)).Distinct().Count();
                return count;
                //return Tuple.Create(count,moyen);
        }

        public int CountAllActivite(Model model)
        {
            var countAll = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation).Count();
                return  countAll;
        }

        [HttpPost]
        public int GetPourcentageNonTermine(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation == 0).Count();
                var moyen = ( count * 100 ) / CountAllActivite(model);
                return moyen;
                //return Tuple.Create(count,moyen);
        }


        [HttpPost]
        public int GetPourcentageTermine(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation == 100).Count();
                var moyen = ( count * 100 ) / CountAllActivite(model);
                return moyen;
                //return Tuple.Create(count,moyen);
        }


        [HttpPost]
        public int GetPourcentageContinue(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation < 100 && e.TauxRealisation > 0 ).Count();
                var moyen = ( count * 100 ) / CountAllActivite(model);
                return moyen;
                //return Tuple.Create(count,moyen);
        }

        [HttpPost]
        public int GetPourcentageEncours(Model model)
        {
          
             var count = _context.Realisations
                .Where(e => e.Activite.ActiviteMesures  != null)
                .Where(e => e.Activite.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" ? true : e.Activite.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Situation == model.Situation)
                .Where(e => e.TauxRealisation < 100 && e.TauxRealisation > 0 && e.Situation == "عمل متواصل").Count();
                var moyen = ( count * 100 ) / CountAllActivite(model);
                return moyen;
                //return Tuple.Create(count,moyen);
        }

        //*******************

        [HttpPost]
        public int GetPourcentageNonTermineMesure(Model model)
        {
          
             var count = _context.Mesures
                // .Where(e => e.ActiviteMesures  != null)
                // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => (model.SituationMesure == "" || model.SituationMesure == "غير منجز")  && e.Realisations.All(f => f.TauxRealisation == 0) )
                .Distinct().Count();

                var countAll = _context.Mesures.Count();

                var countNull = 0;
                if(model.SituationMesure == "" || model.SituationMesure == "غير منجز")
                    countNull =  countAll - (GetNbTermineMesure(model)+ GetNbEncoursMesure(model) + count);
                

                var moyenNull = ( countNull * 100 ) / countAll;
                var moyen = ( count * 100 ) / countAll;
                return moyen + moyenNull;

                //return count + countNull;
                //return Tuple.Create(count,moyen);
        }

        
        [HttpPost]
        public int GetPourcentageTermineMesure(Model model)
        {
          
             var count = _context.Mesures
                // .Where(e => e.ActiviteMesures  != null)
                // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => (model.SituationMesure == "" || model.SituationMesure == "منجز")  && e.Realisations.All(f => f.TauxRealisation == 100)).Distinct().Count();
                var countAll = _context.Mesures.Count();
                
                var moyen = ( count * 100 ) / countAll;
                return moyen;
                //return Tuple.Create(count,moyen);
        }

          [HttpPost]
        public int GetPourcentageEncoursMesure(Model model)
        {
          
             var count = _context.Mesures
                // .Where(e => e.ActiviteMesures  != null)
                // .Where(e => e.ActiviteMesures.Any(f => f.Activite != null))
                .Where(e => model.IdCycle == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdCycle == model.IdCycle))
                .Where(e => model.IdAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdAxe == model.IdAxe))
                .Where(e => model.IdSousAxe == 0 || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.IdSousAxe == model.IdSousAxe))
                
                .Where(e => model.CodeMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Code == model.CodeMesure))
                .Where(e => model.NomMesure == "" || e.ActiviteMesures  == null ? true : e.ActiviteMesures.Any(f=>f.Mesure.Nom.Contains(model.NomMesure)))
                .Where(e => model.Situation == "" ? true : e.Realisations.Any(f => f.Situation == model.Situation))
                .Where(e => (model.SituationMesure == "" || model.SituationMesure == "عمل متواصل")  && e.Realisations.Any(f => f.TauxRealisation > 0 && f.TauxRealisation < 100)).Distinct().Count();
               
                var countAll = _context.Mesures.Count();
                var moyen = ( count * 100 ) / countAll;
                return moyen;
                //return Tuple.Create(count,moyen);
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


                // recommendationsCount = await _context.Realisations
                // // .Where(r => r.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                // // .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => o.Organisme.Type == typeTable)))
                // .CountAsync();
                // list = await _context.Axes
                //     .Select(e => new
                //     {
                //         table = e.Label,
                //         value = e.Mesures
                //                         //.Where(r => r.IdCycle != null)
                //                         //.Where(e => e.Responsables.Any(o => o.Organisme.Type == typeTable))
                //                         .Count() * 100 / recommendationsCount,
                //     })
                //     .Distinct()
                //     .ToListAsync();

                recommendationsCount = await _context.Mesures
                // .Where(r => r.Activite.ActiviteMesures.Any(f => f.Mesure.IdCycle != null))
                // .Where(e => e.Activite.ActiviteMesures.Any(f => f.Mesure.Responsables.Any(o => o.Organisme.Type == typeTable)))
                .CountAsync();
                list = await _context.Axes
                    .Select(e => new
                    {
                        table = e.Label,
                        value = e.Mesures
                                        //.Where(r => r.IdCycle != null)
                                        //.Where(e => e.Responsables.Any(o => o.Organisme.Type == typeTable))
                                        .Count(),
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
           
                // recommendationsCount = await _context.Realisations
                
                // //.Where(e => e.Mesure.TypeMesure == typeTable)
                // .Where(e => e.Activite.ActiviteMesures != null)

                // .CountAsync();
                // list = await _context.Natures
                //     .Select(e => new
                //     {
                //         table = e.Label,
                //         // value = e.Mesures
                //         // .Where(e => e.IdAxe == idAxe)
                //         // .Where(e => e.Responsable.Organisme.Type == typeTable)
                //         //                 .Count() * 100 / recommendationsCount,

                //         //value = e.Mesures.ActiviteMesures.Select(t => t.Activite)
                //         value = e.Mesures.Select(r => r.ActiviteMesures.Select(t => t.Activite))
                //         //.Where(e => e.Any( o => o.ActiviteMesures != null) && e.Any(o => o.ActiviteMesures.Any(r => r.Mesure.IdAxe == idAxe)))
                //         //.Where(e => e.Any( o => o.ActiviteMesures != null)  && e.Any(u => u.ActiviteMesures.Any(o=>o.Mesure.TypeMesure == typeTable)))
                //         .Count() * 100 / recommendationsCount,

                //         //value = 10
                //     })
                //     .Distinct()
                //     .ToListAsync()

                recommendationsCount = await _context.Mesures
                
                //.Where(e => e.Mesure.TypeMesure == typeTable)
                //.Where(e => e.Activite.ActiviteMesures != null)

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
                        value = e.Mesures
                        //.Select(r => r.ActiviteMesures.Select(t => t.Activite))
                        //.Where(e => e.Any( o => o.ActiviteMesures != null) && e.Any(o => o.ActiviteMesures.Any(r => r.Mesure.IdAxe == idAxe)))
                        //.Where(e => e.Any( o => o.ActiviteMesures != null)  && e.Any(u => u.ActiviteMesures.Any(o=>o.Mesure.TypeMesure == typeTable)))
                        .Count() ,

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
