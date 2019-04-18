using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SharedFitness.Model
{
    public class Day: ObservableCollection<Exercise>
    {
        public string Muscle { get; set; }
        public int DayFrequency { get; set; }
        //public ObservableCollection<Exercise> Exercise { get; set; }
    }
}
