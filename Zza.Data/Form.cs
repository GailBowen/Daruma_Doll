using System;
using System.ComponentModel;

namespace Zza.Data
{
    public class Form : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private NonFiniteForm _indicative_Active;
        private NonFiniteForm _indicative_Passive;
        

        public event PropertyChangedEventHandler PropertyChanged;


        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;

                    NotifyPropertyChanged("Name");
                }
            }
        }


        public NonFiniteForm Indicative_Active
        {
            get { return _indicative_Active; }
            set
            {
                if (value != _indicative_Active)
                {
                    _indicative_Active = value;

                    NotifyPropertyChanged("Indicative_Active");
                }
            }
        }
              

        public NonFiniteForm Indicative_Passive
        {
            get { return _indicative_Passive; }
            set
            {
                if (value != _indicative_Passive)
                {
                    _indicative_Passive = value;


                    NotifyPropertyChanged("Indicative_Passive");
                }
            }
        }


        public Form(string name)
        {
            Name = name;
        }

        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
