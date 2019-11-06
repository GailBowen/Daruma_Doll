using System;
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
        private Inflection _indicative_Active_Present;
        private Inflection _subjunctive_Active_Present;

        private IPrincipalPartsRepsository _repository = new PrincipalPartsRepository();

        private ISuffixRepository _suffixRepository = new SuffixRepository();

        public PrincipalPartsEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
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

        public Inflection Indicative_Active_Present
        {
            get { return _indicative_Active_Present; }
            set
            {
                if (value != _indicative_Active_Present)
                {
                    _indicative_Active_Present = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Indicative_Active_Present"));
                }
            }
        }

        public Inflection Subjunctive_Active_Present
        {
            get { return _subjunctive_Active_Present; }
            set
            {
                if (value != _subjunctive_Active_Present)
                {
                    _subjunctive_Active_Present = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Subjunctive_Active_Present"));
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


            Indicative_Active_Present = inflection;


            suffix = Suffixes.Where(s => s.Conjugation == 1.0m && s.Mood == "Subjunctive" && s.Passive == false && s.Tense == "Present").FirstOrDefault();

            inflection = new Inflection();
            inflection.singular_first = $"{stem}{suffix.singular_first}";
            inflection.singular_second = $"{stem}{suffix.singular_second}";
            inflection.singular_third = $"{stem}{suffix.singular_third}";

            inflection.plural_first = $"{stem}{suffix.plural_first}";
            inflection.plural_second = $"{stem}{suffix.plural_second}";
            inflection.plural_third = $"{stem}{suffix.plural_third}";

            Subjunctive_Active_Present = inflection;

        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
