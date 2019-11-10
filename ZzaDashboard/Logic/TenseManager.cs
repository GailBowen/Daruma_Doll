using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Logic
{
    public class TenseManager
    {

        private PrincipalPart _principalPart;

        public List<Suffix> _suffixes { get; set; }

        public TenseManager(PrincipalPart principalPart, List<Suffix> suffixes)
        {
            _principalPart = principalPart;
            _suffixes = suffixes;
            
        }

        public Inflection CreateInflection(decimal conjugation, string mood, string tense, bool passive)
        {
            Suffix suffix = _suffixes.Where(s => s.Conjugation == conjugation && s.Mood == mood && s.Passive == passive && s.Tense == tense).FirstOrDefault();

            Inflection inflection = new Inflection();

            string stem = _principalPart.Present.Remove(_principalPart.Present.Length - 1);

            inflection.singular_first = $"{stem}{suffix.singular_first}";

            if (suffix.singular_second.Contains(','))
            {
                string[] segments = suffix.singular_second.Split(',');

                foreach (var segment in segments)
                {
                    inflection.singular_second += $"{stem}{segment}, ";
                }

                inflection.singular_second = inflection.singular_second.Remove(inflection.singular_second.Length - 2);
            }
            else
            {
                inflection.singular_second = $"{stem}{suffix.singular_second}";
            }


            inflection.singular_third = $"{stem}{suffix.singular_third}";

            inflection.plural_first = $"{stem}{suffix.plural_first}";
            inflection.plural_second = $"{stem}{suffix.plural_second}";
            inflection.plural_third = $"{stem}{suffix.plural_third}";

            return inflection;
        }
    }
}
