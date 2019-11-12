using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;
using ZzaDashboard.Logic;

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

            TenseManager tenseManager = new TenseManager(PrincipalPart, Suffixes);

            PresentTense = new Tense("Present");

            PresentTense.Indicative_Active_Present = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", false);

            PresentTense.Subjunctive_Active_Present = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", false);
                        
            PresentTense.Indicative_Passive_Present = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", true);
                        
            PresentTense.Subjunctive_Passive_Present = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", true);
        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
