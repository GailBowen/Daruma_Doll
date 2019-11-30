using System.Collections.Generic;
using System.Linq;
using Zza.Data;

namespace ZzaDashboard.Logic
{
    public class TenseManager
    {
        private PrincipalPart _principalPart;

        private string _stem;

        public List<Suffix> _suffixes { get; set; }

        public TenseManager(PrincipalPart principalPart, List<Suffix> suffixes)
        {
            _principalPart = principalPart;
            
            _stem = _principalPart.Present.Remove(_principalPart.Present.Length - 1);

            _suffixes = suffixes;
        }

        public Inflection CreateInflection(decimal conjugation, string mood, string tense, bool passive)
        {
            Suffix suffix = _suffixes.Where(s => s.Conjugation == conjugation && s.Mood == mood && s.Passive == passive && s.Tense == tense).FirstOrDefault();

            Inflection inflection = new Inflection();

            inflection.singular_first = SplitSuffix(suffix.singular_first);
            inflection.singular_second = SplitSuffix(suffix.singular_second);
            inflection.singular_third = SplitSuffix(suffix.singular_third);

            inflection.plural_first = SplitSuffix(suffix.plural_first);
            inflection.plural_second = SplitSuffix(suffix.plural_second);
            inflection.plural_third = SplitSuffix(suffix.plural_third);

            return inflection;
        }

        public string SplitSuffix(string suffix)
        {
            string inflection = string.Empty;

            if (suffix.Contains(','))
            {
                string[] segments = suffix.Split(',');

                foreach (var segment in segments)
                {
                    inflection += $"{_stem}{segment}, ";
                }

                inflection = inflection.Remove(inflection.Length - 2);
            }
            else
            {
                inflection = $"{_stem}{suffix}";
            }

            return inflection;
        }
    }
}
