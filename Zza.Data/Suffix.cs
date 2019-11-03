using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class Suffix
    {
        
        [Key]
        public int Id { get; set; }

        public decimal Conjugation { get; set; }

        public string Mood { get; set; }

        public string Tense { get; set; }
        
        public bool Passive { get; set; }


        public string singular_first { get; set; }
        public string singular_second { get; set; }

        public string singular_third { get; set; }

        public string plural_first { get; set; }

        public string plural_second { get; set; }

        public string plural_third { get; set; }
                  
    }
}
