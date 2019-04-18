using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SharedFitness.Model
{
    public class Sheet: ObservableCollection<Day>
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public float Lenght { get; set; }
        public int WeeklyFrequency { get; set; }
        //public ObservableCollection<Day> Day { get; set; }
    }
}
