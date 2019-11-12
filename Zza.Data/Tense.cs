using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Data
{
    public class Tense: INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private Inflection _indicative_Active_Present;
        private Inflection _subjunctive_Active_Present;
        private Inflection _indicative_Passive_Present;
        private Inflection _subjunctive_Passive_Present;

        public event PropertyChangedEventHandler PropertyChanged;


        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    //PropertyChanged(this, new PropertyChangedEventArgs("Name"));
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

        public Inflection Indicative_Passive_Present
        {
            get { return _indicative_Passive_Present; }
            set
            {
                if (value != _indicative_Passive_Present)
                {
                    _indicative_Passive_Present = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Indicative_Passive_Present"));
                }
            }
        }

        public Inflection Subjunctive_Passive_Present
        {
            get { return _subjunctive_Passive_Present; }
            set
            {
                if (value != _subjunctive_Passive_Present)
                {
                    _subjunctive_Passive_Present = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Subjunctive_Passive_Present"));
                }
            }
        }

        public Tense(string name)
        {
            Name = name;
        }
    }
}
