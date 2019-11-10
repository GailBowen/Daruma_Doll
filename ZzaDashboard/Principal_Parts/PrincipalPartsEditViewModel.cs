﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;

namespace ZzaDashboard.Principal_Parts
{
    public class PrincipalPartsEditViewModel : INotifyPropertyChanged
    {
        private PrincipalPart _principalPart;
       
        private Tense _presentTense;

        private IPrincipalPartsRepsository _repository = new PrincipalPartsRepository();

        private ISuffixRepository _suffixRepository = new SuffixRepository();

        public PrincipalPartsEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Tense PresentTense
        {
            get { return _presentTense; }
            set
            {
                if (value != _presentTense)
                {
                    _presentTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PresentTense"));
                }
            }
        }

        public PrincipalPart PrincipalPart
        {
            get { return _principalPart; }
            set
            {
                if (value != _principalPart)
                {
                    _principalPart = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PrincipalPart"));
                }
            }
        }

        public List<Suffix> Suffixes { get; set; }

        public Guid PrincipalPartId { get; set; }
        public ICommand SaveCommand { get; set; }

        public async void LoadPrincipalPart()
        {
            PrincipalPart = await _repository.GetPrincipalPartAsync(PrincipalPartId);

            Suffixes = await _suffixRepository.GetSuffixsAsync();

            Suffix suffix = Suffixes.Where(s => s.Conjugation == 1.0m && s.Mood == "Indicative" && s.Passive == false && s.Tense == "Present").FirstOrDefault();

            Inflection inflection = new Inflection();

            string stem = PrincipalPart.Present.Remove(PrincipalPart.Present.Length - 1);

            inflection.singular_first = PrincipalPart.Present;
            inflection.singular_second = $"{stem}{suffix.singular_second}";
            inflection.singular_third = $"{stem}{suffix.singular_third}";

            inflection.plural_first = $"{stem}{suffix.plural_first}";
            inflection.plural_second = $"{stem}{suffix.plural_second}";
            inflection.plural_third = $"{stem}{suffix.plural_third}";


            //Indicative_Active_Present = inflection;

            PresentTense = new Tense();

            PresentTense.Indicative_Active_Present = inflection;

            suffix = Suffixes.Where(s => s.Conjugation == 1.0m && s.Mood == "Subjunctive" && s.Passive == false && s.Tense == "Present").FirstOrDefault();

            inflection = new Inflection();
            inflection.singular_first = $"{stem}{suffix.singular_first}";
            inflection.singular_second = $"{stem}{suffix.singular_second}";
            inflection.singular_third = $"{stem}{suffix.singular_third}";

            inflection.plural_first = $"{stem}{suffix.plural_first}";
            inflection.plural_second = $"{stem}{suffix.plural_second}";
            inflection.plural_third = $"{stem}{suffix.plural_third}";
                        
            PresentTense.Subjunctive_Active_Present = inflection;


            suffix = Suffixes.Where(s => s.Conjugation == 1.0m && s.Mood == "Indicative" && s.Passive == true && s.Tense == "Present").FirstOrDefault();

            inflection = new Inflection();
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

            PresentTense.Indicative_Passive_Present = inflection;

            suffix = Suffixes.Where(s => s.Conjugation == 1.0m && s.Mood == "Subjunctive" && s.Passive == true && s.Tense == "Present").FirstOrDefault();

            inflection = new Inflection();
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

            PresentTense.Subjunctive_Passive_Present = inflection;

        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
