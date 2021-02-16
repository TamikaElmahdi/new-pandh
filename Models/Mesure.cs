﻿using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Mesure
    {
        protected readonly AdminContext _context;

        public Mesure()
        {
            IndicateurMesures = new HashSet<IndicateurMesure>();
            IndicateurMesureValues = new HashSet<IndicateurMesureValue>();
            Activites = new HashSet<Activite>();
            Partenariats = new HashSet<Partenariat>();
            Responsables = new HashSet<Responsable>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public int IdType { get; set; }
        public int IdResponsable { get; set; }
        public int IdAxe { get; set; }
        public int IdSousAxe { get; set; }
        public int IdCycle { get; set; }
        public int IdNature { get; set; }
        public string ResultatsAttendu { get; set; }
        public string ObjectifGlobal { get; set; }
        public string ObjectifSpeciaux { get; set; }
        public Axe Axe { get; set; }
        public User Responsable { get; set; }
        public SousAxe SousAxe { get; set; }
        public Cycle Cycle { get; set; }
        public Nature Nature { get; set; }
        public virtual ICollection<IndicateurMesure> IndicateurMesures { get; set; }
        public virtual ICollection<IndicateurMesureValue> IndicateurMesureValues { get; set; }
         public virtual ICollection<Activite> Activites { get; set; }
         public virtual ICollection<Partenariat> Partenariats { get; set; }
         public virtual ICollection<Responsable> Responsables { get; set; }

         
    }
}
