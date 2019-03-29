using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SharedFitness.Model
{
    public class User: Resource
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public int Age { get; set; }
        public ObservableCollection<Sheet> Sheet { get; set; } = new ObservableCollection<Sheet>();
    }
}
