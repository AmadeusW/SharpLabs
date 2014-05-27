using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmadeusW.SharpLabs
{
    public class Lab : PropertyBase
    {
        private Dictionary<String, Experiment> _experimentLookup;

        private ObservableCollection<Experiment> _experiments;
        /// <summary>
        /// A property that lists all registered experiments
        /// </summary>
        /// <returns>An ObservableCollection property that can be bound to.</returns>
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

        public Lab()
        {
            _experimentLookup = new Dictionary<string, Experiment>();
        }

        /// <summary>
        /// Creates an entry for a new experiment.
        /// </summary>
        /// <param name="name">Name of the experiment. This name will be used to look up this experiment in the future.</param>
        /// <param name="active">Whether the experiment is active or not in this Lab.</param>
        public void RegisterExperiment(String name, bool active = false)
        {
            Experiment newExperiment = new Experiment(name, active);
            _experimentLookup.Add(name, newExperiment);
            Experiments.Add(newExperiment);
        }

        /// <summary>
        /// Removes information about specified experiment.
        /// Throws ArgumentException if specified experiment wasn't found.
        /// </summary>
        /// <param name="experimentName">Name of the specified experiment</param>
        public void DeregisterExperiment(String experimentName)
        {
            Experiment match = null;
            _experimentLookup.TryGetValue(experimentName, out match);
            if (match == null)
            {
                throw new ArgumentException("Could not find experiment named " + experimentName);
            }
            _experimentLookup.Remove(experimentName);
            Experiments.Remove(match);
        }

        /// <summary>
        /// Checks whether specified experiment is active or not.
        /// If experiment cannot be found, returns false.
        /// </summary>
        /// <param name="experimentName">Name of the specified experiment</param>
        /// <returns>Whether specified experiment is active or not.</returns>
        public bool IsActive(String experimentName)
        {
            Experiment match = null;
            _experimentLookup.TryGetValue(experimentName, out match);
            if (match == null)
            {
                return false;
            }
            return match.Active;
        }
    }
}
