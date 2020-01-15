using System.ComponentModel.DataAnnotations;

namespace Zza.Data
{
    public class NonFiniteSuffix
    {
        
        [Key]
        public int Id { get; set; }

        public decimal Conjugation { get; set; }

        public string Mood { get; set; }

        public string Type { get; set; }
        
        public bool Passive { get; set; }
        
        public string present { get; set; }

        public string perfect { get; set; }

        public string future { get; set; }
                          
    }
}
