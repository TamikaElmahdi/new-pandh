using System;
using System.Collections.Generic;

namespace Models
{
    public partial class ActiviteMesure
    {
        
        public int IdMesure { get; set; }
        public int IdActivite { get; set; }
        public Mesure Mesure { get; set; }
        public Activite Activite { get; set; }

    }
}
