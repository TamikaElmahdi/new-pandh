
namespace Models
{
    public partial class OrganismeUser
    {
        public OrganismeUser()
        {
        }

        public int IdUser { get; set; }
        public int IdOrganisme { get; set; }
        public Organisme Organisme { get; set; }
        public User User { get; set; }

    }
}
