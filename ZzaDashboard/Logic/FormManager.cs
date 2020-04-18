using System.Collections.Generic;
using System.Linq;
using Zza.Data;

namespace ZzaDashboard.Logic
{
    public class FormManager
    {
        private PrincipalPart _principalPart;

        private string _presentStem;

        private string _supineStem;
        
        public List<NonFiniteSuffix> _nonFiniteSuffixes { get; set; }

        public FormManager(PrincipalPart principalPart, List<NonFiniteSuffix> nonFiniteSuffixes)
        {
            _principalPart = principalPart;

            switch (_principalPart.Conjugation)
            {
                case 1:
                    _presentStem = _principalPart.Present.Remove(_principalPart.Present.Length - 1);
                    break;

                case 2:
                    _presentStem = _principalPart.Present.Remove(_principalPart.Present.Length - 2);
                    break;

                default:
                    _presentStem = _principalPart.Present.Remove(_principalPart.Present.Length - 1);
                    break;
            }

           

            if (string.IsNullOrEmpty(_principalPart.Supine) == false)
            {
                _supineStem = _principalPart.Supine.Remove(_principalPart.Supine.Length - 2);
            }

            _nonFiniteSuffixes = nonFiniteSuffixes;
                       
        }

        public NonFiniteForm CreateNonFiniteForm(decimal conjugation, string mood, string type, bool isPassive, bool isSpecial = false)
        {
            NonFiniteForm nonFiniteForm = new NonFiniteForm();
 
            NonFiniteSuffix nonFiniteSuffix = _nonFiniteSuffixes.Where(s => s.Conjugation == conjugation && s.Mood == mood && s.Passive == isPassive && s.Type == type).FirstOrDefault();

            if (isSpecial)
            {
                nonFiniteForm.present = SplitSuffix(nonFiniteSuffix.special);
            }
            else
            {
                nonFiniteForm.present = SplitSuffix(nonFiniteSuffix.present);
            }
            
            nonFiniteForm.future = SplitSuffix(nonFiniteSuffix.future);
            nonFiniteForm.perfect = SplitSuffix(nonFiniteSuffix.perfect);

            return nonFiniteForm;
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
