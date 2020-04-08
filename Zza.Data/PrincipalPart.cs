using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Zza.Data
{
    public class PrincipalPart
    {
        
        [Key]
        public Guid Id { get; set; }

        

        public string CombinedParts
        {
            get {
                return $"{Present}, {PresentInfinitive}, {PerfectActive}, {Supine}";
            }
            
        }
        
        public string Present { get; set; }

        public string PresentInfinitive { get; set; }

        public string PerfectActive { get; set; }

        public string Supine { get; set; }
                
        public bool Deponent { get; set; }

        public bool Defective { get; set; }

        public decimal Conjugation { get; set; }

        public bool SpecialPassiveInfinitive { get; set; }
    }
}
