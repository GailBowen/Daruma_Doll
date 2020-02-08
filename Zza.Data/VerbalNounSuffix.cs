using System.ComponentModel.DataAnnotations;

namespace Zza.Data
{
    public class VerbalNounSuffix
    {
        
        [Key]
        public int Id { get; set; }

        public decimal Conjugation { get; set; }

        public string Type { get; set; }
                
        public string Accusative { get; set; }

        public string Genitive { get; set; }

        public string Dative { get; set; }

        public string Ablative { get; set; }

    }
}
