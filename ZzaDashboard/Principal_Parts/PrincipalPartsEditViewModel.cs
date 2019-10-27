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

        public Guid PrincipalPartId { get; set; }
        public ICommand SaveCommand { get; set; }

        public async void LoadPrincipalPart()
        {
            PrincipalPart = await _repository.GetPrincipalPartAsync(PrincipalPartId);
        }

        private async void OnSave()
        {
            PrincipalPart = await _repository.UpdatePrincipalPartAsync(PrincipalPart);
        }

    }
}
