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
        private string _testString;
        private ObservableCollection<Tense> _topp;

        private PrincipalPart _principalPart;
       
        private Tense Tense;

        private Tense _imperfectTense;

        private Tense _futureTense;

        private IPrincipalPartsRepsository _repository = new PrincipalPartsRepository();

        private ISuffixRepository _suffixRepository = new SuffixRepository();

        public PrincipalPartsEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        public string TestString
        {
            get { return _testString; }
            set
            {
                if (value != _testString)
                {
                    _testString = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TestString"));
                }
            }
        }


        public ObservableCollection<Tense> Topp
        {
            get { return _topp; }
            set
            {
                if (value != _topp)
                {
                    _topp = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Topp"));
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

            PresentTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", false);

            PresentTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", false);
                        
            PresentTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", true);
                        
            PresentTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", true);


            FutureTense = new Tense("Future");

            FutureTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", false);
            
            FutureTense.Indicative_Active.singular_first = "ignōrābō";

            FutureTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", false);

            FutureTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", true);

            FutureTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", true);


            ImperfectTense = new Tense("Imperfect");

            ImperfectTense.Indicative_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", false);

            ImperfectTense.Indicative_Active.singular_first = "ignōrābam";

            ImperfectTense.Subjunctive_Active = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", false);

            ImperfectTense.Indicative_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Indicative", "Present", true);

            ImperfectTense.Subjunctive_Passive = tenseManager.CreateInflection(PrincipalPart.Conjugation, "Subjunctive", "Present", true);

            Topp = new ObservableCollection<Tense>();

            Topp.Add(PresentTense);

            

            Topp.Add(ImperfectTense);

            

            Topp.Add(FutureTense);

            TestString = "Bob";
        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
