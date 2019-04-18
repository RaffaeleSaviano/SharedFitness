using SharedFitness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharedFitness.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SheetView : ContentPage
	{
        private Sheet sheet;
		public SheetView ()
		{
			InitializeComponent ();
		}
        public SheetView(Sheet sheet): this()
        {
            this.sheet = sheet;
            this.BindingContext = this.sheet;
            ExerciseList.ItemsSource = this.sheet;
        }
    }
}