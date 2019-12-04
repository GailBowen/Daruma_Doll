using System.ComponentModel.DataAnnotations;

namespace Zza.Data
{
    public class Passive
    {

        [Key]
        public int Id { get; set; }

        public string Tense { get; set; }
        
        public string singular_first { get; set; }

        public string singular_second { get; set; }

        public string singular_third { get; set; }

        public string plural_first { get; set; }

        public string plural_second { get; set; }

        public string plural_third { get; set; }
    }
}
