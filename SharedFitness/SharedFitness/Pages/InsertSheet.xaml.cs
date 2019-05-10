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
	public partial class InsertSheet : ContentPage
	{
        Sheet s { get; set; } = new Sheet();
		public InsertSheet ()
		{
            s.Date = DateTime.Today.ToString();
            InitializeComponent ();
            SheetViewer.BindingContext = s;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(s);
        }
    }
}