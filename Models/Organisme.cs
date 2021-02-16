using System.Collections.Generic;

namespace Models
{
    public partial class Organisme
    {
        public Organisme()
        {
            Partenariats = new HashSet<Partenariat>();
            Responsables = new HashSet<Responsable>();
            OrganismeUsers = new HashSet<OrganismeUser>();
            Users = new HashSet<User>();
            
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public string Label { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public virtual ICollection<Partenariat> Partenariats { get; set; }
        public virtual ICollection<Responsable> Responsables { get; set; }
        public virtual ICollection<OrganismeUser> OrganismeUsers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
