using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Data
{
    public class Tense : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private Inflection _indicative_Active;
        private Inflection _subjunctive_Active;
        private Inflection _indicative_Passive;
        private Inflection _subjunctive_Passive;

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


        public Inflection Indicative_Active
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

        public Inflection Subjunctive_Active
        {
            get { return _subjunctive_Active; }
            set
            {
                if (value != _subjunctive_Active)
                {
                    _subjunctive_Active = value;

                    NotifyPropertyChanged("Subjunctive_Active");
                }
            }
        }

        public Inflection Indicative_Passive
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

        public Inflection Subjunctive_Passive
        {
            get { return _subjunctive_Passive; }
            set
            {
                if (value != _subjunctive_Passive)
                {
                    _subjunctive_Passive = value;

                    NotifyPropertyChanged("Subjunctive_Passive");
                }
            }
        }

        public Tense(string name)
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
