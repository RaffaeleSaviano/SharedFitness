using SharedFitness.ExtensionMethods;
using SharedFitness.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SharedFitness.ViewModel
{
    public class SFapp
    {
        public static SFapp App { get; set; } = new SFapp();
        public User User { get; set; }

        public ObservableCollection<Sheet> Sheets { get; set; } =
            new ObservableCollection<Sheet>() {
                new Sheet() { Name = "Raul", Date="08/01/1999", WeeklyFrequency=1},
                new Sheet() { Name = "b", Date="17/11/2000", WeeklyFrequency=12},
                new Sheet() { Name = "c", Date="12/08/1997", WeeklyFrequency=4}
            };

        public ObservableCollection<Day> Day { get; set; } =
              new ObservableCollection<Day>() {
                  new Day() { Muscle = "Petto", DayFrequency=1 },
                  new Day() { Muscle = "Schiena", DayFrequency=1  },
                  new Day() { Muscle = "Spalle", DayFrequency=2  }
              };

        public ObservableCollection<Exercise> Exercices { get; set; } =
              new ObservableCollection<Exercise>() {
                  new Exercise() { Name = "Panca piana", Loadw=50 },
                  new Exercise() { Name = "Panca alta", Loadw=45 },
                  new Exercise() { Name = "Chest press presa stretta", Loadw=50 }
              };
        public SFapp()
        {
            Sheet s = new Sheet() { Name = "Prova", Date = "11/22/3333", WeeklyFrequency = 5 };
            s.AddRange(Day);
            Day.First().AddRange(Exercices);
            Sheets.Add(s);
        }
    }
}
