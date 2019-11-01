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

        private IPrincipalPartsRepsository _repository = new PrincipalPartsRepository();

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

        public Guid PrincipalPartId { get; set; }
        public ICommand SaveCommand { get; set; }

        public async void LoadPrincipalPart()
        {
            PrincipalPart = await _repository.GetPrincipalPartAsync(PrincipalPartId);

            Inflection inflection = new Inflection();
            inflection.singular_first = PrincipalPart.Present;
            inflection.singular_second = "test123";

            Indicative_Active_Present = inflection;
        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
