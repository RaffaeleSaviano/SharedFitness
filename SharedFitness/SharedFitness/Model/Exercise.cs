using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SharedFitness.Model
{
    public class Exercise
    {
        public string Name { get; set; }
        public ObservableCollection<Set> Scheme { get; set; }
        public float Wait { get; set; }
        public float Loadw { get; set; }
    }
}
