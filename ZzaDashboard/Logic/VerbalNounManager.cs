using System.Collections.Generic;
using System.Linq;
using Zza.Data;

namespace ZzaDashboard.Logic
{
    public class VerbalNounManager
    {
        private PrincipalPart _principalPart;

        private string _presentStem;

        private string _supineStem;
        
        public List<VerbalNounSuffix> _verbalNounSuffixes { get; set; }

        public VerbalNounManager(PrincipalPart principalPart, List<VerbalNounSuffix> verbalNounSuffixes)
        {
            _principalPart = principalPart;
            
            _presentStem = _principalPart.Present.Remove(_principalPart.Present.Length - 1);

            if (string.IsNullOrEmpty(_principalPart.Supine) == false)
            {
                _supineStem = _principalPart.Supine.Remove(_principalPart.Supine.Length - 2);
            }
            
            _verbalNounSuffixes = verbalNounSuffixes;
                       
        }

        public VerbalNoun CreateVerbalNoun(decimal conjugation, string type)
        {
            VerbalNoun verbalNoun = new VerbalNoun();
 
            VerbalNounSuffix verbalNounSuffix = _verbalNounSuffixes.Where(s => s.Conjugation == conjugation && s.Type == type).FirstOrDefault();

            verbalNoun.Name = type;
            verbalNoun.Accusative = SplitSuffix(verbalNounSuffix.Accusative);
            verbalNoun.Genitive = SplitSuffix(verbalNounSuffix.Genitive);
            verbalNoun.Dative = SplitSuffix(verbalNounSuffix.Dative);
            verbalNoun.Ablative = SplitSuffix(verbalNounSuffix.Ablative);
            
            return verbalNoun;
        }

        public string SplitSuffix(string suffix)
        {
            string inflection = string.Empty;

            if (string.IsNullOrEmpty(suffix) == false)
            {
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
