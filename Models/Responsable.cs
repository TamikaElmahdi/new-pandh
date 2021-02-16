
namespace Models
{
    public partial class Responsable
    {
        public Responsable()
        {
        }

        public int IdMesure { get; set; }
        public int IdOrganisme { get; set; }
        public bool IsPrincipale { get; set;}
        public Mesure Mesure { get; set; }
        public Organisme Organisme { get; set; }
    }
}
