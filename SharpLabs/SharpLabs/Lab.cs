using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLabs
{
    public class Lab : PropertyBase
    {
        private ObservableCollection<Experiment> _experiments;
        public ObservableCollection<Experiment> Experiments
        {
            get
            {
                return _experiments;
            }
            set
            {
                _experiments = value;
                NotifyPropertyChanged();
            }
        }

    }
}
