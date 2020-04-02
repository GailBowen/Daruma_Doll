using System.Collections.Generic;
using System.Linq;
using Zza.Data;

namespace ZzaDashboard.Logic
{
    public class TenseManager
    {
        private PrincipalPart _principalPart;

        private string _presentStem;

        private string _supineStem;

        public List<Suffix> _suffixes { get; set; }

        public List<Passive> _passives { get; set; }

        public TenseManager(PrincipalPart principalPart, List<Suffix> suffixes, List<Passive> passives)
        {
            _principalPart = principalPart;
            
            _presentStem = _principalPart.Present.Remove(_principalPart.Present.Length - 1);

            if (string.IsNullOrEmpty(_principalPart.Supine) == false)
            {
                _supineStem = _principalPart.Supine.Remove(_principalPart.Supine.Length - 2);
            }

            _suffixes = suffixes;

            _passives = passives;
        }

        public Inflection CreateInflection(decimal conjugation, string mood, string tense, bool isPassive)
        {
            Inflection inflection = new Inflection();


            if ((tense == "Perfect" || tense == "Pluperfect" || tense == "Future Perfect") && isPassive)
            {
                Passive passive = _passives.Where(p => p.Tense == tense && p.Mood == mood).FirstOrDefault();

                if (passive != null)
                {

                    inflection.singular_first = $"{passive.singular_first} {_supineStem}us";
                    inflection.singular_second = $"{passive.singular_second} {_supineStem}us";
                    inflection.singular_third = $"{passive.singular_third} {_supineStem}us";

                    inflection.plural_first = $"{passive.plural_first} {_supineStem}i";
                    inflection.plural_second = $"{passive.plural_second} {_supineStem}i";
                    inflection.plural_third = $"{passive.plural_third} {_supineStem}i";
                }

            }
            else
            {
             
                Suffix suffix = _suffixes.Where(s => s.Conjugation == conjugation && s.Mood == mood && s.Passive == isPassive && s.Tense == tense).FirstOrDefault();

                inflection.singular_first = SplitSuffix(suffix.singular_first);
                inflection.singular_second = SplitSuffix(suffix.singular_second);
                inflection.singular_third = SplitSuffix(suffix.singular_third);

                inflection.plural_first = SplitSuffix(suffix.plural_first);
                inflection.plural_second = SplitSuffix(suffix.plural_second);
                inflection.plural_third = SplitSuffix(suffix.plural_third);
            }
            
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
                    inflection += $"{_presentStem}{segment}, ";
                }

                inflection = inflection.Remove(inflection.Length - 2);
            }
            else
            {
                if (string.IsNullOrEmpty(suffix) == false)
                    inflection = $"{_presentStem}{suffix}";
            }

            return inflection;
        }

        public string SplitPassive(string passive, bool plural)
        {
            string inflection = string.Empty;

            inflection = $"{passive} {_supineStem}us";

            return inflection;
        }
    }
}
