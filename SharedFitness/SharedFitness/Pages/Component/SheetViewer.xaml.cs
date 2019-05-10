using SharedFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharedFitness.Pages.Component
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SheetViewer : ContentView
	{
		public SheetViewer ()
		{
			InitializeComponent ();
            DateSelect.Date = DateTime.Now;
            DateSelect.MinimumDate = DateTime.Today;
        }

        private void AddDay(object sender, EventArgs e)
        {
            Sheet s = this.BindingContext as Sheet;
            Day d = new Day();
            d.Muscle = "Muscle";
            d.DayFrequency = 1;
            s.Add(d);
        }
    }
}