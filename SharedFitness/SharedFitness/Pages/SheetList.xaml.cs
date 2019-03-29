using SharedFitness.Model;
using SharedFitness.ViewModel;
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
	public partial class SheetList : ContentPage
	{
        ICollection<Sheet> sheetList = ((App)Application.Current).MainSFapp.User.Sheet;

        public SheetList ()
		{
			InitializeComponent ();
            SheetLV.ItemsSource = sheetList;
		}

        int count = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            sheetList.Add(new Sheet() { Date = count.ToString()});
        }
    }
}