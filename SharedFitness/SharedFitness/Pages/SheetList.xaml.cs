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

        public SheetList ()
		{
			InitializeComponent ();
            SheetLV.ItemsSource = SFapp.App.Sheets;
		}

        int count = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            SFapp.App.Sheets.Add(new Sheet() { Name = "Name"+count.ToString(), Date= count.ToString()+"/"+ count.ToString() + "/" + count.ToString()});
        }

        private void SheetLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Sheet selected = e.SelectedItem as Sheet;
            ((NavigationPage)((MainPageCS)Application.Current.MainPage).Detail).PushAsync(new SheetView(selected));
        }
    }
}