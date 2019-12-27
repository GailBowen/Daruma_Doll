using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Zza.Data;
using ZzaDashboard.Services;
using ZzaDashboard.Logic;
using System.Collections.ObjectModel;

namespace ZzaDashboard.Principal_Parts
{
    public class PrincipalPartsEditViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Tense> _tenses;

        private PrincipalPart _principalPart;
       
        private Tense Tense;

        private Tense _imperfectTense;

        private Tense _futureTense;

        private Tense _perfectTense;

        private Tense _pluperfectTense;

        private Tense _futurePerfectTense;

        private Tense _presentImperativeTense;

        private IPrincipalPartsRepsository _repository = new PrincipalPartsRepository();

        private ISuffixRepository _suffixRepository = new SuffixRepository();

        private IPassiveRepository _passiveRepository = new PassiveRepository();

        public PrincipalPartsEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        
        public ObservableCollection<Tense> Tenses
        {
            get { return _tenses; }
            set
            {
                if (value != _tenses)
                {
                    _tenses = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Tenses"));
                }
            }
        }

        public Tense PresentTense
        {
            get { return Tense; }
            set
            {
                if (value != Tense)
                {
                    Tense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PresentTense"));
                }
            }
        }


        public Tense FutureTense
        {
            get { return _futureTense; }
            set
            {
                if (value != _futureTense)
                {
                    _futureTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FutureTense"));
                }
            }
        }

        public Tense ImperfectTense
        {
            get { return _imperfectTense; }
            set
            {
                if (value != _imperfectTense)
                {
                    _imperfectTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ImperfectTense"));
                }
            }
        }

        public Tense PerfectTense
        {
            get { return _perfectTense; }
            set
            {
                if (value != _perfectTense)
                {
                    _perfectTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PerfectTense"));
                }
            }
        }

        public Tense PluperfectTense
        {
            get { return _pluperfectTense; }
            set
            {
                if (value != _pluperfectTense)
                {
                    _pluperfectTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PluperfectTense"));
                }
            }
        }

        public Tense FuturePerfectTense
        {
            get { return _futurePerfectTense; }
            set
            {
                if (value != _futurePerfectTense)
                {
                    _futurePerfectTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("FuturePerfectTense"));
                }
            }
        }


        public Tense PresentImperativeTense
        {
            get { return _presentImperativeTense; }
            set
            {
                if (value != _presentImperativeTense)
                {
                    _presentImperativeTense = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PresentImperativeTense"));
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

        public List<Passive> Passives { get; set; }

        public Guid PrincipalPartId { get; set; }
        public ICommand SaveCommand { get; set; }

        public async void LoadPrincipalPart()
        {
            PrincipalPart = await _repository.GetPrincipalPartAsync(PrincipalPartId);
            Suffixes = await _suffixRepository.GetSuffixsAsync();
            Passives = await _passiveRepository.GetPassivesAsync();
            

            TenseManager tenseManager = new TenseManager(PrincipalPart, Suffixes, Passives);

            PresentTense = new Tense("Present");

            PresentTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", false);

            PresentTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", false);
                        
            PresentTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", true);
                        
            PresentTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", true);


            FutureTense = new Tense("Future");


            FutureTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Future", false);


            FutureTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Future", true);


            ImperfectTense = new Tense("Imperfect");

            ImperfectTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Imperfect", false);


            ImperfectTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Imperfect", false);

            ImperfectTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Imperfect", true);

            ImperfectTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Imperfect", true);

            PerfectTense = new Tense("Perfect");
            PerfectTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Perfect", false);
            PerfectTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Perfect", false);
            PerfectTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Perfect", true);

            PerfectTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Perfect", true);


            PluperfectTense = new Tense("Pluperfect");
            PluperfectTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Pluperfect", false);
            PluperfectTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Pluperfect", true);
            PluperfectTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Pluperfect", false);
            PluperfectTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Pluperfect", true);

            FuturePerfectTense = new Tense("Future Perfect");
            FuturePerfectTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Future Perfect", false);
            FuturePerfectTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Future Perfect", true);

            PresentImperativeTense = new Tense("Present Imperative");
            PresentImperativeTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present Imperative", false);


            Tenses = new ObservableCollection<Tense>();

            Tenses.Add(PresentTense);
            
            Tenses.Add(ImperfectTense);

            Tenses.Add(FutureTense);

            Tenses.Add(PerfectTense);

            Tenses.Add(PluperfectTense);

            Tenses.Add(FuturePerfectTense);

            Tenses.Add(PresentImperativeTense);

        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
