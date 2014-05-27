using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusW.SharpLabs
{
    public class Experiment : PropertyBase
    {
        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private bool _active;
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                NotifyPropertyChanged();
            }
        }

        public Experiment(String name, bool active = false)
        {
            _name = name;
            _active = active;
        }
    }
}
