﻿using System;
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

            var query = _context.Realisations
                .Where(e => hasAcess ? true : (e.Activite.Mesure.IdResponsable == idUser))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.Activite.Mesure.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Activite.IdMesure == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Activite.Mesure.IdResponsable == model.IdResponsable)
                .Where(e => model.IdAxe == 0 ? true : e.Activite.Mesure.IdAxe == model.IdAxe)
                .Where(e => model.IdSousAxe == 0 ? true : e.Activite.Mesure.IdSousAxe == model.IdSousAxe)
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
                    mesure = e.Activite.Mesure.Nom,
                    activite = e.Activite.Nom,
                    annee = e.Annee,
                    nom = e.Nom,
                    situation = e.Situation,
                    taux = e.Taux,
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
                .Where(e => hasAcess ? true : (e.Activite.Mesure.IdResponsable == idUser))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.Activite.Mesure.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Activite.IdMesure == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.Activite.Mesure.IdResponsable == model.IdResponsable)
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
                    organisme = e.Activite.Mesure.Responsable.Organisme.Label,
                    mesure = e.Activite.Mesure.Nom,
                    activite = e.Activite.Nom,
                    annee = e.Annee,
                    situation = e.Situation,
                    taux = e.Taux,
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
                .Where(e => hasAcess ? true : (e.IdResponsable == idUser))
                // .Where(e => e.Responsable.Organisme.Type == model.TypeOrganisme)
                .Where(e => model.IdCycle == 0 ? true : e.IdCycle == model.IdCycle)
                .Where(e => model.IdMesure == 0 ? true : e.Id == model.IdMesure)
                .Where(e => model.IdResponsable == 0 ? true : e.IdResponsable == model.IdResponsable)
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
                    organisme = e.Responsable.Organisme.Label,
                    mesure = e.Nom,
                    realisations = e.Activites.SelectMany(a => a.Realisations.Select(r => r.Nom)),
                    taux = e.Activites.SelectMany(a => a.Realisations.Select(r => r.Taux)),
                    // taux = e.ac,
                    indicateurs = e.IndicateurMesures.Select(i => i.Indicateur.Nom),
                })
                .ToListAsync();
            ;

            return Ok(new { list = list, count = count });
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneWithInclude(int id)
        {
            var model = await _context.Realisations.Where(e => e.Id == id)
                .Include(e => e.Activite)
                .ThenInclude(e => e.Mesure)
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
